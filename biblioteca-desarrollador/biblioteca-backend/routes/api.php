<?php

use App\Http\Controllers\Api\PrestamoController;
use App\Http\Controllers\Api\EstadisticasController;
use App\Http\Controllers\LibroController;

Route::apiResource('libros', LibroController::class);
Route::prefix('estadisticas')->group(function () {
    Route::get('/libros-mas-prestados', [EstadisticasController::class, 'topLibros']);
    Route::get('/prestamos-activos', [EstadisticasController::class, 'prestamosActivos']);
    Route::get('/usuarios-top', [EstadisticasController::class, 'topUsuarios']);
});

Route::get('/prestamos', [PrestamoController::class, 'index']);
Route::post('/prestamos', [PrestamoController::class, 'store']);
Route::put('/prestamos/devolver/{id}', [PrestamoController::class, 'devolver']);
Route::delete('/prestamos/{id}', [PrestamoController::class, 'destroy']);


