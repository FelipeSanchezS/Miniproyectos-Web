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

    public function store(Request $request)
    {
        $request->validate([
            'libro_id' => 'required|exists:libros,id',
            'usuario' => 'required|string',
            'fecha_prestamo' => 'required|date',
            'fecha_devolucion' => 'required|date|after_or_equal:fecha_prestamo',
        ]);

        // Marcar el libro como no disponible
        $libro = Libro::find($request->libro_id);
        if (!$libro->disponible) {
            return response()->json(['error' => 'Libro no disponible'], 400);
        }

        $libro->disponible = false;
        $libro->save();

        return Prestamo::create($request->all());
    }

    public function devolver(Prestamo $prestamo)
    {
        $prestamo->devuelto = true;
        $prestamo->save();

        // Marcar el libro como disponible
        $libro = $prestamo->libro;
        $libro->disponible = true;
        $libro->save();

        return response()->json(['mensaje' => 'Libro devuelto']);
    }
}
