namespace Minima.MongoDb.ConsoleTest.Domain;

public class Product : BaseEntity
{  
    private ICollection<Price> _productCategories;
    public string Name { get; set; }
    public int Price { get; set; }
    
    public virtual ICollection<Price> ProductCategories
    {
        get { return _productCategories ??= new List<Price>(); }
        protected set { _productCategories = value; }
    }

}