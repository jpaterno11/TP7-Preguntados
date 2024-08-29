public class Preguntas
{
    public int IdPreguntas { get; set; }
    public int IdDificultades { get; set; }
    public int IdCatergoria { get; set; }
    public string Enunciado { get; set; }
    public string Foto { get; set; }

    public Preguntas() { }

    public Preguntas(int idPreguntas, int idDificultades, int idCatergoria, string enunciado, string foto)
    {
        IdPreguntas = idPreguntas;
        IdDificultades = idDificultades;
        IdCatergoria = idCatergoria;
        Enunciado = enunciado;
        Foto = foto;

    }
}