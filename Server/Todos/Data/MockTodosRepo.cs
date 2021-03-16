using System.Collections.Generic;
using MongoDB.Bson;
using Todos.Models;


namespace Todos.Data
{
    public class MockTodosRepo : ITodosRepo
    {
        public IEnumerable<Todo> GetTodos()
        {
            return new List<Todo>
            {
                new Todo{Id="", Title="boil water", Description="do it today", Status="Not completed"},
                new Todo{Id = "", Title="Boil eggs", Description="do it tomorrow", Status="not started"}
            };

        }

        public Todo GetTodoById(string Id)
        {
            return new Todo {Id ="", Title="test", Description="do wed", Status="in progress"};
        }

        public void CreateTodo(Todo todo)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTodo(string Id)
        {
            throw new System.NotImplementedException();
        }


        public void UpdateTodo(string Id, Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}