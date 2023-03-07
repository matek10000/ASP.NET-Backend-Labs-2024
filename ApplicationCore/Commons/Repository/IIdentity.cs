namespace ApplicationCore.Interfaces.Repository;

public interface IIdentity<K>: IComparable<K> where K: IComparable<K>
{
    public K Id
    {
        get;
        set;
    }
}