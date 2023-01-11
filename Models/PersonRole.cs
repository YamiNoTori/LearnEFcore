using System.ComponentModel.DataAnnotations.Schema;
namespace EFcoreLearn_0.View.Models
{   
    [Table("person_role")]
    public class PersonRole
    {
        [Column("role_id")]
        public int Id {get; set;}
        [Column("role_name")]
        public string? Name {get; set;}


        public override string ToString()
        {
            return $"Role: [{Id}] - {Name}";
        }
    }
}