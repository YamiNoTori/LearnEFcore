using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFcoreLearn_0.View.Models
{   
    [Table("PersonRole")]
    public class PersonRole
    {
        [Key]
        public int Id {get; set;}
        [Required, MaxLength(25)]
        public string? Name {get; set;}


        public override string ToString()
        {
            return $"Role: [{Id}] - {Name}";
        }
    }
}