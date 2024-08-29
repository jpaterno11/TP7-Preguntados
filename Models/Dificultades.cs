public class Dificultades
{
    public int IdDificultades { get; set; }
    public string Nombre { get; set; }

    public Dificultades() { }

    public Dificultades(int IdDificultades, string nombre)
    {
        IdDificultades = IdDificultades;
        Nombre = nombre;
    }
}