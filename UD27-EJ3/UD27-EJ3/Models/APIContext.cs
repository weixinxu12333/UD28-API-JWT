using Microsoft.EntityFrameworkCore;

namespace UD27_EJ3.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public virtual DbSet<Cajero> Cajeros { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Maquina_Registradora> Maquina_Registradoras { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajero>(cajero =>
            {
                cajero.ToTable("Cajeros");

                //Columna codigo y Primary key
                cajero.Property(e => e.Codigo)
                    .HasColumnName("Codigo")
                    .IsRequired();
                cajero.HasKey(e => e.Codigo)
                    .HasName("PK__Cajeros__15S4Q8D1F5F1B1F8");

                //Columnas y caracteristicas
                cajero.Property(e => e.NomApels)
                .HasColumnName("NomApels")
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Producto>(producto =>
            {
                producto.ToTable("Productos");

                //Columna codigo y Primary key
                producto.Property(e => e.Codigo)
                    .HasColumnName("Codigo")
                    .IsRequired();
                producto.HasKey(e => e.Codigo)
                    .HasName("PK__Productos__S8E4F2G8W7DS4S8S");

                //Columnas y caracteristicas
                producto.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(100);

                producto.Property(e => e.Precio)
                    .HasColumnName("Precio")
                    .IsRequired();
            });

            modelBuilder.Entity<Maquina_Registradora>(maquina_registradoras =>
            {
                maquina_registradoras.ToTable("Maquinas_registradoras");

                //Columna codigo y Primary key
                maquina_registradoras.Property(e => e.Codigo)
                    .HasColumnName("Codigo")
                    .IsRequired();
                maquina_registradoras
                    .HasKey(e => e.Codigo)
                    .HasName("PK__MaquinaRegistradora__7R7W7F84F5D9W8D4");
                //Columnas y caracteristicas
                maquina_registradoras.Property(e => e.Piso)
                    .HasColumnName("Piso")
                    .IsRequired();
            });

            modelBuilder.Entity<Venta>(venta =>
            {
                venta.ToTable("Venta");

                //Columna codigo y Primary key
                venta.Property(e => e.Cajero)
                    .HasColumnName("Cajero")
                    .IsRequired();
                venta.HasKey(e => e.Cajero);

                venta.Property(e => e.Maquina)
                    .HasColumnName("Maquina")
                    .IsRequired();
                venta.HasKey(e => e.Maquina);

                venta.Property(e => e.Producto)
                    .HasColumnName("Producto")
                    .IsRequired();
                venta.HasKey(e => e.Producto);

                //Relaciones de las tablas
                venta.HasOne(c => c.Cajeros)
                    .WithMany(v => v.Ventas)
                    .HasForeignKey(f => f.Cajero)
                    .HasConstraintName("FK__Venta__Cajero__B5D8WE4FGG58EE88");

                venta.HasOne(c => c.Productos)
                    .WithMany(v => v.Ventas)
                    .HasForeignKey(f => f.Producto)
                    .HasConstraintName("FK__Venta__MaquinaRegistradora__8789J77U8J1K4Y8U");

                venta.HasOne(c => c.Maquinas)
                    .WithMany(v => v.Ventas)
                    .HasForeignKey(f => f.Maquina)
                    .HasConstraintName("FK__Venta__Producto__1R1R2T5Y0H5Y7J4H");

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
