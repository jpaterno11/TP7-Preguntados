public static class Juego
{
    private static string username {get; set;}
    private static int puntajeActual {get; set;}
    private static int contadorPreguntaActual {get; set;}
    private static int cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> ListaPreguntas {get; set;}
    private static List<Respuestas> ListaRespuestas {get; set;}

    public static void InicializarJuego()
    {  
        username = null;
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
    }
    public static list ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }
}
