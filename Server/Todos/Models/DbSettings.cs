namespace Todos.Models
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}