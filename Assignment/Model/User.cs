using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
    }
}
