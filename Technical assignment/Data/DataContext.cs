using Microsoft.EntityFrameworkCore;
using Technical_assignment.Models;

namespace Technical_assignment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>(c => { c.HasIndex(x => x.Email).IsUnique(); } );
        }
    }
}
