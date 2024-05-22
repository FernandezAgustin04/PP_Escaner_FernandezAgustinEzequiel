using System;
using PP_Escaner_ApellidoNombre.Entidades;

namespace PP_Escaner_ApellidoNombre.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var escanerLibros = new Escaner("libro");
            var escanerMapas = new Escaner("mapa");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("¿Qué desea ingresar? (libro/mapa/salir)");
                string opcion = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese 'libro', 'mapa' o 'salir'.");
                    continue;
                }

                switch (opcion)
                {
                    case "libro":
                        IngresarLibro(escanerLibros);
                        break;
                    case "mapa":
                        IngresarMapa(escanerMapas);
                        break;
                    case "salir":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese 'libro', 'mapa' o 'salir'.");
                        break;
                }
            }

            // Generación de informes después de la entrada de datos
            Console.WriteLine("Informes de Libros:");
            Console.WriteLine($"Extensión en Estado 'Distribuido': {Informes.ObtenerExtension(escanerLibros, EstadoDocumento.Distribuido)}");
            Console.WriteLine($"Cantidad en Estado 'Distribuido': {Informes.ObtenerCantidad(escanerLibros, EstadoDocumento.Distribuido)}");

            var resumenLibros = Informes.ObtenerResumen(escanerLibros, EstadoDocumento.Distribuido);
            foreach (var doc in resumenLibros)
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("Informes de Mapas:");
            Console.WriteLine($"Extensión en Estado 'Distribuido': {Informes.ObtenerExtension(escanerMapas, EstadoDocumento.Distribuido)}");
            Console.WriteLine($"Cantidad en Estado 'Distribuido': {Informes.ObtenerCantidad(escanerMapas, EstadoDocumento.Distribuido)}");

            var resumenMapas = Informes.ObtenerResumen(escanerMapas, EstadoDocumento.Distribuido);
            foreach (var doc in resumenMapas)
            {
                Console.WriteLine(doc.ToString());
            }
        }

        static void IngresarLibro(Escaner escaner)
        {
            Console.WriteLine("Ingrese los datos del libro:");
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? string.Empty;
            Console.Write("Autor: ");
            string autor = Console.ReadLine() ?? string.Empty;
            Console.Write("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out int añoPublicacion))
            {
                Console.WriteLine("Año de publicación no válido.");
                return;
            }
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? string.Empty;
            Console.Write("Número de páginas: ");
            if (!int.TryParse(Console.ReadLine(), out int numPaginas))
            {
                Console.WriteLine("Número de páginas no válido.");
                return;
            }

            var libro = new Libro(titulo, autor, añoPublicacion, isbn, "1114", numPaginas);
            escaner += libro;

            Console.WriteLine("Libro ingresado correctamente.");
        }

        static void IngresarMapa(Escaner escaner)
        {
            Console.WriteLine("Ingrese los datos del mapa:");
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? string.Empty;
            Console.Write("Editorial: ");
            string editorial = Console.ReadLine() ?? string.Empty;
            Console.Write("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out int añoPublicacion))
            {
                Console.WriteLine("Año de publicación no válido.");
                return;
            }
            Console.Write("Código de barras: ");
            string codigoBarras = Console.ReadLine() ?? string.Empty;
            Console.Write("Ancho (en cm): ");
            if (!double.TryParse(Console.ReadLine(), out double ancho))
            {
                Console.WriteLine("Ancho no válido.");
                return;
            }
            Console.Write("Alto (en cm): ");
            if (!double.TryParse(Console.ReadLine(), out double alto))
            {
                Console.WriteLine("Alto no válido.");
                return;
            }

            var mapa = new Mapa(titulo, editorial, añoPublicacion, codigoBarras, ancho, alto);
            escaner += mapa;

            Console.WriteLine("Mapa ingresado correctamente.");
        }
    }
}
