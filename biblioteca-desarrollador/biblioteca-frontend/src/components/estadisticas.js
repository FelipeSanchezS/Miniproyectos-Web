import React, { useEffect, useState } from "react";
import { Bar } from "react-chartjs-2";
import api from "../api";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend);

const Estadisticas = () => {
  const [libros, setLibros] = useState([]);

  useEffect(() => {
    api.get("/libros").then((res) => setLibros(res.data));
  }, []);

  // Procesar datos para el gráfico
  const datosPorGenero = libros.reduce((acc, libro) => {
    acc[libro.genero] = (acc[libro.genero] || 0) + 1;
    return acc;
  }, {});

  const data = {
    labels: Object.keys(datosPorGenero),
    datasets: [
      {
        label: "Cantidad de libros por género",
        data: Object.values(datosPorGenero),
        backgroundColor: "rgba(54, 162, 235, 0.6)",
        borderColor: "rgba(54, 162, 235, 1)",
        borderWidth: 1,
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: "top",
      },
      title: {
        display: true,
        text: "Estadísticas de Libros por Género",
      },
    },
  };

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">Estadísticas de la Biblioteca</h2>
      <Bar data={data} options={options} />
    </div>
  );
};

export default Estadisticas;
