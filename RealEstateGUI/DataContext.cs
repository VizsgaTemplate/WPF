using Jedlik.EntityFramework.Helper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    //Parancsok a Package manager console-ban:
    //  Add-Migration <név> -Project <data project> -StartupProject <data project>
    //  Script-Migration -Project <data project> -StartupProject <data project>
    //  update-database -Project <data project> -StartupProject <data project>

    public class DataContext: JedlikDbContext
    {
        public DbSet<Ad> realestates { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Seller> sellers { get; set; }

        private readonly string connStr;

        public DataContext()
        {            
            connStr = "server=localhost;database=ingatlan;uid=root;pwd=;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connStr))
                optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TeacherModel>().HasIndex(t => t.Name).IsUnique();

            //modelBuilder.Entity<ToolTypeModel>().HasData
            //(
            //    new () { id = 1, name = "Számítástechnikai"},
            //    new () { id = 2, name = "Építészi"},
            //    new () { id = 3, name = "Javítási"},
            //    new () { id = 4, name = "Dekorációs"},
            //    new () { id = 5, name = "Egyéb"}
            //);

        }
    }
}
