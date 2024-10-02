using Microsoft.EntityFrameworkCore;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ADHI170;initial catalog=TraversalDbApi;integrated security=true;TrustServerCertificate=True");

        }

        public DbSet<Visitor> Visitors { get; set; } 
    }
}
