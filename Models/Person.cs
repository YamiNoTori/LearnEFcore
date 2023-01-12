using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace EFcoreLearn_0.View.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public PersonRole? Role {get; set;}
        [Required, MaxLength(15)]
        public string? Name {get; set;}
        [Required]
        public int Age {get; set;}
    }
}