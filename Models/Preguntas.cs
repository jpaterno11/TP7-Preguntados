public class Preguntas
{
    public int IdPregunta { get; set; }
    public int IdDificultad { get; set; }
    public int IdCategoria { get; set; }
    public string Enunciado { get; set; }
    public string Foto { get; set; }

    public Preguntas() { }

    public Preguntas(int idpreg, int iddif, int idcat, string enunciado, string foto)
    {
        IdPregunta = idpreg;
        IdDificultad = iddif;
        IdCategoria = idcat;
        Enunciado = enunciado;
        Foto = foto;

    }
}