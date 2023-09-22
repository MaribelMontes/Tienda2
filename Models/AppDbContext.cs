using Microsoft.EntityFrameworkCore;
using Practice2.Models;

namespace Practice2.Models {
    public class AppDbContext : DbContext {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

       

     
       public DbSet<Movie> Movies { get; set; }
    
       public DbSet<Actor> Actores{ get; set; }

       public DbSet<Cantante> Cantantes { get; set; }

       public DbSet<Ciudad> Ciudades { get; set; }

         public DbSet<Comment> Comments { get; set;}
         
          public DbSet<Album> Albums { get; set;}
    }
}

