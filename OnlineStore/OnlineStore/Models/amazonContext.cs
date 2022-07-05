using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnlineStore.Models
{
    public partial class amazonContext : DbContext
    {
        public amazonContext()
        {
        }

        public amazonContext(DbContextOptions<amazonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=amazon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                //entity.HasNoKey();
               
                entity.ToTable("cart");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Pname)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("pname");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__cart__email__38996AB5");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__cart__product_id__398D8EEE");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Subject)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("subject");
            });

            modelBuilder.Entity<Order>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("Orders");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("deliveryDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                //entity.Property(e => e.Id)
                //    .ValueGeneratedOnAdd()
                //    .HasColumnName("id");

                entity.Property(e => e.MobileNumber).HasColumnName("mobileNumber");
                entity.Property(e => e.MyEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("myemail");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("orderDate");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("paymentMethod");

                entity.Property(e => e.Pname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("pname");
                entity.Property(e => e.Price).HasColumnName("price");
                            
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("transactionId");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__Orders__email__3B75D760");
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__product___49C3F6B7");
            
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("active");

                entity.Property(e => e.Category)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__users__AB6E61657B84ADB3");

                entity.ToTable("users");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Answer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("answer");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.MobileNumber).HasColumnName("mobileNumber");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("securityQuestion");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
