using System.ComponentModel.DataAnnotations.Schema;
namespace EFcoreLearn_0.View.Models
{
    [Table("person")]
    public class Person
    {
        [Column("person_id")]
        public int Id {get; set;}
        [Column("person_role_id")]
        public int RoleId {get; set;}
        [Column("person_name")]
        public string? Name {get; set;}
        [Column("person_age")]
        public int Age {get; set;}
    }
}