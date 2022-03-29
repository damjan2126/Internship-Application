using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Skill> Skills { get; set; }

        //public DbSet<CandidateSkills> CandidateSkills { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = Guid.NewGuid(),
                    Name = "Skill A"
                });

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = Guid.NewGuid(),
                    Name = "Skill B"
                });

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = Guid.NewGuid(),
                    Name = "Skill C"
                });

            modelBuilder.Entity<Candidate>().HasData(
                 new Candidate
                 {
                     Id = Guid.NewGuid(),
                     FullName = "John Johnson",
                     ContactNumber = "1",
                     DateOfBirth = DateTime.UtcNow,
                     Email = "email"
                 }
                ) ;

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    FullName = "Jack Jackson",
                    ContactNumber = "2",
                    DateOfBirth = DateTime.UtcNow,
                    Email = "email2"
                }
               );

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    FullName = "Johnny Joe",
                    ContactNumber = "3",
                    DateOfBirth = DateTime.UtcNow,
                    Email = "email3"
                }
               );
        }
    }
}
