using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MvcMovie.Data;

public class MvcMovieContextFactory : IDesignTimeDbContextFactory<MvcMovieContext>
{
    public MvcMovieContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MvcMovieContext>();
        // Вказуємо шлях до бази даних напряму для інструментів дизайну
        optionsBuilder.UseSqlite("Data Source=MvcMovie.db");

        return new MvcMovieContext(optionsBuilder.Options);
    }
}