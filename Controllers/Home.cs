using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System;

[Route("/")]
public class HomeController : Controller
{
    private IRepository<Project> projects;
    private IRepository<ProjectList> lists;
    
    public HomeController(IRepository<Project> projects, IRepository<ProjectList> lists){
        this.projects = projects;
        this.lists = lists;
    }

    [HttpGet("/{username?}")]
    [HttpGet("home/index/{username?}")]
    public IActionResult Root(string username = "you")
    {
        // Console.WriteLine(HttpContext);
        ViewData["Message"] = "Some extra info can be sent to the view";
        ViewData["Username"] = username;
        return View("Index"); // View(new Student) method takes an optional object as a "model", typically called a ViewModel
    }

    // [HttpGet("sql/projects")] // ?sql=....
    // public IActionResult SqlCards([FromQuery]string sql) => Ok(cards.FromSql(sql));

    // [HttpGet("sql/lists")] // ?sql=....
    // public IActionResult SqlLists([FromQuery]string sql) => Ok(lists.FromSql(sql));

}