<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use App\Models\Prestamo;
use App\Models\Libro;
use Illuminate\Http\Request;

class PrestamoController extends Controller
{
    public function index()
    {
        return Prestamo::with('libro')->get();
    }

    // public function store(Request $request)
    // {
    //     $request->validate([
    //         'libro_id' => 'required|exists:libros,id',
    //         'usuario' => 'required|string',
    //         'fecha_prestamo' => 'required|date',
    //         'fecha_devolucion' => 'required|date|after_or_equal:fecha_prestamo',
    //     ]);

    //     // Marcar el libro como no disponible
    //     $libro = Libro::find($request->libro_id);
    //     if (!$libro->disponible) {
    //         return response()->json(['error' => 'Libro no disponible'], 400);
    //     }

    //     $libro->disponible = false;
    //     $libro->save();

    //     return Prestamo::create($request->all());
    // }
    

    // public function devolver($id)
    // {
    //     $prestamo = Prestamo::findOrFail($id);
    //     $prestamo->devuelto = true;
    //     $prestamo->save();

    //     $libro = $prestamo->libro;
    //     $libro->disponible = true;
    //     $libro->save();

    //     return response()->json(['mensaje' => 'Libro devuelto correctamente.']);
    // }
    // public function devolver($id)
    // {
    //     return response()->json(['mensaje' => "Libro $id devuelto con nombre $nombre"]);
    // }
    // public function devolver($id)
    // {
    //     // Intentar obtener el préstamo
    //     $prestamo = Prestamo::find($id);
    //     if (!$prestamo) {
    //         return response()->json(['error' => 'Préstamo no encontrado'], 404);
    //     }

    //     // Marcar el préstamo como devuelto
    //     $prestamo->devuelto = true;
    //     $prestamo->save();

    //     // Obtener el libro relacionado
    //     $libro = $prestamo->libro;
    //     if ($libro) {
    //         $libro->disponible = true;
    //         $libro->save();
    //     }

    //     return response()->json(['mensaje' => "Libro $id devuelto correctamente."]);
    // }
    public function devolver($id)
    {
        $prestamo = Prestamo::find($id);
        if (!$prestamo) {
            return response()->json(['error' => 'Préstamo no encontrado'], 404);
        }

        $libro = $prestamo->libro;

        if (!$libro) {
            return response()->json(['error' => 'Libro relacionado no encontrado'], 404);
        }

        // Marcar como devuelto
        $prestamo->devuelto = true;
        $prestamo->save();

        // Marcar libro como disponible
        $libro->disponible = true;
        $libro->save();

        return response()->json(['mensaje' => 'Libro devuelto correctamente.']);
    }



}
