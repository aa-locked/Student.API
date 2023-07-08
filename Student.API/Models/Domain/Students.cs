using System.ComponentModel.DataAnnotations;

namespace Student.API.Models.Domain
{
    public class Students
    {
        [Key]
        public Guid StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Standard { get; set; }
    }
}
