using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoBook.Models
{
    public partial class recipe_bookContext : DbContext
    {
        public recipe_bookContext()
        {
        }

        public recipe_bookContext(DbContextOptions<recipe_bookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipesProducts> RecipesProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=CLusters10107#;database=recipe_book");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", "recipe_book");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasColumnName("product_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipes", "recipe_book");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Decription)
                    .HasColumnName("decription")
                    .HasColumnType("longtext");

                entity.Property(e => e.Difficulty)
                    .HasColumnName("difficulty")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Favorites)
                    .HasColumnName("favorites")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.MyRecipes)
                    .HasColumnName("my_recipes")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasColumnName("recipe_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipesProducts>(entity =>
            {
                entity.ToTable("recipes_products", "recipe_book");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_products_recipes_products");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("fk_recipes_recipes_products");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("recipe_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RecipesProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_products_recipes_products");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipesProducts)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("fk_recipes_recipes_products");
            });
        }
    }
}
