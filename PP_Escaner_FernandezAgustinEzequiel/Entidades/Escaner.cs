using System;
using System.Collections.Generic;
using System.Linq;

namespace PP_Escaner_ApellidoNombre.Entidades
{
    public class Escaner
    {
        public string Locacion { get; }
        public List<Documento> Documentos { get; }

        public Escaner(string tipoDocumento)
        {
            Documentos = new List<Documento>();
            Locacion = tipoDocumento.ToLower() == "mapa" ? "mapoteca" : "procesosTecnicos";
        }

        public static bool operator ==(Escaner escaner, Documento documento)
        {
            return escaner.Documentos.Any(doc => doc.Equals(documento));
        }

        public static bool operator !=(Escaner escaner, Documento documento)
        {
            return !(escaner == documento);
        }

        public static Escaner operator +(Escaner escaner, Documento documento)
        {
            if (escaner != documento && documento.Estado == EstadoDocumento.Inicio)
            {
                documento.AvanzarEstado();
                escaner.Documentos.Add(documento);
            }
            return escaner;
        }

        public bool CambiarEstadoDocumento(Documento documento)
        {
            foreach (var doc in Documentos)
            {
                if (doc.Equals(documento))
                {
                    return doc.AvanzarEstado();
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Escaner escaner &&
                   EqualityComparer<List<Documento>>.Default.Equals(Documentos, escaner.Documentos) &&
                   Locacion == escaner.Locacion;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (Documentos != null ? Documentos.GetHashCode() : 0);
            hash = hash * 23 + (Locacion != null ? Locacion.GetHashCode() : 0);
            return hash;
        }
    }
}
