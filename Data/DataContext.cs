using TreesAPI.Models;
using Microsoft.EntityFrameworkCore; 

namespace TreesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options){}

        public DbSet<Node> Nodes {get; set;}
    }
}