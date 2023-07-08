using Microsoft.EntityFrameworkCore;
using Student.API.Models.Domain;

namespace Student.API.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        DbSet<Students> students { get; set; }
    }
}
