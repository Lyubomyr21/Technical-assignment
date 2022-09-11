using Microsoft.EntityFrameworkCore;
using Technical_assignment.Models;

namespace Technical_assignment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestModel> testModels { get; set; }
    }
}
