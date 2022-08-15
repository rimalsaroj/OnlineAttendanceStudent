using Microsoft.EntityFrameworkCore;
using OnlineAttendanceStudent.Models.Domain;

namespace OnlineAttendanceStudent.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
