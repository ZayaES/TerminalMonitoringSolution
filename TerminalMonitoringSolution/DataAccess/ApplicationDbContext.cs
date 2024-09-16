using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.Models;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Custodian> Custodians { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TerminalInfo> TerminalInformation { get; set; }
        public DbSet<SerialNumberTracker> SerialNumberTrackers { get; set; }

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

            modelBuilder.Entity<SerialNumberTracker>().HasKey(t => t.EntityType);

            modelBuilder.Entity<Custodian>().HasData(
                new Custodian
                {
                    Id = "C001",
                    Name = "John Doe",
                    ContactNumber = "123-456-7890",
                    Gender = GenderEnum.Male,
                    Email = "john.doe@example.com",
                    Address = "123 Main St",
                    LGA = "LGA1",
                    State = "State1",
                    Cluster = "Cluster1",
                    ClusterCode = "CC001",
                    ClusterManager = "Manager1",
                    ANM = "ANM1",
                    Type = CustodianType.Merchant,
                    DateCreated = DateTime.Now.AddMonths(-1),
                    DateActivated = DateTime.Now,
                    Status = StatusEnum.Active,
                    IncomeAccount = "IA001"
                },
                new Custodian
                {
                    Id = "C002",
                    Name = "Jane Smith",
                    ContactNumber = "098-765-4321",
                    Gender = GenderEnum.Female,
                    Email = "jane.smith@example.com",
                    Address = "456 Elm St",
                    LGA = "LGA2",
                    State = "State2",
                    Cluster = "Cluster2",
                    ClusterCode = "CC002",
                    ClusterManager = "Manager2",
                    ANM = "ANM2",
                    Type = CustodianType.Agent,
                    DateCreated = DateTime.Now.AddMonths(-2),
                    DateActivated = DateTime.Now.AddDays(-15),
                    Status = StatusEnum.Inactive,
                    IncomeAccount = "IA002"
                });      

            modelBuilder.Entity<Terminal>().HasData(
            new Terminal
            {
                Id = "T001",
                CustodianId = "C001",
                Region = "Region1",
                DateAssigned = DateTime.Now
            },
            new Terminal
            {
                Id = "T002",
                CustodianId = "C002",
                Region = "Region2",
                DateAssigned = DateTime.Now.AddDays(-1)
            }
        );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = "TR001",
                    TimeLogged = DateTime.Now,
                    TransactionTime = DateTime.Now.AddHours(-1),
                    TransactionReference = "TRX001",
                    Amount = 100.00m,
                    TerminalId = "T001",
                    TransactionType = TransactionType.Deposit,
                    TransactionDetails = "Initial deposit",
                    CustodianShare = 10.00m,
                    BankShare = 90.00m
                },
                new Transaction
                {
                    Id = "TR002",
                    TimeLogged = DateTime.Now.AddHours(-2),
                    TransactionTime = DateTime.Now.AddHours(-3),
                    TransactionReference = "TRX002",
                    Amount = 200.00m,
                    TerminalId = "T002",
                    TransactionType = TransactionType.Withdrawal,
                    TransactionDetails = "Withdrawal request",
                    CustodianShare = 20.00m,
                    BankShare = 180.00m
                }
            );

            modelBuilder.Entity<TerminalInfo>().HasData(
                new TerminalInfo
                {
                    Id = "TI001",
                    TimeCreated = DateTime.Now,
                    Signal = SignalEnum.Good,
                    LocationExact = "[40.7128, -74.0060]",
                    LocationApprox = "Downtown",
                    IpAddress = "192.168.1.1",
                    TerminalId = "T001",
                    BatteryLevel = "85%"
                },
                new TerminalInfo
                {
                    Id = "TI002",
                    TimeCreated = DateTime.Now.AddHours(-1),
                    Signal = SignalEnum.Excellent,
                    LocationExact = "[34.0522, -118.2437]",
                    LocationApprox = "Suburb",
                    IpAddress = "192.168.1.2",
                    TerminalId = "T002",
                    BatteryLevel = "75%"
                }
            );
        }
    }
}
