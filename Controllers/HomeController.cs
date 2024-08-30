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
        ViewBag.pregunta = Juego.ObtenerProximaPregunta();
        ViewBag.respuestas = Juego._respuestas;
        return View(); //incompleto
    }
}
