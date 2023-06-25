using Microsoft.EntityFrameworkCore;

namespace Studenci.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
    }
}
