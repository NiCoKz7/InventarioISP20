using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public partial class Alumno
    {
        static int instanciasCreadas = 0; //Variable de clase para contar las instancias creadas de la clase alumno
        string nombre;
        string apellido;
        int dni;
        DateOnly fecha_nacimiento;

        //constructor de la clase alumno que recibe los datos del alumno y los asigna a las variables de instancia
        public Alumno(string nombre, string apellido, int dni, DateOnly fecha_nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fecha_nacimiento = fecha_nacimiento;
            instanciasCreadas++;
        }

        public string ImpresionFichaDatos()
        {
            return $"Nombre: {nombre} Apellido: {apellido}\n DNI: {dni}\n Fecha de nacimiento: {fecha_nacimiento}";
        }

    }
}
