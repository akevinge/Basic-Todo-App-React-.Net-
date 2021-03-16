using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todos.Data;
using Todos.Models;

namespace Todos.Controllers
{
    [ApiController]
    [Route("api/todos")]
    // [EnableCors]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepo _repository;

        public TodosController(ITodosRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            IEnumerable<Todo> Todos = _repository.GetTodos();
            return Ok(Todos);
        }


        [HttpGet("{id}", Name="GetTodoById")]
        public ActionResult<Todo> GetTodoById(string Id)
        {
            Todo TodoModel = _repository.GetTodoById(Id);
            if(TodoModel == null) return NotFound();
            return Ok(TodoModel);
        }

        [HttpPost]
        public ActionResult CreateTodo(Todo todo)
        {
            _repository.CreateTodo(todo);
            return CreatedAtRoute(nameof(GetTodoById), new { Id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTodo(string Id, [FromBody] Todo todo)
        {
            _repository.UpdateTodo(Id, todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(string Id)
        {
            _repository.DeleteTodo(Id);
            return NoContent();
        }
    }
}