using Microsoft.EntityFrameworkCore;

namespace CustomField_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomFormField>()
                .Property(c => c.CustomFormFieldId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomFormFieldItem>()
                .Property(c => c.CustomFormFieldItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomFormField>()
                .HasMany(f => f.CustomFormFieldItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<CustomFormField> CustomFormFields { get; set; }

        public DbSet<CustomFormFieldItem> CustomFormFieldItems { get; set; }
    }
}
