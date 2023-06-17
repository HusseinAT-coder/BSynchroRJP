using Bsynchro.Domain.Acounts;
using Bsynchro.Domain.Customers;
using Bsynchro.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.Infrastructure
{
    public partial class BSynchroDbContext : DbContext
    {
        public BSynchroDbContext()
        {
            Database.Migrate();
        }

        public BSynchroDbContext(DbContextOptions<BSynchroDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;User ID=sa;Password=P@ssw0rd;Database=BSynchro-db;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

    }
}
