using Microsoft.EntityFrameworkCore;
using UD27_EJ4.DataLayer.Models;

namespace UD27_EJ4.DataLayer.Context
{
    public partial class InvestigadoresContext : DbContext
    {
        public InvestigadoresContext(DbContextOptions<InvestigadoresContext> options)
            : base(options) { }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Facultad> Facultades { get; set; }
        public virtual DbSet<Investigador> Investigadores { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }

        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.ToTable("Equipos");

                //Columna numSerie y Primary key
                equipo.Property(e => e.NumSerie)
                    .HasColumnName("NumSerie")
                    .HasMaxLength(4)
                    .IsRequired();
                equipo.HasKey(e => e.NumSerie)
                    .HasName("PK__Equipos__G5F8W888W7W14W7W");

                //Columnas y caracteristicas
                equipo.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .IsUnicode(true)
                    .HasMaxLength(100);

                equipo.HasOne(e => e.Facultad).WithMany(f => f.Equipos).HasForeignKey("facultad");
            });

            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.ToTable("Reserva");

                //Columna codigo y Primary key
                reserva.Property(e => e.Investigador_DNI)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(true)
                    .IsRequired();

                reserva.Property(e => e.Equipo_NumSerie)
                    .HasColumnName("NumSerie")
                    .HasMaxLength(4)
                    .IsUnicode(true)
                    .IsRequired();

                reserva.HasKey(e => new { e.Investigador_DNI, e.Equipo_NumSerie });

                //Columnas y caracteristicas
                reserva.Property(e => e.Comienzo)
                    .HasColumnName("Comienzo");

                reserva.Property(e => e.Fin)
                    .HasColumnName("Fin");

                reserva.HasOne(e => e.Investigador)
                    .WithMany(i => i.Reservas)
                    .HasForeignKey(e => e.Investigador_DNI)
                    .HasConstraintName("FK__ReservaInvestigador__77WE745D8E54W2D5");

                reserva.HasOne(e => e.Equipo)
                    .WithMany(i => i.Reservas)
                    .HasForeignKey(e => e.Equipo_NumSerie)
                    .HasConstraintName("FK__ReservaEquipo__9Q9WD5YT5I7O4P1P");
            });

            modelBuilder.Entity<Facultad>(facultad =>
            {
                facultad.ToTable("Facultad");

                facultad.Property(e => e.Codigo)
                     .HasColumnName("Codigo")
                     .IsRequired();
                facultad.HasKey(e => e.Codigo)
                     .HasName("PK__Facultades__Q7W89R7G4D5W6D1S");

                facultad.Property(f => f.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .IsRequired();
            });

            modelBuilder.Entity<Investigador>(investigador =>
            {
                investigador.ToTable("Investigadores");

                //Columna codigo y Primary key
                investigador.Property(e => e.DNI)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsRequired()
                    .IsUnicode(true);
                investigador.HasKey(e => e.DNI)
                    .HasName("PK__Investigadores__M1M4M1M4G8D9E5D5");

                investigador.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsRequired()
                    .IsUnicode(true);

                investigador.HasOne(e => e.Facultad).WithMany(f => f.Investigadores).HasForeignKey("facultad");
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