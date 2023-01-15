using Minima.MongoDb;
using Minima.MongoDb.ConsoleTest.Domain;
using Minima.MongoDb.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb(m => m.ConnectionString = "mongodb://localhost:27017/testdb");

var app = builder.Build();




try
{
    
    var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetService<IRepository<Product>>();
    
    //var repository = app.Services.GetService<IRepository<Product>>();
    var product = new Product {Name = "Test"};
    service.InsertAsync(product).Wait();
    
    
    var price = new Price(){  DisplayOrder  = 10, ProductId = product.Id};
    
    service.AddToSet(product.Id, x => x.ProductCategories, price);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}



app.MapGet("/", () => "Hello World!");

app.Run();