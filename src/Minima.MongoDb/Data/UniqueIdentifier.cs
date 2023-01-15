using MongoDB.Bson;

namespace Minima.MongoDb.Data;

public static class UniqueIdentifier
{
    public static string New => ObjectId.GenerateNewId().ToString();
}