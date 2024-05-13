using Microsoft.EntityFrameworkCore;

namespace DAL;

public class TestContext : DbContext
{
    public DbSet<Rectangle> Rectangles { get; set; }

    public string DbPath { get; }

    public TestContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;

        var path = Environment.GetFolderPath(folder);

        DbPath = System.IO.Path.Join(path, "rectangles.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}