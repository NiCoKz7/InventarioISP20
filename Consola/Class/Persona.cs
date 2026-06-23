using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class Persona
    {
        public string? Nombre;
        private int Edad = 52;

        public void cumpliranios() {
            Edad++;
            Console.WriteLine($"la edad es {Edad}");
        }

        public virtual void Hablar()
        {
            Console.WriteLine($"Hola que tal");
        }
    }

}
