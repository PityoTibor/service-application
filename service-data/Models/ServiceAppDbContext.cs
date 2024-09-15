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
        public ServiceAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
            

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //pesten
            optionsBuilder.UseMySql(ServerVersion.AutoDetect("server=localhost;database=service_database;User=tibor;Password=Start123"), x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            //laptop
            //optionsBuilder.UseMySql(ServerVersion.AutoDetect("server=localhost;database=service_database;User=tibor;Password=Start123"), x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Admin>()
            //   .HasOne(a => a.User)
            //   .WithOne(u => u.Admin)
            //   .HasForeignKey<Admin>(a => a.User_id);

            //modelBuilder.Entity<Costumer>()
            //   .HasOne(c => c.User)
            //   .WithOne(u => u.Costumer)
            //   .HasForeignKey<Costumer>(uc => uc.User_id);

            //modelBuilder.Entity<Handyman>()
            //   .HasOne(h => h.User)
            //   .WithOne(u => u.Handyman)
            //   .HasForeignKey<Handyman>(uh => uh.User_id);

            modelBuilder.Entity<User>()
               .HasOne(u => u.Admin)
               .WithOne(a => a.User)
               .HasForeignKey<Admin>(a => a.User_id);

            modelBuilder.Entity<User>()
              .HasOne(u => u.Costumer)
              .WithOne(c => c.User)
              .HasForeignKey<Costumer>(c => c.User_id);

            modelBuilder.Entity<User>()
              .HasOne(u => u.Handyman)
              .WithOne(h => h.User)
              .HasForeignKey<Handyman>(h => h.User_id);

            modelBuilder.Entity<Ticket>()
               .HasOne(t => t.Handyman)
               .WithMany(h => h.Tickets)
               .HasForeignKey(t => t.Handyman_id);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Costumer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.Costumer_id);
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Messages)
                .WithOne(m => m.Ticket)
                .HasForeignKey(m => m.Ticket_id);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Costumer)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.Costumer_id);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Handyman)
                .WithMany(h => h.Messages)
                .HasForeignKey(m => m.Handyman_id);

            //modelBuilder.Entity<HandymanSkill>()
            //    .HasKey(hs => new { hs.})

            modelBuilder.Entity<HandymanSkill>()
            .HasOne(hs => hs.Skill)
            .WithMany(s => s.HandymanSkills)
            .HasForeignKey(hs => hs.Skill_id);

            modelBuilder.Entity<HandymanSkill>()
            .HasOne(hs => hs.Handyman)
            .WithMany(s => s.HandymanSkills)
            .HasForeignKey(hs => hs.Handyman_id);

            modelBuilder.Entity<TicketSkill>()
            .HasOne(ts => ts.Skill)
            .WithMany(s => s.TicketSkills)
            .HasForeignKey(ts => ts.Skill_id);

            modelBuilder.Entity<TicketSkill>()
            .HasOne(ts => ts.Ticket)
            .WithMany(s => s.TicketSkills)
            .HasForeignKey(ts => ts.Ticket_id);

            modelBuilder.Entity<Interval>()
            .HasOne(hs => hs.Handyman)
            .WithMany(s => s.Intervals)
            .HasForeignKey(hs => hs.Handyman_id);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Costumer> Costumer { get; set; }
        public DbSet<Handyman> Handyman { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<HandymanSkill> HandymanSkill { get; set; }
        public DbSet<TicketSkill> TicketSkill { get; set; }
        public DbSet<Interval> Interval { get; set; }

    }
}