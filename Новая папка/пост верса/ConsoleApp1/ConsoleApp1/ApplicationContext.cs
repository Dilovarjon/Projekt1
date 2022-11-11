using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;
using ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Bank> Banks { get; set; } = null!;
        public DbSet<Credit> Credits { get; set; } = null!;
        public DbSet<Deposit> Deposits { get; set; } = null!;
        public DbSet<Account> Acconts { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Transit> TransitAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=testdb;",
                new MySqlServerVersion(new Version(10, 6, 5)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Credit>()
                .Property(x => x.Amount).HasPrecision(25, 2);
            modelBuilder.Entity<Deposit>()
                .Property(x => x.Amount).HasPrecision(25, 2);


            modelBuilder.Entity<Bank>().HasData(new Bank
            {
                Id = Guid.Parse("08da6eff-cc2b-42b5-857b-1b0a2942c71d"),
                Name = "Эсхата"
            });

            modelBuilder.Entity<Account>()
                .Property(x => x.TJK).HasPrecision(25, 2);
            modelBuilder.Entity<Account>()
                .Property(x => x.USD).HasPrecision(25, 2);
            modelBuilder.Entity<Account>()
                .Property(x => x.RUB).HasPrecision(25, 2);

            modelBuilder.Entity<Currency>()
                .Property(x => x.Rate).HasPrecision(25, 2);


            modelBuilder.Entity<Currency>().HasKey(x => x.Id);

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = CurrencyEnum.USD,
                    Code = 840,
                    Name = "USD",
                    Rate = 10.27m
                },
                new Currency
                {
                    Id = CurrencyEnum.RUB,
                    Code = 643,
                    Name = "RUB",
                    Rate = 0.16745m
                }
            );


            //Трансит Аккаунт

            modelBuilder.Entity<Transit>()
                .Property(x => x.Amout).HasPrecision(25, 2);
            modelBuilder.Entity<Transit>()
                .Property(x => x.converted_amount).HasPrecision(25, 2);
            modelBuilder.Entity<Transit>()
                .Property(x => x.cur_rate).HasPrecision(25, 2);
        }
    }
}
