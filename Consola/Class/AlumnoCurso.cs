using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class AlumnoCurso
    {
        // Campo privado
        private List<double> notas = new List<double>();

        // Propiedades públicas
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public int CantMatDes { get; set; }
        public int CantMatAprob { get; set; }
        public bool PasaDeAño { get; set; }

        // Método constructor
        public AlumnoCurso(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Activo = true;
        }

        // Método que no devuelve valor
        public void AgregarNota(double nota)
        {
            notas.Add(nota);
        }

        // Método que devuelve string
        public string ObtenerNombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        // Método que devuelve int
        public int ObtenerCantidadDeNotas()
        {
            return notas.Count;
        }

        // Método que devuelve double
        public double CalcularPromedio()
        {
            if (notas.Count == 0)
            {
                return 0;
            }

            double suma = 0;

            foreach (double nota in notas)
            {
                suma += nota;
            }

            return suma / notas.Count;
        }

        // Método que devuelve bool
        public bool EstaAprobado()
        {
            return CalcularPromedio() >= 6;
        }

        // Método que devuelve char
        public char ObtenerInicial()
        {
            return Nombre[0];
        }

        // Método que devuelve DateTime
        public DateTime ObtenerFechaConsulta()
        {
            return DateTime.Now;
        }

        // Método que devuelve List<double>
        public List<double> ObtenerNotas()
        {
            return notas;
        }

        //metodo que devuelve la cantidad de materias desaprobadas
        public int CantMateriasDesaprobadas()
        {
            int materiasdesaprobadas = 0;
            foreach (double nota in notas)
            {
                if (nota < 6)
                {
                    materiasdesaprobadas++;
                }
            }
            return materiasdesaprobadas;
        }

        //metodo que devuelve la cantidad de materias aprobadas
        public int CantMateriasAprobadas()
        {
            int materiasaprobadas = 0;
            foreach (double nota in notas)
            {
                if (nota >= 6)
                {
                    materiasaprobadas++;
                }
            }
            return materiasaprobadas;
        }

        //metodo que verifica si paso de año o no
        public bool PasoDeAño(int notas)
        {
            bool pasadeaño = false;
            if(notas<=2)
            {
                pasadeaño = true;
            }
            else if(notas>2) 
            {
                pasadeaño = false;
            }
            return pasadeaño;
        }
    }
}
