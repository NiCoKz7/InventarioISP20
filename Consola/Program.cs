using Consola.Class;
using System.Numerics;
using System.Runtime.Intrinsics;

public class Program
{
    static string[] meses;
    static string[,] nosotros;
    private static void Main(string[] args)
    {
        //CreamosVariables();

        //CreamosMatricesYVectores();

        //Console.WriteLine("probando escribir algo en la pantalla");

        //ImpresionDeMatrices(meses, nosotros);

        //ImpresionDeParametros(args);

        //CapturaDeValoresDelUsuario();

        //CreamosAlumnosEImprimimosSuFichaDeDatos();

        //CreamosEstudiantesEImprimimosSuSaludo();

        //ProbamosMetodosConDiferentesValoresDeRetorno();

        //Ejercicio1();

        //Ejercicio2();

        Ejercicio3();

    }

    private static void Ejercicio3()
    {
        //object prueba2 = new object();
        //prueba2.ToString();
        Object prueba = new Object();
        Persona[] grupo = new Persona[2];
        Persona persona1 = new();
        grupo[0] = persona1;
        Estudiante estudiante1 = new();
        estudiante1.Nombre = "bauti inso";
        grupo[1] = estudiante1;
        //estudiante1.ToString();
        foreach (Persona persona in grupo)
        {
            persona.Hablar();
        }
        Console.WriteLine(Environment.NewLine+"probando:\n ");
        prueba.ToString();
        DateTime ahora = new DateTime();
        ahora = DateTime.Now;
        Console.WriteLine(prueba.ToString());
        Console.WriteLine(estudiante1.ToString());
        Console.WriteLine(ahora);
        
    }

    private static void Ejercicio2()
    {
        Bicicleta bici = new();
        bici.velocidad = 15;
        bici.tienecampanilla = false;
        //if (bici.tienecampanilla)
        //{
        //    Console.WriteLine($"la bici va a una velocidad de {bici.velocidad} km/h y tiene campanilla");
        //}
        //else
        //{
        //    Console.WriteLine($"la bici va a una velocidad de {bici.velocidad} km/h y no tiene campanilla");

        //}
        Console.WriteLine($"la bicicleta va a una velocidad de {bici.velocidad} y {(!bici.tienecampanilla?"no ":"")}tiene campanilla");
    }

    private static void Ejercicio1()
    {
        Persona persona1 = new();
        persona1.Nombre = "Bauti G";
        //persona1.Edad = 50;
        Console.WriteLine($"El nombre es {persona1.Nombre}" /* y su edad es: {persona1.Edad}"*/);
        persona1.cumpliranios();
    }

    private static void ProbamosMetodosConDiferentesValoresDeRetorno()
    {
        AlumnoCurso alumno1 = new AlumnoCurso("Negro", "Tecla", 29);

        alumno1.AgregarNota(8);
        alumno1.AgregarNota(7.5);
        alumno1.AgregarNota(9);
        alumno1.AgregarNota(5.5);
        alumno1.AgregarNota(3);
        alumno1.AgregarNota(2);

        string nombreCompleto = alumno1.ObtenerNombreCompleto();
        int cantidadNotas = alumno1.ObtenerCantidadDeNotas();
        double promedio = alumno1.CalcularPromedio();
        bool aprobado = alumno1.EstaAprobado();
        char inicial = alumno1.ObtenerInicial();
        DateTime fechaConsulta = alumno1.ObtenerFechaConsulta();
        List<double> notas = alumno1.ObtenerNotas();
        int cantidadmateriasdesaprobadas = alumno1.CantMateriasDesaprobadas();
        bool pasadeaño = alumno1.PasoDeAño(cantidadmateriasdesaprobadas);

        Console.WriteLine("Nombre completo: " + nombreCompleto);
        Console.WriteLine("Cantidad de notas: " + cantidadNotas);
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("¿Está aprobado?: " + aprobado);
        Console.WriteLine("Inicial: " + inicial);
        Console.WriteLine("Fecha de consulta: " + fechaConsulta);
        Console.WriteLine("Materias desaprobadas: " + cantidadmateriasdesaprobadas);
        Console.WriteLine("Paso de año: " + pasadeaño);
    }

    private static void CreamosEstudiantesEImprimimosSuSaludo()
    {
        Estudiante estudiante1 = new Estudiante();
        estudiante1.Nombre = "Nico";
        estudiante1.Edad = 24;
        estudiante1.Domicilio = "Calle falopa rica 123";
        //estudiante1.Saludar();
        Console.WriteLine(estudiante1.DatosCompletos);
    }

    private static void CreamosAlumnosEImprimimosSuFichaDeDatos()
    {
        Alumno alumno1 = new Alumno("Autista", "Gomez", 12345678, new DateOnly(1956, 3, 9));
        Console.WriteLine(alumno1.ImpresionFichaDatos());

        Alumno alumno2 = new Alumno("Sachet", "Vera", 87654321, new DateOnly(2000, 5, 15));
        Console.WriteLine(alumno2.ImpresionFichaDatos());

        Alumno alumno3 = new Alumno("Moana", "Vera", 11223344, new DateOnly(1995, 8, 20));
        Console.WriteLine(alumno3.ImpresionFichaDatos());

        Console.WriteLine(Alumno.ImpresionCantidadInstancias());
    }

    private static void ImpresionDeMatrices(string[] meses, string[,] nosotros)
    {
        Console.WriteLine("imprimiendo el vector meses");
        for (int i = 0; i < meses.Length; i++)
        {
            Console.Write(meses[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("imprimiendo la matriz nosotros");
        Console.WriteLine();
        for (int i = 0; i < nosotros.GetLength(0); i++)
        {
            for (int j = 0; j < nosotros.GetLength(1); j++)
            {
                Console.Write(nosotros[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void CreamosMatricesYVectores()
    {
        //creando un vector de tipo string con 12 elementos
        meses = new string[12] { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
        meses[0] = "Enero";
        //creando una matriz de tipo string con 3 filas y 2 columnas
        nosotros = new string[3,2] { { "menzo", "cabron" }, { "sachet", "vera" }, { "moana 'fit'", "vera" } };
        nosotros[2, 0] = "moana";
        int[] edades = new int[3] {20, 21, 22};
    }

    private static void CapturaDeValoresDelUsuario()
    {
        Console.Write("ingresa tu nombre: ");
        string? nombre = Console.ReadLine();
        Console.WriteLine("hola " + nombre);
        Console.Write("ingrese su año de nacimiento: ");
        string? anio_nacimiento = Console.ReadLine();
        int anio = Convert.ToInt32(anio_nacimiento);
        Console.WriteLine($"tu fecha de nacimiento es {anio}");
        int edad = DateTime.Now.Year - anio;
        Console.WriteLine($"tu edad es {edad} aproximadamente");
    }

    private static void ImpresionDeParametros(string[] args)
    {
        Console.WriteLine("probando escribir algo en la pantalla");
        //Console.WriteLine("el valor de sumar {0} y {1} es {2}", numero, numero2, numero3);
        if (args.Length > 1)
        {
            Console.WriteLine($"Hola {args[0]} y {args[1]} son unos capos");
        }
        else
        {
            Console.WriteLine("no se ingresaron suficientes argumentos");
        }
    }

    private static void CreamosVariables()
    {
        //Console.WriteLine("Hello, World!");
        //Creamos una variable int y le asignamos un valor
        int numero = 10;
        //declaracion
        int numero2;
        //asignacion
        numero2 = 20;
        int numero3 = 30;
    }
}