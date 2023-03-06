using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class User: IIdentity<int>
{
    public int Id { get; set; }
    
    public string Username { get; init; }
}