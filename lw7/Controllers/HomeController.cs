using System.Diagnostics;
using lw7.Data;
using lw7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lw7.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationContext _db;


    public HomeController(ApplicationContext context)
    {
        _db = context;
    }

    public IActionResult Index()
    {
        DbSet<Game> games = _db.Games;
        DbSet<Developer> developers = _db.Developers;

        var query = games.Join(developers, game => game.Developer.Id, developer => developer.Id,
            (game, developer) => new
            {
                Id = game.Id,
                Title = game.Title,
                Developer = developer.Name,
                DeveloperId = developer.Id,
                Genre = game.Genre
            });

        return View("Index", query);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(int? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.Developers = _db.Developers.ToList();
        ViewBag.Game = _db.Games?.Find(id);
        return View("Edit");
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(Game game)
    {
        var model = _db.Games?.SingleOrDefault(g => g.Id == game.Id);
        if (model is not null)
        {
            model.Id = game.Id;
            model.Title = game.Title;
            model.Developer = game.Developer;
            model.Genre = game.Genre;
            _db.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(int? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.GameId = id;
        return View("Delete", _db.Games?.Find(id));
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(Game game)
    {
        _db.Games?.Remove(game);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult DeleteDecline(Game game)
    {
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Create()
    {
        ViewBag.Developers = _db.Developers.ToList();
        return View("Create");
    }


    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Create(GameInt game)
    {
        Developer dev = _db.Developers.Single(dev => dev.Id == game.Developer);
        Game created = new(game.Title, dev, game.Genre);
        _db.Games?.Add(created);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Developer(int id)
    {
        var games = _db.Games.ToList();
        var developers = _db.Developers.ToList();

        var query =
            from dev in developers
            join game in games on dev.Id equals game.Developer.Id into gamesGroup
            where dev.Id == id
            select new DeveloperGames(dev, gamesGroup);
        return View("Developer", query);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}