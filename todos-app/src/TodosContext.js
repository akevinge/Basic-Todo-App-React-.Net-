import { createContext, useState } from "react";

export const TodosContext = createContext();

export function TodosContextProvider(props) {
  const [todos, setTodos] = useState([]);
  return <TodosContext.Provider value={[todos, setTodos]}>{props.children}</TodosContext.Provider>;
}
