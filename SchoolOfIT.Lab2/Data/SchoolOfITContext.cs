using Microsoft.EntityFrameworkCore;
using SchoolOfIT.Lab2.Models;

namespace SchoolOfIT.Lab2.Data
{
    public class SchoolOfITContext : DbContext
    {
        public SchoolOfITContext(DbContextOptions<SchoolOfITContext> options) 
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet <RelationTable> Relations { get; set; }

    }
}
