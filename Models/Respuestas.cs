public class Respuestas
{
    public int IdRespuestas { get; set; }
    public int IdPregunta { get; set; }
    public string Opcion { get; set; }
    public string Contenido { get; set; }
    public bool Correcta {get; set;}
    public string Foto { get; set; }

    public Respuestas() { }

    public Respuestas(int idRespuestas, int idPregunta, string opcion, string contenido, bool correcta, string foto)
    {
        IdRespuestas = idRespuestas;
        IdPregunta = idPregunta;
        Opcion = opcion;
        Contenido = contenido;
        Correcta = correcta;
        Foto = foto;

    }
}