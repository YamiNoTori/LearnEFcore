using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFcoreLearn_0.View.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons {get; set;} = null!;
        public DbSet<PersonRole> PersonRoles {get; set;} = null!;

        private Action<string> Logger {get; set;} = null!;


        public AppDbContext(DbContextOptions<AppDbContext> options, Action<string> logger) : base(options) 
        {
            Database.EnsureCreated();
            Logger = logger;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.LogTo(Logger ?? throw new Exception("Logger is null!"), new[] { RelationalEventId.CommandExecuted});


    }
}