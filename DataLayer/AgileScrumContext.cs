using DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AgileScrumContext: DbContext
    {
        public AgileScrumContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<RegistrationDetail> RegistrationDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<DomainClasses.Task> Tasks { get; set; }

        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<Backlog> Backlogs { get; set; }

        public DbSet<EmailServer> EmailServers { get; set; }

        public DbSet<Epic> Epics { get; set; }

        public DbSet<ResetPasswordDetail> ResetPasswordDetails { get; set; }

        public DbSet<WorkLoad> WorkLoads { get; set; }

    }
}
