public class Respuestas
{
    public int IdRespuesta { get; set; }
    public int IdPregunta { get; set; }
    public string Opcion { get; set; }
    public string Contenido { get; set; }
    public bool Correcta {get; set;}
    public string Foto { get; set; }

    public Respuestas() { }

    public Respuestas(int idres, int idpreg, string opcion, string contenido, bool correcta, string foto)
    {
        IdRespuesta = idres;
        IdPregunta = idpreg;
        Opcion = opcion;
        Contenido = contenido;
        Correcta = correcta;
        Foto = foto;

    }
}