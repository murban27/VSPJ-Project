using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using XWP.Demo06.Model;

namespace XWP.Demo06
{
    public class ContactsDatabaseContext : DbContext
    {
        private const string DatabaseFilename = "Contacts.db";

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseFilePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
            optionsBuilder.UseSqlite($"Filename={databaseFilePath}");
        }
    }
}
