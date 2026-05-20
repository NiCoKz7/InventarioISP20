using Consola.Class;
using System.Numerics;
using System.Runtime.Intrinsics;

public class Program
{
    static string[] meses;
    static string[,] nosotros;
    private static void Main(string[] args)
    {
        CreamosVariables();

        CreamosMatricesYVectores();

        Console.WriteLine("probando escribir algo en la pantalla");

        ImpresionDeMatrices(meses, nosotros);

        ImpresionDeParametros(args);

        //CapturaDeValoresDelUsuario();

        CreamosAlumnosEImprimimosSuFichaDeDatos();

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