using Microsoft.Extensions.DependencyInjection;
using Minima.MongoDb.Data;
using Minima.MongoDb.Utils;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Minima.MongoDb.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, Action<MongoDbSettings> options)
    {
        BsonSerializer.RegisterSerializer(typeof(DateTime), new BsonUtcDateTimeSerializer());

        BsonSerializer.RegisterSerializer(typeof(Dictionary<int, int>),
            new DictionaryInterfaceImplementerSerializer<Dictionary<int, int>>(DictionaryRepresentation.ArrayOfArrays));

        // global set an equivalent of [BsonIgnoreExtraElements] for every Domain Model
        var cp = new ConventionPack
        {
            new IgnoreExtraElementsConvention(true)
        };
        ConventionRegistry.Register("ApplicationConventions", cp, t => true);


        // TODO: there must be a cleaner way to do IOptions validation...
        //var databaseSettings = config.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
        var databaseSettings = new MongoDbSettings();
        options(databaseSettings);
        string rootConnectionString = databaseSettings.ConnectionString;
        if (string.IsNullOrEmpty(rootConnectionString))
        {
            throw new InvalidOperationException("DB ConnectionString is not configured.");
        }

        string connectionString = databaseSettings.ConnectionString;
        var mongoUrl = new MongoUrl(connectionString);
        string databaseName = mongoUrl.DatabaseName;
        var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
        clientSettings.LinqProvider = MongoDB.Driver.Linq.LinqProvider.V3;
        services.AddScoped(c => new MongoClient(clientSettings).GetDatabase(databaseName));
        

        // store files context - gridfs
        services.AddScoped<IStoreFilesContext, MongoStoreFilesContext>();

        // Mongo Repository
        services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
        services.AddSingleton<MongoDbSettings>(databaseSettings);
        return services;
    }
}