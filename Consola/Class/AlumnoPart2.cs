using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    partial class Alumno
    {
        public static string ImpresionCantidadInstancias()
        {
            return $"Cantidad de instancias creadas: {instanciasCreadas}";
        }
    }
}
