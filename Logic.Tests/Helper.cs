using DAL;
using Logic;
using Microsoft.Extensions.Configuration;

using NSubstitute;

namespace Logic.Tests;

public static class Helper
{
    public static TestDbContext CreateInMemoryContext()
    {
        var configuration = Substitute.For<IConfiguration>();
        configuration.GetConnectionString("WebApiDatabase")
            .ReturnsForAnyArgs("Filename=:memory:");

        var context = new TestDbContext(configuration);

        //await context.Database.EnsureCreated();

        return context;
    }
}