using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practice2.Models;

namespace Practice2.Controllers;

public class MovieController : Controller
{
    public List<Movie> listMovies;
    public MovieController()
    {
        var myJsonString = System.IO.File.ReadAllText("Models/Movie.json");
        this.listMovies = JsonConvert.DeserializeObject<List<Movie>>(myJsonString)!;
    }

    public IActionResult Index()
    {
        return View(listMovies);
    }

    public IActionResult Find(string movie)
    {
        if (movie == null)
        {
            return View("Index", new List<Movie>());
        }

        List<Movie> FoundMovies = new();

        foreach (var item in this.listMovies)
        {
            if (item.title.ToLower().Contains(movie.ToLower()))
            {
                FoundMovies.Add(item);
            }
        }
        return View("Index", FoundMovies);
    }

    public IActionResult Details(int id)
    {
        foreach (var item in listMovies)
        {
            if(item.id == id)
            {
                return View(item);
            }
        }
        return View(new Movie());
    }
}
