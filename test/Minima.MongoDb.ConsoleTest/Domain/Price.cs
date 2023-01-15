namespace Minima.MongoDb.ConsoleTest.Domain;

public class Price : SubBaseEntity
{
    /// <summary>
    /// Gets or sets the category identifier
    /// </summary>
    public string ProductId { get; set; }
    
    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}