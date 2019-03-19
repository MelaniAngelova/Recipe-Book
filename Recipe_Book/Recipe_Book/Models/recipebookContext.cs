using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Recipe_Book.Models
{
    public partial class recipebookContext : DbContext
    {
        public recipebookContext()
        {
        }

        public recipebookContext(DbContextOptions<recipebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsRecipes> ProductsRecipes { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=172.16.100.105;port=3306;user=root;password=root;database=recipebook");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "recipebook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", "recipebook");

                entity.HasIndex(e => e.TypeId)
                    .HasName("fk_products_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImgName)
                    .HasColumnName("img_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("fk_products_types");
            });

            modelBuilder.Entity<ProductsRecipes>(entity =>
            {
                entity.ToTable("products_recipes", "recipebook");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_products_products_products");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("fk_products_recipes_recipes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("recipe_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsRecipes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_products_products_products");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.ProductsRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("fk_products_recipes_recipes");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipes", "recipebook");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_recipes_categories_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImgName)
                    .HasColumnName("img_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipes_categories");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.ToTable("types", "recipebook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
