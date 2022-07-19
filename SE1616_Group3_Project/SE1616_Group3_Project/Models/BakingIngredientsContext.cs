using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SE1616_Group3_Project.Models
{
    public partial class BakingIngredientsContext : DbContext
    {
        public BakingIngredientsContext()
        {
        }

        public BakingIngredientsContext(DbContextOptions<BakingIngredientsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductQuantity> ProductQuantities { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; database=BakingIngredients; Integrated security=true; TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.EnableStatus)
                    .HasColumnName("enable_status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Owner)
                    .HasMaxLength(100)
                    .HasColumnName("owner");

                entity.Property(e => e.PhotoLink)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("photo_link");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("title");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK__blog__owner__3D5E1FD2");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__cart_ite__47027DF523FAA3D6");

                entity.ToTable("cart_item");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("added_date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("user_email");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.CartItem)
                    .HasForeignKey<CartItem>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart_item__produ__3E52440B");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserEmail)
                    .HasConstraintName("FK__cart_item__user___3F466844");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("category");
            });

            modelBuilder.Entity<DeliveryStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("delivery_status");

                entity.Property(e => e.DeliveryUnit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("delivery_unit");

                entity.Property(e => e.OrderItem).HasColumnName("order_item");

                entity.Property(e => e.ShippingCompleted).HasColumnName("shipping_completed");

                entity.Property(e => e.ShippingStatus)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("shipping_status");

                entity.HasOne(d => d.OrderItemNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.OrderItem)
                    .HasConstraintName("FK__delivery___order__403A8C7D");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => new { e.UserEmail, e.OrderItem })
                    .HasName("PK__feedback__F3DCE7DC9225E090");

                entity.ToTable("feedback");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("user_email");

                entity.Property(e => e.OrderItem).HasColumnName("order_item");

                entity.Property(e => e.FeedbackDetail)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("feedback_detail");

                entity.Property(e => e.FeedbackPhoto)
                    .HasColumnType("ntext")
                    .HasColumnName("feedback_photo");

                entity.Property(e => e.FeedbackRate).HasColumnName("feedback_rate");

                entity.HasOne(d => d.OrderItemNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrderItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__feedback__order___412EB0B6");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__feedback__user_e__4222D4EF");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasColumnName("amount");

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("user_email");

                entity.HasOne(d => d.PaymentMethodNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethod)
                    .HasConstraintName("FK__order__payment_m__4316F928");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserEmail)
                    .HasConstraintName("FK__order__user_emai__440B1D61");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_item");

                entity.HasIndex(e => e.ProductName, "UQ__order_it__2B5A6A5FDAD5A8D0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BoughtDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bought_date");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PhotoLink)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("photo_link");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("product_name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_ite__order__44FF419A");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_method");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Method)
                    .HasMaxLength(200)
                    .HasColumnName("method");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.PhotoLink)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("photo_link");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__45F365D3");
            });

            modelBuilder.Entity<ProductQuantity>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ShopId, e.UpdateDate })
                    .HasName("PK__product___649AE20DC245A422");

                entity.ToTable("product_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_q__produ__46E78A0C");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_q__shop___47DBAE45");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("address");

                entity.Property(e => e.StaffEmail)
                    .HasMaxLength(100)
                    .HasColumnName("staff_email");

                entity.HasOne(d => d.StaffEmailNavigation)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.StaffEmail)
                    .HasConstraintName("FK__shop__staff_emai__48CFD27E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__user__AB6E61652474F411");

                entity.ToTable("user");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Address)
                    .HasColumnType("ntext")
                    .HasColumnName("address");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.PhotoLink)
                    .HasColumnType("ntext")
                    .HasColumnName("photo_link");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__user__role_id__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
