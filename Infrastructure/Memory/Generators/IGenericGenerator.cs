namespace Infrastructure.Memory;

public interface IGenericGenerator<K>
{
    K Next { get; }
    K Current { get; }
}