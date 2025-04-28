namespace App\Http\Controllers;

use App\Models\Libro;
use Illuminate\Http\Request;

class LibroController extends Controller
{
    public function index()
    {
        return Libro::all();
    }

    public function store(Request $request)
    {
        $request->validate([
            'titulo' => 'required',
            'autor' => 'required',
            'genero' => 'required',
        ]);
        return Libro::create($request->all());
    }

    public function update(Request $request, Libro $libro)
    {
        $request->validate([
            'titulo' => 'required',
            'autor' => 'required',
            'genero' => 'required',
        ]);
        $libro->update($request->all());
        return $libro;
    }

    public function destroy(Libro $libro)
    {
        $libro->delete();
        return response()->noContent();
    }
}
