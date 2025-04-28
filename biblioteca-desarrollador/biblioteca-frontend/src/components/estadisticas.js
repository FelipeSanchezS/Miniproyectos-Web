import React, { useEffect, useState } from "react";
import api from "../api";
import { Bar } from "react-chartjs-2";
import { Chart, BarElement, CategoryScale, LinearScale, Tooltip, Legend } from 'chart.js';

Chart.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend);

const Estadisticas = () => {
  const [topLibros, setTopLibros] = useState([]);
  const [prestamosActivos, setPrestamosActivos] = useState(0);

  useEffect(() => {
    api.get("/estadisticas/libros-mas-prestados").then(res => setTopLibros(res.data));
    api.get("/estadisticas/prestamos-activos").then(res => setPrestamosActivos(res.data.prestamos_activos));
  }, []);

  const chartData = {
    labels: topLibros.map(p => p.libro.titulo),
    datasets: [
      {
        label: "Veces Prestado",
        data: topLibros.map(p => p.total),
        backgroundColor: "rgba(75,192,192,0.6)"
      }
    ]
  };

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">Estadísticas de Biblioteca</h2>

      <div className="mb-8">
        <h3 className="text-lg mb-2">Top 5 libros más prestados</h3>
        <Bar data={chartData} />
      </div>

      <div>
        <h3 className="text-lg">Préstamos activos: <strong>{prestamosActivos}</strong></h3>
      </div>
    </div>
  );
};

export default Estadisticas;
