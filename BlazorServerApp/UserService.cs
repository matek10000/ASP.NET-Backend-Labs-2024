namespace BlazorServerApp
{

    public interface IUserService
    {
        void Add(string connectionId, string username);
        void RemoveByName(string username);
        string GetConnectionIdByName(string username);
        IEnumerable<(string ConnectionId, string Username)> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();

        public void Add(string connectionId, string username)
        {
            if (!_users.ContainsKey(username))
            {
                _users.Add(username, connectionId);
                Console.WriteLine($"User '{username}' with connection ID '{connectionId}' added.");
            }
            else
            {
                Console.WriteLine($"Username '{username}' is already in use.");
            }
        }

        public void RemoveByName(string username)
        {
            if (_users.ContainsKey(username))
            {
                _users.Remove(username);
                Console.WriteLine($"User '{username}' removed.");
            }
            else
            {
                Console.WriteLine($"User '{username}' not found.");
            }
        }

        public string GetConnectionIdByName(string username)
        {
            return _users.GetValueOrDefault(username);
        }

        public IEnumerable<(string ConnectionId, string Username)> GetAll()
        {
            var allUsers = _users.Select(u => (u.Value, u.Key)).ToList();

            return allUsers;
        }

    }
}
