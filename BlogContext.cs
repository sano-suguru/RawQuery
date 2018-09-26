using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace RawQuery {
  class BlogContext : DbContext {
    public DbSet<Post> Posts { get; set; }

    static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        new ConsoleLoggerProvider((category, level) =>
          category == DbLoggerCategory.Database.Command.Name
              && level == LogLevel.Information, includeScopes: true) });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
      optionsBuilder
        .EnableSensitiveDataLogging()
        .UseLoggerFactory(loggerFactory)
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Post>().HasData(
          new Post {
            ID = 1,
            Title = "C# 8 ロードマップ",
            Category = "C#",
            IsPrivate = false
          },
          new Post {
            ID = 2,
            Title = "Array.some と Array.includes の使い分け",
            Category = "JavaScript",
            IsPrivate = false
          },
          new Post {
            ID = 3,
            Title = "秘密のポートフォリオ",
            Category = "C#",
            IsPrivate = true
          });
  }
}
