public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }
    public string Foto { get; set; }

    public Categoria() { }

    public Categoria(int idcat, string nombre, string foto)
    {
        IdCategoria = idcat;
        Nombre = nombre;
        Foto = foto;
    }
}