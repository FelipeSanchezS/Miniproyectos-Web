<?php

namespace App\Http\Controllers\Api;

use App\Models\Libro;
use App\Models\User;
use App\Models\Prestamo;
use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\DB;

class EstadisticasController extends Controller
{
    // Libros más prestados (top 5)
    public function topLibros()
    {
        return Prestamo::select('libro_id', DB::raw('count(*) as total'))
            ->groupBy('libro_id')
            ->orderByDesc('total')
            ->with('libro')
            ->limit(5)
            ->get();
    }

    // Cantidad de préstamos activos
    public function prestamosActivos()
    {
        $activos = Prestamo::whereNull('fecha_devolucion')->count();
        return response()->json(['prestamos_activos' => $activos]);
    }

    // Usuarios con más préstamos (top 5)
    public function topUsuarios()
    {
        return Prestamo::select('user_id', DB::raw('count(*) as total'))
            ->groupBy('user_id')
            ->orderByDesc('total')
            ->with('usuario')
            ->limit(5)
            ->get();
    }
}

