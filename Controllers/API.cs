using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/project")]
public class ProjectController : CRUDController<Project> {
    public ProjectController(IRepository<Project> r) : base(r){}

    [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(project => 
            project.Title.ToLower().IndexOf(term.ToLower()) != -1
            || project.Text.ToLower().IndexOf(term.ToLower()) != -1
        )));
    }
}

[Route("/api/projectList")]
public class ProjectListController : CRUDController<ProjectList> {
    public ProjectListController(IRepository<ProjectList> r) : base(r){}
}