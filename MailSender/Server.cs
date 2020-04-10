namespace MailSender.lib
{
    public class Server
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; } = true;
        public string Login { get; set; }
        public string Password { get; set; }

        public Server(int id, string name, string address, int port, string login, string password)
        {
            ID = id;
            Name = name;
            Address = address;
            Port = port;
            Login = login;
            Password = password;
        }
    }
}
