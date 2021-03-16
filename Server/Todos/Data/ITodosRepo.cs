using System.Collections.Generic;
using Todos.Models;


namespace Todos.Data
{
    public interface ITodosRepo 
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodoById(string Id);
        void CreateTodo(Todo todo);
        void UpdateTodo(string Id, Todo todo);
        void DeleteTodo(string Id);
    }
}