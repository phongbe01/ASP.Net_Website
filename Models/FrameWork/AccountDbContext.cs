namespace Models.FrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountDbContext : DbContext
    {
        public AccountDbContext()
            : base("name=AccountDbContext")
        {
        }

        public virtual DbSet<account> accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
