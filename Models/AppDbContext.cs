using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFcoreLearn_0.View.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons {get; set;} = null!;
        public DbSet<PersonRole> PersonRoles {get; set;} = null!;
        
        
        private StreamWriter LogStream {get; } = new StreamWriter("DbLog.txt", true);


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.LogTo(LogStream.WriteLine, new[] { RelationalEventId.CommandExecuted}
                , Microsoft.Extensions.Logging.LogLevel.Information);


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonRole>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }






        public override void Dispose()
        {
            base.Dispose();
            LogStream.Dispose();
        }
    
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await LogStream.DisposeAsync();
        }

    }


}