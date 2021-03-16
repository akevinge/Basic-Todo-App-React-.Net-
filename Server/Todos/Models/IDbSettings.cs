namespace Todos.Models
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        
    }
}