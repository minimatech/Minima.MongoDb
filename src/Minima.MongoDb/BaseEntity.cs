namespace Minima.MongoDb;

public abstract partial class BaseEntity : ParentEntity
{
    protected BaseEntity()
    {
        UserFields = new List<UserField>();
    }

    public IList<UserField> UserFields { get; set; }

}