import React, { useEffect, useState } from "react";
import api from "../api";

const Libros = () => {
  const [libros, setLibros] = useState([]);
  const [titulo, setTitulo] = useState("");
  const [autor, setAutor] = useState("");
  const [genero, setGenero] = useState("");
  const [idEditando, setIdEditando] = useState(null);

  useEffect(() => {
    cargarLibros();
  }, []);

  const cargarLibros = () => {
    api.get("/libros").then((res) => setLibros(res.data));
  };

  const guardarLibro = (e) => {
    e.preventDefault();
    if (idEditando) {
      api.put(`/libros/${idEditando}`, { titulo, autor, genero }).then(() => {
        setIdEditando(null);
        setTitulo("");
        setAutor("");
        setGenero("");
        cargarLibros();
      });
    } else {
      api.post("/libros", { titulo, autor, genero }).then(() => {
        setTitulo("");
        setAutor("");
        setGenero("");
        cargarLibros();
      });
    }
  };

  const editarLibro = (libro) => {
    setIdEditando(libro.id);
    setTitulo(libro.titulo);
    setAutor(libro.autor);
    setGenero(libro.genero);
  };

  const eliminarLibro = (id) => {
    if (window.confirm("¿Seguro de eliminar este libro?")) {
      api.delete(`/libros/${id}`).then(() => cargarLibros());
    }
  };

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">{idEditando ? "Editar Libro" : "Agregar Libro"}</h2>

      <form onSubmit={guardarLibro} className="mb-6">
        <input 
          type="text"
          placeholder="Título"
          value={titulo}
          onChange={(e) => setTitulo(e.target.value)}
          className="border p-2 mr-2"
          required
        />
        <input 
          type="text"
          placeholder="Autor"
          value={autor}
          onChange={(e) => setAutor(e.target.value)}
          className="border p-2 mr-2"
          required
        />
        <input 
          type="text"
          placeholder="Género"
          value={genero}
          onChange={(e) => setGenero(e.target.value)}
          className="border p-2 mr-2"
          required
        />
        <button type="submit" className="bg-blue-500 text-white p-2">
          {idEditando ? "Actualizar" : "Crear"}
        </button>
      </form>

      <h2 className="text-xl font-bold mb-2">Listado de Libros</h2>
      <table className="w-full border">
      <thead>
      <tr className="bg-gray-200">
        <th className="p-2 border">Título</th>
        <th className="p-2 border">Autor</th>
        <th className="p-2 border">Género</th>
        <th className="p-2 border">Disponible</th> {/* 👈 Agregado */}
      <th className="p-2 border">Acciones</th>
      </tr>
</thead>

<tbody>
  {libros.map((libro) => (
    <tr key={libro.id}>
      <td className="border p-2">{libro.titulo}</td>
      <td className="border p-2">{libro.autor}</td>
      <td className="border p-2">{libro.genero}</td>
      <td className="border p-2">
        {libro.disponible === 1 ? 'Sí' : 'No'}
      </td> {/* 👈 Agregado */}
      <td className="border p-2">
        <button onClick={() => editarLibro(libro)} className="bg-yellow-400 text-white px-2 py-1 mr-2">Editar</button>
        <button onClick={() => eliminarLibro(libro.id)} className="bg-red-500 text-white px-2 py-1">Eliminar</button>
      </td>
    </tr>
  ))}
</tbody>

      </table>
    </div>
  );
};

export default Libros;
