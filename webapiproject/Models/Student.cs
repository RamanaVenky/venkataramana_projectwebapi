using System.ComponentModel.DataAnnotations;

namespace webapiproject.Models
{
    public class Student
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int age { get; set; }
    }
}