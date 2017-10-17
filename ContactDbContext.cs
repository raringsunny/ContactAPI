using Microsoft.EntityFrameworkCore;

namespace contactapi.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) 
        : base(options)
        {

        }

        public DbSet<Contact> Contacts{get;set;}
    }
}