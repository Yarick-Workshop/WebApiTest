using Microsoft.EntityFrameworkCore;

namespace DAL;

public class TestDbContext : DbContext
{
    public DbSet<Rectangle> Rectangles { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {}
}