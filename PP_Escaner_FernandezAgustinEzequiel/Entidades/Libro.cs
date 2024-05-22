using System.Text;

namespace PP_Escaner_ApellidoNombre.Entidades
{
    public class Libro : Documento
    {
        public string ISBN
        {
            get => NumNormalizado;
            private set => NumNormalizado = value;
        }

        public int NumeroPaginas { get; set; }

        public Libro(string titulo, string autor, int año, string barcode, string isbn, int numeroPaginas)
            : base(titulo, autor, año, barcode)
        {
            ISBN = isbn;
            NumeroPaginas = numeroPaginas;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Número de páginas: {NumeroPaginas}");
            return sb.ToString();
        }

        public static bool operator ==(Libro libro1, Libro libro2)
        {
            if (ReferenceEquals(libro1, libro2)) return true;
            if (ReferenceEquals(libro1, null) || ReferenceEquals(libro2, null)) return false;

            return libro1.Barcode == libro2.Barcode ||
                   libro1.ISBN == libro2.ISBN ||
                   (libro1.Titulo == libro2.Titulo && libro1.Autor == libro2.Autor);
        }

        public static bool operator !=(Libro libro1, Libro libro2)
        {
            return !(libro1 == libro2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Libro libro)
                return this == libro;
            return false;
        }

        public override int GetHashCode()
        {
            return (Barcode, ISBN, Titulo, Autor).GetHashCode();
        }
    }
}
