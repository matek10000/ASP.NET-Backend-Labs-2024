namespace Infrastructure.Memory;

public class IntGenerator: IGenericGenerator<int>
{
    private int _value;
    
    public int Next => ++_value;

    public int Current => _value;

    public IntGenerator(int init = 0)
    {
        _value = init;
    }
}