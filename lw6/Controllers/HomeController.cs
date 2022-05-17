using System.Diagnostics;
using lw6.Models;
using Microsoft.AspNetCore.Mvc;

namespace lw6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private GameContext db;
    

    public HomeController(ILogger<HomeController> logger, GameContext context)
    {
        _logger = logger;
        db = context;
    }

    public IActionResult Index()
    {
        return View("Index",db.Games.ToList());
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.GameId = id;
        return View("Edit", db.Games.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(Game game)
    {
        var model = db.Games.SingleOrDefault(g => g.Id == game.Id);
        if (model is not null)
        {
            model.Id = game.Id;
            model.Title = game.Title;
            model.Developer = game.Developer;
            model.Genre = game.Genre;
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.GameId = id;
        return View("Delete", db.Games.Find(id));
    }
    
    [HttpPost]
    public IActionResult Delete(Game game)
    {
        db.Games.Remove(game);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult DeleteDecline(Game game)
    {
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }
    
    
    [HttpPost]
    public IActionResult Create(Game game)
    {
        db.Games.Add(game);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}