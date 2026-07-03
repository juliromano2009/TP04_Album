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

    public IActionResult ConfirmarSobre()
    {
        bd.ConfimarSobre();
        return RedirectToAction("VerAlbum");
    }
    public IActionResult VerAlbum()
    {
        ViewBag.NombreSelecciones = bd.pedirNombreSeleccion();
        ViewBag.Figuritas = bd.ListaFiguritasPorUsuario();
        return View("Album");
    }
}