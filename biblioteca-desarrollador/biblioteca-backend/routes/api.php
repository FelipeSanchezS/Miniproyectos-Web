<?php

use App\Http\Controllers\Api\PrestamoController;
use App\Http\Controllers\Api\EstadisticasController;
use App\Http\Controllers\Api\LibroController;
use Illuminate\Support\Facades\Route;

Route::apiResource('libros', LibroController::class);

// Estadísticas
Route::prefix('estadisticas')->group(function () {
    Route::get('/libros-mas-prestados', [EstadisticasController::class, 'topLibros']);
    Route::get('/prestamos-activos', [EstadisticasController::class, 'prestamosActivos']);
    Route::get('/usuarios-top', [EstadisticasController::class, 'topUsuarios']);
});

// Prestamos CRUD parcial
Route::get('/prestamos', [PrestamoController::class, 'index']);
Route::post('/prestamos', [PrestamoController::class, 'store']);
Route::delete('/prestamos/{id}', [PrestamoController::class, 'destroy']);

// Acción personalizada: devolver un libro
Route::put('/prestamos/{id}/devolver', [PrestamoController::class, 'devolver']);
