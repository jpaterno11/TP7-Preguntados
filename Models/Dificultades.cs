public class Dificultades
{
    public int IdDificultad { get; set; }
    public string Nombre { get; set; }

    public Dificultades() { }

    public Dificultades(int iddif, string nombre)
    {
        IdDificultad = iddif;
        Nombre = nombre;
    }
}