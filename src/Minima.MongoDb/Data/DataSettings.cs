namespace Minima.MongoDb.Data;

/// <summary>
/// Data settings (connection string information)
/// </summary>
public partial class DataSettings
{

    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; set; }

    
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(ConnectionString);
    }
}