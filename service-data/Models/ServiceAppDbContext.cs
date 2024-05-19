using Microsoft.EntityFrameworkCore;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models
{
    public class ServiceAppDbContext : DbContext
    {
        public ServiceAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ServerVersion.AutoDetect("server=localhost;database=service_database;User=tibor;Password=Devanlek4203"), x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            base.OnModelCreating(modelBuilder);


        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Admin>()
        //        .HasOne(b => b.Admin_user_id)
        //        .
        //}


        //public DbSet<Ticket> Ticket { get; set; }
        //public DbSet<User> User { get; set; }
        //public DbSet<UserProfile> UserProfile { get; set; }
        //public DbSet<Message> Message { get; set; }
        //public DbSet<Admin> Admin { get; set; }
        //public DbSet<Costumer> Costumer { get; set; }
    }
}