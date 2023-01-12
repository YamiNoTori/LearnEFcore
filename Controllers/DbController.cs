using EFcoreLearn_0.View.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreLearn_0.View.Controllers
{
    public class DbController
    {
        public AppDbContext Context {get; private set;} = null!;
        public String? ConnectionsString {get; private set;}
        private DbContextOptionsBuilder<AppDbContext> OptionsBuilder {get; set;}

        public DbController(string? connStr) 
        {
            ConnectionsString = connStr;
            OptionsBuilder = new();
        }
        

        // Add new role/role`s from role-list
        public void AddNewRoleRange(List<PersonRole> roleList)
        {
            using (AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options))
            {
                foreach(PersonRole role in roleList)
                    db.Add(role);
                try
                {
                    db.SaveChanges();
                }
                catch(DbUpdateException ex) { Console.WriteLine($"Ошибка при добавлении новой роли: {ex.InnerException?.Message}"); }
            }
        }


        public void AddNewPerson(List<Person> personList)
        {
            using (AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options))
            {
                foreach(Person person in personList)
                    db.Add(person);
                try
                {
                    db.SaveChanges();
                }
                catch(DbUpdateException ex) { Console.WriteLine($"Ошибка при добавлении нового юзера: {ex.InnerException?.Message}"); }
            }
        }

        public void GetAndShowAllPersonRoles()
        {
            using (AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options))
            {
                List<PersonRole> list = db.PersonRoles.ToList();
                foreach(PersonRole role in list)
                    Console.WriteLine($"[{role.Id}] {role.Name}");
            }
        }


        // public List<PersonRole> GetAllPersonRole()
        // {
        //     using(AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options))
        //         return db.PersonRoles.ToList();
        // } 

        // public List<Person> GetAllPerson()
        // {
        //     List<Person> result = new();
        //     using(AppDbContext db = new AppDbContext(OptionsBuilder.UseNpgsql(ConnectionsString).Options))
        //     {
        //         List<PersonRole> roles = db.PersonRoles.ToList();

        //     }
        //     return result;
        // }

    }
}