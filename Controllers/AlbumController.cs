using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Album.Models;

namespace Album.Controllers;

public class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    } 
    public IActionResult AbrirSobre()
    {
        return View();
    }  
    public IActionResult VerAlbum()
    {
        return View();
    }
}