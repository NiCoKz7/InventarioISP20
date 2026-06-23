using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class Estudiante : Persona
    {
        //private string? nombre;

        //public string? Nombre
        //{
        //    get { return nombre?.ToUpper(); }
        //    set { nombre = value; }
        //}

        public override void Hablar()
        {
            Console.WriteLine($"Hola estoy harto");
        }

        public string Domicilio { get; set; } = string.Empty;
        public int Edad { get; set; }

        //creamos una propiedad llamada datosCompletos que concatena todos los datos del estudiante y los devuelve al llamarla
        public string DatosCompletos
        {
            get { return $"Nombre: {this.Nombre}, Domicilio: {this.Domicilio}, Edad: {this.Edad}"; }
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy el estudiante {this.Nombre} y tengo {this.Edad} años.");
            //si llamo a la propiedad(Nombre) aplica las mayusculas, si llamo al campo(nombre) no lo aplica
        }

        public override string ToString()
        {
            string retorno = "retorno original:" + base.ToString();
            string newretorno = "retorno nuevo: " + Nombre;
            return retorno + Environment.NewLine + newretorno;
        }
        

    }
}