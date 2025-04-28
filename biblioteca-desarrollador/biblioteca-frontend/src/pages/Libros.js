import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Libros = () => {
  const [libros, setLibros] = useState([]);

  useEffect(() => {
    axios.get('http://127.0.0.1:8000/api/libros')
      .then(response => {
        setLibros(response.data);
      })
      .catch(error => {
        console.error('Error al obtener los libros:', error);
      });
  }, []);

  return (
    <div className="p-5">
      <h1 className="text-2xl font-bold mb-4">Lista de Libros</h1>
      <table className="w-full table-auto border-collapse">
        <thead>
          <tr>
            <th className="border p-2">Título</th>
            <th className="border p-2">Autor</th>
            <th className="border p-2">Género</th>
            <th className="border p-2">Disponible</th> {/* 🔥 Esta es la nueva columna */}
            <th className="border p-2">Acciones</th>
          </tr>
        </thead>
        <tbody>
          {libros.map(libro => (
            <tr key={libro.id}>
              <td className="border p-2">{libro.titulo}</td>
              <td className="border p-2">{libro.autor}</td>
              <td className="border p-2">{libro.genero}</td>
              <td className="border p-2">
                {libro.disponible === 1 ? 'Sí' : 'No'}
              </td> {/* 🔥 Mostrar si está disponible */}
              <td className="border p-2">
                {/* Aquí puedes agregar tus botones Editar y Eliminar */}
                <button className="bg-blue-500 text-white px-2 py-1 rounded mr-2">Editar</button>
                <button className="bg-red-500 text-white px-2 py-1 rounded">Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Libros;
