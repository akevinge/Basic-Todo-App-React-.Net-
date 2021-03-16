import "./App.css";
import Todos from "./Todos";
import { TodosContextProvider } from "./TodosContext";

function App() {
  return (
    <div className="App">
      <TodosContextProvider>
        <Todos />
      </TodosContextProvider>
    </div>
  );
}

export default App;
