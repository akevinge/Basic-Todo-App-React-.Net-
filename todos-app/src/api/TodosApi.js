module.exports = {
  getTodos: async () => {
    return await fetch("https://localhost:5001/api/todos", {
      method: "get",
    }).then((resp) => {
      if (resp.status === 200) return resp.json();
      else return undefined;
    });
  },
  newTodo: async (todo) => {
    return await fetch("https://localhost:5001/api/todos", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      mode: "cors",
      body: JSON.stringify(todo),
    }).then((resp) => {
      if (resp.status === 201) return resp.json();
    });
  },
  deleteTodo: async (Id) => {
    return await fetch(`https://localhost:5001/api/todos/${Id}`, {
      method: "delete",
      mode: "cors",
    }).then((resp) => {
      if (resp.ok) return {};
      return { error: resp };
    });
  },
};
