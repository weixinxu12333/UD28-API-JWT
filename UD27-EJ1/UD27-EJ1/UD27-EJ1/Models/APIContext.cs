using Microsoft.EntityFrameworkCore;

namespace UD27_EJ1.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(pieza =>
            {
                pieza.ToTable("Piezas");

                //Columna codigo y Primary key
                pieza.Property(e => e.Codigo)
                    .HasColumnName("Codigo")
                    .IsRequired();
                pieza.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                pieza.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedor>(proveedor =>
            {
                proveedor.ToTable("Proveedores");

                //Columna codigo y Primary key
                proveedor.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsRequired();
                proveedor.HasKey(e => e.Id);

                //Columnas y caracteristicas
                proveedor.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Suministra>(suministra =>
            {
                suministra.ToTable("Suministra");

                //Columna codigo y Primary key
                suministra.Property(e => e.CodigoPieza)
                    .HasColumnName("CodigoPieza")
                    .IsRequired();
                suministra.HasKey(e => e.CodigoPieza);

                suministra.Property(e => e.IdProveedor)
                    .HasColumnName("IdProveedor")
                    .HasMaxLength(4)
                    .IsRequired();
                suministra.HasKey(e => e.IdProveedor);

                suministra.Property(e => e.Precio)
                    .HasColumnName("Precio");

                //Relaciones de las tablas
                suministra.HasOne(p => p.Pieza)
                    .WithMany(s => s.Suministras)
                    .HasForeignKey(f => f.CodigoPieza)
                    .HasConstraintName("CodigoPieza_fk");

                suministra.HasOne(p => p.Proveedor)
                   .WithMany(s => s.Suministras)
                   .HasForeignKey(f => f.IdProveedor)
                   .HasConstraintName("IdProveedor_fk");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CE81A3218");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
