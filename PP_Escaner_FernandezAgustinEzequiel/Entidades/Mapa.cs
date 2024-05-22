using System.Text;

namespace PP_Escaner_ApellidoNombre.Entidades
{
    public class Mapa : Documento
    {
        private string editorial;
        private int añoPublicacion;
        private string codigoBarras;
        private double ancho;
        private double alto;

        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int Superficie => Alto * Ancho;

        public Mapa(string titulo, string autor, int año, string barcode, double alto, double ancho)
            : base(titulo, autor, año, barcode)
        {
            double Alto = alto;
           double  Ancho = ancho;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Superficie: {Alto} * {Ancho} = {Superficie} cm2");
            return sb.ToString();
        }

        public static bool operator ==(Mapa mapa1, Mapa mapa2)
        {
            if (ReferenceEquals(mapa1, mapa2)) return true;
            if (ReferenceEquals(mapa1, null) || ReferenceEquals(mapa2, null)) return false;

            return mapa1.Barcode == mapa2.Barcode ||
                   (mapa1.Titulo == mapa2.Titulo &&
                    mapa1.Autor == mapa2.Autor &&
                    mapa1.Año == mapa2.Año &&
                    mapa1.Superficie == mapa2.Superficie);
        }

        public static bool operator !=(Mapa mapa1, Mapa mapa2)
        {
            return !(mapa1 == mapa2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Mapa mapa)
                return this == mapa;
            return false;
        }

        public override int GetHashCode()
        {
            return (Barcode, Titulo, Autor, Año, Superficie).GetHashCode();
        }
    }
}
