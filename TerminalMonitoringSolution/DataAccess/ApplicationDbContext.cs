using Microsoft.EntityFrameworkCore;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Custodian> Custodians { get; set;}
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TerminalInfo> TerminalInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Terminal>().HasOne(t => t.Custodian)
                                           .WithMany(c => c.Terminals)
                                           .HasForeignKey(t => t.CustodianId);            

            modelBuilder.Entity<Transaction>().HasOne(txn => txn.Terminal)
                                              .WithMany(c => c.Transactions)
                                              .HasForeignKey(txn => txn.TerminalId);

            modelBuilder.Entity<TerminalInfo>().HasOne(ti => ti.Terminal)
                                               .WithMany(t => t.TerminalInfo)
                                               .HasForeignKey(ti => ti.TerminalId);

            modelBuilder.Entity<Custodian>().HasKey(c => c.Id);

            modelBuilder.Entity<Transaction>().HasKey(txn => txn.TransactionReference);

            modelBuilder.Entity<Terminal>().HasKey(t => t.Id);

            modelBuilder.Entity<TerminalInfo>().HasKey(t => t.Id);

        }
    }

    
}
