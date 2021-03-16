import React, { useEffect, useState, useContext } from "react";
import TodosApi from "./api/TodosApi";
import { TodosContext } from "./TodosContext";
import "./Todos.css";

export default function Todos() {
  const [todos, setTodos] = useContext(TodosContext);
  const [addTitle, setAddTitle] = useState("");
  const [addDescription, setAddDescription] = useState("");
  const [status, setAddStatus] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();
    const todo = await TodosApi.newTodo({
      Title: addTitle,
      Description: addDescription,
      Status: status,
    });
    if (todo) {
      setTodos((prevTodos) => {
        return [...prevTodos, todo];
      });
    }
  }

  async function deleteTodo(Id) {
    const response = await TodosApi.deleteTodo(Id);
    if (!response.error) {
      setTodos((prevTodos) => {
        return [...prevTodos.filter((todo) => todo.id !== Id)];
      });
    }
  }

  useEffect(() => {
    (async () => {
      const resp = await TodosApi.getTodos();
      if (resp) setTodos(resp);
    })();
  }, []);
  console.log(todos);
  return (
    <div className="todos-container">
      <form onSubmit={handleSubmit} className="todos-form">
        <input
          type="text"
          placeholder="Title"
          onChange={(e) => setAddTitle(e.target.value)}
          value={addTitle}
        />
        <input
          type="text"
          placeholder="Description"
          onChange={(e) => setAddDescription(e.target.value)}
          value={addDescription}
        />
        <input
          type="text"
          placeholder="status"
          onChange={(e) => setAddStatus(e.target.value)}
          value={status}
        />
        <button type="submit">Add</button>
      </form>
      <ul className="todos-list">
        {todos.map((todo) => (
          <li key={todo.id} className="todo-item">
            <div className="text-wrap">
              <h2>{todo.title}</h2>
              <p>{todo.description}</p>
              <span>{todo.status}</span>
            </div>

            <button
              onClick={() => {
                deleteTodo(todo.id);
              }}
            >
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
