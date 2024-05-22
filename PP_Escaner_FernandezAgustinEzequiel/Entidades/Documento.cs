using System.Text;



namespace PP_Escaner_ApellidoNombre.Entidades
{
    public abstract class Documento
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public string Barcode { get; set; }
        protected string NumNormalizado { get; set; }
        public EstadoDocumento Estado { get; private set; } = EstadoDocumento.Inicio;

        public Documento(string titulo, string autor, int año, string barcode)
        {
            Titulo = titulo;
            Autor = autor;
            Año = año;
            Barcode = barcode;
        }

        public bool AvanzarEstado()
        {
            if (Estado == EstadoDocumento.Terminado)
                return false;

            Estado++;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Año}");
            sb.AppendLine($"Cod. de barras: {Barcode}");
            return sb.ToString();
        }
    }

    public enum EstadoDocumento
    {
        Inicio,
        Distribuido,
        EnEscaner,
        EnRevision,
        Terminado
    }
}
