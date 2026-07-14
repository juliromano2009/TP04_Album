using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Album.Models;

namespace Album.Controllers;

public class AlbumController : Controller
{
    BD bd = new BD();

    public IActionResult Index()
    {
        return View();
    } 
    public IActionResult AbrirSobre()
    {
        ViewBag.Sobre = bd.AbrirSobre();
        return View();
    }  

    public IActionResult ConfirmarSobre( int f1 , int f2 , int f3 , int f4 , int f5)
    {
        List<int> sobre = new List <int>();
        sobre.Add(f1);
        sobre.Add(f2); 
        sobre.Add(f3);
        sobre.Add(f4);
        sobre.Add(f5);
        bd.ConfirmarSobre(sobre);
        return RedirectToAction("VerAlbum");
    }
    public IActionResult VerAlbum()
    {
        ViewBag.FigusUsuario = bd.ListaFiguritasPorUsuario();
        ViewBag.TodasLasFigus = bd.ListaFiguritas();
        ViewBag.NombreSelecciones = bd.pedirNombreSeleccion();
        return View("Album");
    }
}