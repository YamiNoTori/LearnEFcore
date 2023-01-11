using EFcoreLearn_0.View.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreLearn_0.View.Controllers
{
    public class DbController
    {
        public AppDbContext Context {get; private set;} = null!;
        public String? ConnectionsString {get; private set;}
        private DbContextOptionsBuilder<AppDbContext> OptionsBuilder {get; set;}
        // Типа лог-контроллер для БД
        //readonly StreamWriter logDb = new StreamWriter("DbLog.txt", true);

        public DbController(string? connStr) 
        {
            ConnectionsString = connStr;
            OptionsBuilder = new();
        }

        public List<PersonRole> GetAllPersonRole()
        {
            using(AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options, Console.WriteLine))
            {
                var roles = db.PersonRoles.ToList();
                foreach (PersonRole role in roles)
                    Console.WriteLine($"[{role.Id}] {role.Name}");
            }

            return new List<PersonRole>();
        } 
    }
}