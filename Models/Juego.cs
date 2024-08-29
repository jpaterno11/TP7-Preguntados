public static class Juego
{
    private static string Username {get; set;}
    private static int puntajeActual {get; set;}
    private static int contadorPreguntaActual {get; set;}
    private static int cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> _preguntas {get; set;}
    private static List<Respuestas> _respuestas {get; set;}

    public static void InicializarJuego()
    {  
        Username = null;
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
    }
    public static list ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }
    public static list ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        Username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = new List<Respuesta>();

        foreach (Pregunta pregunta in _preguntas)
        {
            Respuesta respuestasPregunta = BD.ObtenerRespuestas(pregunta.IdPregunta); 
            _respuestas.Add(respuestasPregunta);
        }
    }
    public static Pregunta ObtenerProximaPregunta()
    {
        if (_preguntas != null && _preguntas.Count > 0)
        {
            Random rnd = new Random();
            int random = rnd.Next(_preguntas.Count);
            return _preguntas[random];
        }
        return null;
    }
}
