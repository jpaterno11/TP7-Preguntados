public static class Juego
{
    private static string _username {get; set;}
    private static int _puntajeActual {get; set;}
    private static int _contadorPreguntaActual {get; set;}
    private static int _cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> _preguntas {get; set;}
    public static List<Respuestas> _respuestas {get; set;}

    public static void InicializarJuego()
    {  
        _username = null;
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }
    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = new List<Respuestas>();
        foreach (Preguntas pregunta in _preguntas)
        {
            _respuestas.Add(BD.ObtenerRespuestas(pregunta.IdPreguntas)); 
        }
    }
    public static bool HayPreguntasCargadas()
    {
        return _preguntas != null && _preguntas.Count > 0;
    }
    public static Preguntas ObtenerProximaPregunta()
    {
        if (_preguntas != null && _preguntas.Count > 0)
        {
            Random rnd = new Random();
            int random = rnd.Next(_preguntas.Count);
            return _preguntas[random];
        }
        return null;
    }
    
     public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        var respuestaCorrecta = _respuestas.Find(respuesta => respuesta.IdRespuestas == idRespuesta && respuesta.IdPregunta == idPregunta && respuesta.Correcta);

        if (respuestaCorrecta != null)
        {
            _puntajeActual += 10;
            _cantidadPreguntasCorrectas++;
            _preguntas.RemoveAll(pregunta => pregunta.IdPreguntas == idPregunta);
            return true;
        }

        return false;
    }
}
