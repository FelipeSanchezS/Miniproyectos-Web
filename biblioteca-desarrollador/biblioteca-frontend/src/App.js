import React, { useState } from "react";
import Estadisticas from "./components/estadisticas";
import Libros from "./components/Libro";

function App() {
  const [vista, setVista] = useState("estadisticas");

  return (
    <div className="App p-4">
      <div className="mb-4">
        <button onClick={() => setVista("estadisticas")} className="bg-green-500 text-white p-2 mr-2">
          Estadísticas
        </button>
        <button onClick={() => setVista("libros")} className="bg-blue-500 text-white p-2">
          Libros
        </button>
      </div>

      {vista === "estadisticas" ? <Estadisticas /> : <Libros />}
    </div>
  );
}

export default App;
