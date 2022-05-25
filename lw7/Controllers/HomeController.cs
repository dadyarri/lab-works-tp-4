using System.Diagnostics;
using lw7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lw7.Controllers;

public class HomeController : Controller
{
    private readonly GameContext _db;


    public HomeController(GameContext context)
    {
        _db = context;
    }

    public IActionResult Index()
    {
        return View("Index", _db.Games?.ToList());
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(int? id)
    {
        if (id == null) return RedirectToAction("Index");
        ViewBag.GameId = id;
        return View("Edit", _db.Games?.Find(id));
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
        return View("Create");
    }


    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Create(Game game)
    {
        _db.Games?.Add(game);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}