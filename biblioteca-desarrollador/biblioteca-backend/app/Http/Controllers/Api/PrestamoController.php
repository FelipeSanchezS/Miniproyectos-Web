<?php

namespace App\Http\Controllers\Api;

use App\Models\Prestamo;
use App\Models\Libro;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;

class PrestamoController extends Controller
{
    public function index()
    {
        return Prestamo::with(['libro', 'usuario'])->get();
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'user_id' => 'required|exists:users,id',
            'libro_id' => 'required|exists:libros,id',
            'fecha_prestamo' => 'required|date'
        ]);

        $libro = Libro::find($request->libro_id);

        if (!$libro->disponible) {
            return response()->json(['error' => 'El libro no está disponible'], 400);
        }

        // Marcar libro como no disponible
        $libro->update(['disponible' => false]);

        return Prestamo::create($validated);
    }

    public function devolver($id)
    {
        $prestamo = Prestamo::findOrFail($id);

        if ($prestamo->fecha_devolucion) {
            return response()->json(['error' => 'Este préstamo ya fue devuelto'], 400);
        }

        $prestamo->update(['fecha_devolucion' => now()]);

        // Marcar libro como disponible
        $prestamo->libro->update(['disponible' => true]);

        return response()->json(['message' => 'Libro devuelto con éxito']);
    }

    public function destroy($id)
    {
        $prestamo = Prestamo::findOrFail($id);
        $prestamo->delete();

        return response()->json(['message' => 'Préstamo eliminado']);
    }
}
