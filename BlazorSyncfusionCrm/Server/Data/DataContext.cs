using BlazorSyncfusionCrm.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(

                new Contact
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    NickName = "Spider-man",
                    DateOfBirth = new DateTime(2001, 8, 1),
                    Place = "New York City"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Tony",
                    LastName = "Stark",
                    NickName = "Iron-man",
                    DateOfBirth = new DateTime(1990, 8, 1),
                    Place = "Malibu"
                },
              new Contact
              {
                  Id = 3,
                  FirstName = "Bruce",
                  LastName = "Wayne",
                  NickName = "Batman",
                  DateOfBirth = new DateTime(1990, 8, 1),
                  Place = "Gotham City"
              }
                );

            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, ContactId = 1, Text = "With great power comes great responsibility"},
                new Note { Id = 2, ContactId = 2, Text = "The magic you are searching for is in the work you avoiding"},
                new Note { Id = 3, ContactId = 3, Text = "do not care about people"}
                );
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
