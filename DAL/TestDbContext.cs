using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class TestDbContext : DbContext
{
    public DbSet<Rectangle> Rectangles { get; set; }

    protected readonly IConfiguration Configuration;

    public TestDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }
}