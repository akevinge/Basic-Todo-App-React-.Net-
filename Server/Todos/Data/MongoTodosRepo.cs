using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Todos.Models;

namespace Todos.Data
{
    public class MongoTodosRepo : ITodosRepo
    {
        private readonly IMongoCollection<Todo> _todosCollection;
        public MongoTodosRepo(IDbSettings settings)
            {
            var Client = new MongoClient(settings.ConnectionString);
            _todosCollection = Client.GetDatabase(settings.DatabaseName).GetCollection<Todo>("Todos");
        }

        public void CreateTodo(Todo todo)
        {
             _todosCollection.InsertOne(todo);
        }

        public void DeleteTodo(string Id)
        {
            _todosCollection.FindOneAndDelete(todo => todo.Id == Id);
        }

        public Todo GetTodoById(string Id)
        {
            return _todosCollection.Find(todo => todo.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _todosCollection.Find(todo =>true).ToList();
        }

        public void UpdateTodo(string Id, Todo todo)
        {
            var updateBuilder = Builders<Todo>.Update;
            var updates = new List<UpdateDefinition<Todo>>();
            
            if(todo.Title!=null)updates.Add(Builders<Todo>.Update.Set("Title",todo.Title));
            if(todo.Description!=null)updates.Add(Builders<Todo>.Update.Set("Description",todo.Description));
            if(todo.Status!=null)updates.Add(Builders<Todo>.Update.Set("Status",todo.Status));
            var finalUpdates = Builders<Todo>.Update.Combine(updates);
            _todosCollection.UpdateOne(d =>d.Id == Id, finalUpdates);
        }
    }
}


