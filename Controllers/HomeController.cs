using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        ViewBag.categorias = BD.ObtenerCategorias();
        ViewBag.dificultades = BD.ObtenerDificultades();
        Juego.InicializarJuego();
        return View();
    }
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        if (!Juego.HayPreguntasCargadas())
        {
            return RedirectToAction("ConfigurarJuego");
        }
        return RedirectToAction("Jugar");
    }
    public IActionResult Jugar()
    {
        ViewBag.Username = Juego._username;
        ViewBag.PuntajeActual = Juego._puntajeActual;
        ViewBag.ContadorPreguntaActual = Juego._contadorPreguntaActual;
        Preguntas pregunta = Juego.ObtenerProximaPregunta();
          if (pregunta != null)
        {
            ViewBag.pregunta = pregunta;
            ViewBag.respuesta = new List<Respuestas>();
            foreach (Respuestas respuesta in Juego._respuestas)
            {
                if (respuesta.IdPregunta == ViewBag.pregunta.IdPregunta)
                {
                    ((List<Respuestas>)ViewBag.respuesta).Add(respuesta); //medio raro esto pero no encontre otra forma de agregar a un viewbag tipo lista
                }
            }
            return View("Juego");
        }
        return View("Fin");
    }
    [HttpPost]
    public IActionResult VerificarRespuesta(int IdPregunta, int idRespuesta)
    {
        ViewBag.correcto = Juego.VerificarRespuesta(IdPregunta, idRespuesta);
        if (ViewBag.correcto)
        {
            ViewBag.respuestaCorrecta = Juego._respuestas.Find(respuesta => respuesta.IdPregunta == IdPregunta && respuesta.Correcta); 
        }
        return RedirectToAction("Jugar");
    }
}
