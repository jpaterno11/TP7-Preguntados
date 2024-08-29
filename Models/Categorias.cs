public class Categoria
{
    public int IdCatergoria { get; set; }
    public string Nombre { get; set; }
    public string Foto { get; set; }

    public Categoria() { }

    public Categoria(int IdCatergoria, string nombre, string foto)
    {
        IdCatergoria = IdCatergoria;
        Nombre = nombre;
        Foto = foto;
    }
}