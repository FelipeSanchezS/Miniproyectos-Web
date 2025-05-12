using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaApp
{
    internal class EspecialidadAux
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre; // Esto es lo que se mostrará en el ComboBox
        }
        

    }
}
