using Microsoft.EntityFrameworkCore;

namespace DAL;

public class TestDbContext : DbContext
{
    public DbSet<Rectangle> Rectangles { get; set; }

    public string DbPath { get; }

    public TestDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;

        var path = Environment.GetFolderPath(folder);

        DbPath = System.IO.Path.Join(path, "test.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}