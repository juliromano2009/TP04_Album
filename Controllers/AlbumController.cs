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
}