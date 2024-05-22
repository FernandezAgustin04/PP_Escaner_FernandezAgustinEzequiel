using System;
using System.Collections.Generic;
using System.Linq;

namespace PP_Escaner_ApellidoNombre.Entidades
{
    public static class Informes
    {

        public static int ObtenerExtension(Escaner escaner, EstadoDocumento estado)
        {
            return escaner.Documentos
                .Where(doc => doc.Estado == estado)
                .Sum(doc => doc is Libro libro ? libro.NumeroPaginas : (doc as Mapa)?.Superficie ?? 0);
        }

        public static int ObtenerCantidad(Escaner escaner, EstadoDocumento estado)
        {
            return escaner.Documentos.Count(doc => doc.Estado == estado);
        }

        public static List<Documento> ObtenerResumen(Escaner escaner, EstadoDocumento estado)
        {
            return escaner.Documentos.Where(doc => doc.Estado == estado).ToList();
        }
    }
}
