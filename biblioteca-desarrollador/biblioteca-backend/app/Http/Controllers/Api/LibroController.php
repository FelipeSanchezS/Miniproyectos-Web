<?php

namespace App\Http\Controllers\Api;

use App\Models\Libro;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class LibroController extends Controller
{
    public function index()
    {
        return Libro::all();
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'titulo' => 'required|string',
            'autor' => 'required|string',
            'genero' => 'required|string',
        ]);

        return Libro::create($validated);
    }

    public function show($id)
    {
        return Libro::findOrFail($id);
    }

    public function update(Request $request, $id)
    {
        $libro = Libro::findOrFail($id);
        $libro->update($request->only(['titulo', 'autor', 'genero', 'disponible']));

        return $libro;
    }

    public function destroy($id)
    {
        Libro::destroy($id);
        return response()->json(['message' => 'Libro eliminado']);
    }
}
