using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Create Project Class Models
public class Project : HasId
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Text { get; set; }
    public int ProjectListId { get; set; }
}

public class ProjectList : HasId
{
    [Required]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public List<Project> Projects { get; set; }
    public int ProjectId { get;set; }
}

// declare the DbSet<T>'s of our DB context, thus creating the tables
public partial class DB : IdentityDbContext<IdentityUser> {
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectList> ProjectLists { get; set; }
}
// create a Repo<T> services
public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        Repo<Project>.Register(services, "Projects");
        Repo<ProjectList>.Register(services, "ProjectLists",
            d => d.Include(l => l.Projects));
    }
}