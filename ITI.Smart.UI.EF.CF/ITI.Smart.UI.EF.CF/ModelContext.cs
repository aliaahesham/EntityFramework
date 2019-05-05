namespace ITI.Smart.UI.EF.CF
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>()
            //    .ToTable("City");

            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            //one to many
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Fk_DepartmentId)
                .WillCascadeOnDelete(false);

            //many to many
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .Map(m => m.ToTable("UsersBooks")
                .MapLeftKey("Fk_BookId")
                .MapRightKey("Fk_UserId"));

            //one to one optional
            modelBuilder.Entity<City>()
                .HasOptional(c => c.Book)
                .WithRequired(b => b.City);

            //one to one required
            modelBuilder.Entity<Cover>()
                .ToTable("Cover");

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Cover)
                .WithRequiredPrincipal(c => c.Book);
        }


    }
}