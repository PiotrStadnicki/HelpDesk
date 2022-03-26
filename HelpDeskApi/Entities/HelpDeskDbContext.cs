using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace HelpDeskApi.Entities
{
    public class HelpDeskDbContext : DbContext
    {
        private string _conncectionString = "Server=.;Database=HelpDeskDb;Trusted_Connection=True;";
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemCategory> ProblemsCategory { get; set; }
        public DbSet<ProblemPlace> ProblemsPlace { get; set; }
        public DbSet<ProblemSolution> ProblemsSolution { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<EnginerLine> EnginerLines { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired(); 

            modelBuilder.Entity<Client>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(12)  ;
        
           modelBuilder.Entity<ProblemCategory>()
                .Property(r => r.Name)
                .IsRequired();                
            modelBuilder.Entity<ProblemPlace>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(12);
            modelBuilder.Entity<ProblemSolution>()
                .Property(r => r.Name)
               .IsRequired();
            modelBuilder.Entity<Client>()
               .Property(r => r.Name)
               .IsRequired();  
            
         



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conncectionString);
        }
        
    }
}
