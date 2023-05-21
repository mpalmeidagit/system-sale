using Microsoft.EntityFrameworkCore;
using SystemSale.Model;

namespace SystemSale.DAL.DBContext;

public partial class DbsaleContext : DbContext
{
    public DbsaleContext()
    {
    }

    public DbsaleContext(DbContextOptions<DbsaleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DetailsSale> DetailsSales { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<NumberDocument> NumberDocuments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B6BF5044CD");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DetailsSale>(entity =>
        {
            entity.HasKey(e => e.IdDetailsSale).HasName("PK__DetailsS__BE6BFC3A4270407C");

            entity.ToTable("DetailsSale");

            entity.Property(e => e.IdDetailsSale).HasColumnName("idDetailsSale");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.DetailsSales)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__DetailsSa__idPro__66603565");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.DetailsSales)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__DetailsSa__idSal__656C112C");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483F42CFCDF");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A43E20B1A0");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__4E88ABD4");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__4F7CD00D");
        });

        modelBuilder.Entity<NumberDocument>(entity =>
        {
            entity.HasKey(e => e.IdNumberDocument).HasName("PK__NumberDo__7A94A7ACF17F9A84");

            entity.ToTable("NumberDocument");

            entity.Property(e => e.IdNumberDocument).HasColumnName("idNumberDocument");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.LastNumber).HasColumnName("lastNumber");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__5EEC79D155817949");

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Product__idCateg__5AEE82B9");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F768320320C");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Sale__C4AEB198B695C8F7");

            entity.ToTable("Sale");

            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.NumberDocument)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numberDocument");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TypePayment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typePayment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C98266E17BBC");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegistration");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActivo");
            entity.Property(e => e.NameFull)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameFull");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__idRol__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
