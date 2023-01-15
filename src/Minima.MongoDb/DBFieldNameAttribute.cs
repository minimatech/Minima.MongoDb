namespace Minima.MongoDb;

[AttributeUsage(AttributeTargets.Property)]
public class DBFieldNameAttribute : Attribute
{
    private readonly string _name;

    public DBFieldNameAttribute(string name)
    {
        this._name = name;
    }
    public virtual string Name => _name;
}