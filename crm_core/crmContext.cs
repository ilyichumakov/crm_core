using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crm_core
{
    public partial class crmContext : DbContext
    {
        public crmContext()
        {
        }

        public crmContext(DbContextOptions<crmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsCategory> GoodsCategory { get; set; }
        public virtual DbSet<GoodsToOrders> GoodsToOrders { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<NaturalPerson> NaturalPerson { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString.Value);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PricePaid).HasColumnName("price_paid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bills_order_id_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bills_status_fkey");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_author_fkey");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.InverseComment)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("comments_comment_id_fkey");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("comments_post_id_fkey");
            });

            modelBuilder.Entity<Deals>(entity =>
            {
                entity.ToTable("deals", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("deals_client_id_fkey");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("deals_company_id_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deals_status_fkey");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("documents", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Path).HasColumnName("path");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.ToTable("goods", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("goods_category__fk");
            });

            modelBuilder.Entity<GoodsCategory>(entity =>
            {
                entity.ToTable("goods_category", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<GoodsToOrders>(entity =>
            {
                entity.ToTable("goods_to_orders", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.GoodsToOrders)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("goods_to_orders_good_id_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.GoodsToOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("goods_to_orders_order_id_fkey");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.GoodsToOrders)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("goods_to_orders_service_id_fkey");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads", "test_user");

                entity.HasIndex(e => e.Phone)
                    .HasName("leads_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(200);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(22);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leads_status_fkey");
            });

            modelBuilder.Entity<LegalPerson>(entity =>
            {
                entity.ToTable("legal_person", "test_user");

                entity.HasIndex(e => e.Bik)
                    .HasName("legal_person__bik__unique")
                    .IsUnique();

                entity.HasIndex(e => e.Itin)
                    .HasName("legal_person__itin__unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.Bik)
                    .HasColumnName("bik")
                    .HasMaxLength(9);

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(22);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Itin)
                    .HasColumnName("itin")
                    .HasMaxLength(12);

                entity.Property(e => e.Kpp)
                    .HasColumnName("kpp")
                    .HasMaxLength(9);

                entity.Property(e => e.Representative).HasColumnName("representative");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(300);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(9);

                entity.HasOne(d => d.RepresentativeNavigation)
                    .WithMany(p => p.LegalPerson)
                    .HasForeignKey(d => d.Representative)
                    .HasConstraintName("legal_person__representative__fk");
            });

            modelBuilder.Entity<NaturalPerson>(entity =>
            {
                entity.ToTable("natural_person", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalPhone)
                    .HasColumnName("additional_phone")
                    .HasMaxLength(22);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(22);

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_author_fkey");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("service_category", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services", "test_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("service_service_category_fk");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff", "test_user");

                entity.HasIndex(e => e.Username)
                    .HasName("staff__username__unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.DtCreated)
                    .HasColumnName("dt_created")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DtUpdated)
                    .HasColumnName("dt_updated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.Property(e => e.User).HasColumnName("user");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30);

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_user_fkey");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.ToTable("statuses", "test_user");

                entity.HasIndex(e => e.Code)
                    .HasName("statuses_code_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(2);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasColumnName("entity")
                    .HasMaxLength(2);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username)
                    .HasName("user__username__unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
