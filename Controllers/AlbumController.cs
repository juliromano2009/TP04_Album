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

    public IActionResult ConfirmarSobre(Figuritas f1 , Figuritas f2 , Figuritas f3 , Figuritas f4 , Figuritas f5)
    {
        List<Figuritas> sobre = new List <Figuritas>();
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