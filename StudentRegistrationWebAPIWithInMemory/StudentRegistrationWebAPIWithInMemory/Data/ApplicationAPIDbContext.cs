using Microsoft.EntityFrameworkCore;
using StudentRegistrationWebAPIWithInMemory.Models;

namespace StudentRegistrationWebAPIWithInMemory.Data
{
    public class ApplicationAPIDbContext : DbContext
    {
        public ApplicationAPIDbContext(DbContextOptions<ApplicationAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students2 { get; set; }
    }
}
