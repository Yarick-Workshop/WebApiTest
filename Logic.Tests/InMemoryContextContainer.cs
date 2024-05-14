using DAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;


namespace Logic.Tests;
/// <summary>
/// based on: 
/// </summary>
public class InMemoryContextContainer: IDisposable
{
    private bool _disposedValue;

    private readonly SqliteConnection _connection;
    public readonly TestDbContext Context;

    public InMemoryContextContainer()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        var contextOptions = new DbContextOptionsBuilder<TestDbContext>()
            .UseSqlite(_connection)
            .Options;
        
        Context = new TestDbContext(contextOptions);

        Context.Database.EnsureCreated();
    }

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Context.Dispose();
                _connection.Dispose();
            }

            _disposedValue = true;
        }
    }
}