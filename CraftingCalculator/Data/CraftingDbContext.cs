using CraftingCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftingCalculator.Data;

public partial class CraftingDbContext : DbContext
{
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<CraftType> CraftTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nicol\source\repos\CraftingCalculator\CraftingCalculator\Database\CraftingDb.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(p => p.Id)
            .ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
            .HasMaxLength(150)
            .IsUnicode(false);

        });

        modelBuilder.Entity<CraftType>(entity =>
        {
            entity.Property(p => p.Id)
            .ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
            .HasMaxLength(50)
            .IsUnicode(false);

            entity.HasMany(e => e.Recipes)
            .WithOne(e => e.CraftType)
            .HasForeignKey(e => e.CraftTypeId)
            .HasPrincipalKey(e => e.Id);

        });


        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.Property(p => p.Id)
            .ValueGeneratedOnAdd();

            entity.HasMany(e => e.Ingredients)
            .WithOne(e => e.Recipe)
            .HasForeignKey(e => e.RecipeId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction);
        });


        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        });




    }
}
