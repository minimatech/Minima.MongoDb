using Minima.MongoDb.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Minima.MongoDb.Utils;

public class MongoStoreFilesContext : IStoreFilesContext
{
    protected readonly IMongoDatabase _database;
    
    public MongoStoreFilesContext(MongoDbSettings mongoDbSettings)
    {
        var mongoDbSettings1 = mongoDbSettings;
        

        var mongourl = new MongoUrl(mongoDbSettings1.ConnectionString);
        var databaseName = mongourl.DatabaseName;
        _database = new MongoClient(mongoDbSettings1.ConnectionString).GetDatabase(databaseName);
    }
    
    public async Task<byte[]> BucketDownload(string id)
    {
        var bucket = new MongoDB.Driver.GridFS.GridFSBucket(_database);
        var binary = await bucket.DownloadAsBytesAsync(new ObjectId(id), new MongoDB.Driver.GridFS.GridFSDownloadOptions() { CheckMD5 = true });
        return binary;

    }
    public async Task BucketDelete(string id)
    {
        var bucket = new MongoDB.Driver.GridFS.GridFSBucket(_database);
        await bucket.DeleteAsync(new ObjectId(id));
    }

    public async Task<string> BucketUploadFromBytes(string filename, byte[] source)
    {
        var bucket = new MongoDB.Driver.GridFS.GridFSBucket(_database);
        var id = await bucket.UploadFromBytesAsync(filename, source);
        return id.ToString();
    }
}