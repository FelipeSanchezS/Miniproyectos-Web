<?php

use App\Http\Controllers\Api\PrestamoController;

Route::get('/prestamos', [PrestamoController::class, 'index']);
Route::post('/prestamos', [PrestamoController::class, 'store']);
Route::put('/prestamos/devolver/{id}', [PrestamoController::class, 'devolver']);
Route::delete('/prestamos/{id}', [PrestamoController::class, 'destroy']);


