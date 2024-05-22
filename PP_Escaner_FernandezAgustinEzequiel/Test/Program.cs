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

            var libro1 = new Libro("Yerma", "Garcia Lorca, Federico", 1995, "22222", "1114", 27);
            var mapa1 = new Mapa("Ciudad Autónoma de Buenos Aires", "Instituto de Geografia", 2022, "8888", 30, 20);

            escanerLibros += libro1;
            escanerMapas += mapa1;

            escanerLibros.CambiarEstadoDocumento(libro1);
            escanerMapas.CambiarEstadoDocumento(mapa1);

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
    }
}
