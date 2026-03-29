namespace webapiproject.Models
{
    public class classRepositary
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student { id = 1, name = "ramana", age = 10 },
            new Student { id = 2, name = "ramanavenky", age = 40 },
            new Student { id = 3, name = "venu", age = 40 }
        };
    }
}  