namespace ID_24_58158_2_LoginSystem
{
    internal sealed class UserSession
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public int LoginHistoryId { get; set; }

        public UserSession(int userId, string username, string fullName)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
        }
    }
}
