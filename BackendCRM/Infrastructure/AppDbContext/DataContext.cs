
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AppDbContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Interactions> Interactions { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }

        public DbSet<InteractionTypes> InteractionTypes { get; set; }

        public DbSet<CampaignTypes> CampaignTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=CRMProyecto;User=root;Password=Optymus262003;Port=3306;", new MySqlServerVersion(new Version(8, 0, 39)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.ClientID).ValueGeneratedOnAdd();
                entity.Property(c => c.CreateDate).IsRequired();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(255);
                entity.Property(c => c.Email).IsRequired().HasColumnType("varchar").HasMaxLength(255);
                entity.Property(c => c.Phone).IsRequired().HasColumnType("varchar").HasMaxLength(255);
                entity.Property(c => c.Company).IsRequired().HasColumnType("varchar").HasMaxLength(100);
                entity.Property(c => c.Address).IsRequired().HasColumnType("varchar").HasMaxLength(255);

                entity.HasData(

                    new Clients { ClientID = 1, Name = "Bruce Wayne", Email = "bruce.wayne@wayneenterprises.com", Phone = "+1 555-0100", Company = "Wayne Enterprises", Address = "1007 Mountain Drive, Gotham City, NJ", CreateDate = DateTime.Now},
                    new Clients { ClientID = 2, Name = "Clark Kent", Email = "clark.kent@dailyplanet.com", Phone = "+1 555-0199", Company = "Daily Planet", Address = "350 5th St, Metropolis, NY", CreateDate = DateTime.Now },
                    new Clients { ClientID = 3, Name = "Diana Prince", Email = "diana.prince@themyscira.com", Phone = "+1 555-0142", Company = "Amazonian Technologies", Address = "Paradise Island, Themyscira", CreateDate = DateTime.Now },
                    new Clients { ClientID = 4, Name = "Hal Jordan", Email = "hal.jordan@greenlantern.com", Phone = "+1 555-0166", Company = "Ferris Aircraft", Address = "800 15th St, Coast City, CA", CreateDate = DateTime.Now },
                    new Clients { ClientID = 5, Name = "Barry Allen", Email = "barry.allen@ccpd.com", Phone = "+1 555-0123", Company = "Central City Police Department", Address = "123 Main St, Central City, KS", CreateDate = DateTime.Now }
                    );
            }
            );


            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(c => c.ProjectID);
                entity.Property(c => c.ProjectID).ValueGeneratedOnAdd();
                entity.Property(c => c.StartDate).IsRequired();
                entity.Property(c => c.EndDate).IsRequired();
                entity.Property(c => c.CreateDate).IsRequired();
                entity.Property(c => c.UpdateDate);
                entity.Property(c => c.ProjectName).IsRequired().HasColumnType("varchar").HasMaxLength(255); 
                entity.HasOne(c => c.ClientsNavigator).WithMany(p => p.Projects).HasForeignKey(k => k.ClientID);
                entity.HasOne(c => c.CampaignTypesNavigator).WithMany(p => p.Projects).HasForeignKey(k => k.CampaignType);
            }
            );


            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(c => c.TaskID);
                entity.Property(c => c.TaskID).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(255); 
                entity.Property(c => c.DueDate).IsRequired();
                entity.Property(c => c.CreateDate).IsRequired();
                entity.Property(c => c.UpdateDate);
                entity.HasOne(c => c.ProjectNavigator).WithMany(p => p.Tasks).HasForeignKey(k => k.ProjectID);
                entity.HasOne(c => c.UserNavigator).WithMany(p => p.Tasks).HasForeignKey(k => k.AssignedTo);
                entity.HasOne(c => c.TaskStatusNavigator).WithMany(p => p.Tasks).HasForeignKey(k => k.Status);
            }
            );


            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.HasKey(c => c.InteractionID);
                entity.Property(c => c.InteractionID).ValueGeneratedOnAdd();
                entity.Property(c => c.Date).IsRequired();
                entity.Property(c => c.Notes).IsRequired().HasColumnType("varchar").HasMaxLength(255); 
                entity.HasOne(c => c.ProjectNavigator).WithMany(p => p.Interactions).HasForeignKey(k => k.ProjectID);
                entity.HasOne(c => c.InteractionTypesNavigator).WithMany(p => p.Interactions).HasForeignKey(k => k.InteractionType);
            }
            );


            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(c => c.UserID);
                entity.Property(c => c.UserID).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(255);
                entity.Property(c => c.Email).IsRequired().HasColumnType("varchar").HasMaxLength(255);

                entity.HasData(
                    new Users { UserID = 1, Name = "Joe Done", Email = "jdone@marketing.com" },
                    new Users { UserID = 2, Name = "Nill Amstrong", Email = "namstrong@marketing.com" },
                    new Users { UserID = 3, Name = "Marlyn Morales", Email = "mmorales@marketing.com" },
                    new Users { UserID = 4, Name = "Antony Orué", Email = "aorue@marketing.com" },
                    new Users { UserID = 5, Name = "Jazmin Fernandez ", Email = "jfernandez@marketing.com" });
            }
            );


            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(25);

                entity.HasData(
                    new Domain.Entities.TaskStatus { Id = 1, Name = "Pending" },
                    new Domain.Entities.TaskStatus { Id = 2, Name = "In Progress" },
                    new Domain.Entities.TaskStatus { Id = 3, Name = "Blocked" },
                    new Domain.Entities.TaskStatus { Id = 4, Name = "Done" },
                    new Domain.Entities.TaskStatus { Id = 5, Name = "Cancel" }
                    );
            }
            );


            modelBuilder.Entity<CampaignTypes>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(25);

                entity.HasData(
                    new CampaignTypes { Id = 1, Name = "SEO"},
                    new CampaignTypes { Id = 2, Name = "PPC" },
                    new CampaignTypes { Id = 3, Name = "Social Media" },
                    new CampaignTypes { Id = 4, Name = "Email Marketing" }
                    );
            }
           );


            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(25);

                entity.HasData(
                    new InteractionTypes { Id = 1, Name = "Initial Meeting"},
                    new InteractionTypes { Id = 2, Name = "Phone call" },
                    new InteractionTypes { Id = 3, Name = "Email" },
                    new InteractionTypes { Id = 4, Name = "Presentation of Results" }
                    );
            }
           );







        }
    }
}
