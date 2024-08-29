public class Catergoria
{
    public int IdCatergoria { get; set; }
    public string Nombre { get; set; }
    public string Foto { get; set; }

    public Catergoria() { }

    public Catergoria(int IdCatergoria, string nombre, string foto)
    {
        IdCatergoria = IdCatergoria;
        Nombre = nombre;
        Foto = foto;
    }
}