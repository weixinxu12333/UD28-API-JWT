using Microsoft.EntityFrameworkCore;

namespace UD27_EJ2.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public virtual DbSet<Cientifico> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Asignado_a> Asignado_as { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientifico>(cientifico =>
            {
                cientifico.ToTable("Cientificos");

                //Columna codigo y Primary key
                cientifico.Property(e => e.Dni)
                    .HasColumnName("Dni")
                    .HasMaxLength(8)
                    .IsRequired();

                cientifico.HasKey(e => e.Dni)
                    .HasName("PK__Cientifico__S8E4G2S9Q2F3R8H1");

                //Columnas y caracteristicas
                cientifico.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .IsUnicode(true)
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Proyecto>(proyecto =>
            {
                proyecto.ToTable("Proyectos");

                proyecto.HasKey(e => e.Id)
                    .HasName("PK__Cientifico__SDA7FG8W1B5W9Q5F");

                //Columna codigo y Primary key
                proyecto.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(4)
                    .IsUnicode(true)
                    .IsRequired();
                
                //Columnas y caracteristicas
                proyecto.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .IsUnicode(true)
                    .HasMaxLength(255);

                proyecto.Property(e => e.Horas)
                    .HasColumnName("Horas")
                    .HasMaxLength(255);

            });

            modelBuilder.Entity<Asignado_a>(asignado_a =>
            {
                asignado_a.ToTable("Asignado_a");

                //Columna codigo y Primary key
                asignado_a.Property(e => e.Cientifico)
                    .HasColumnName("Cientifico")
                    .IsRequired()
                    .IsUnicode(true);
                asignado_a.HasKey(e => e.Cientifico);

                asignado_a.Property(e => e.Proyecto)
                    .HasColumnName("Proyecto")
                    .HasMaxLength(4)
                    .IsRequired()
                    .IsUnicode(true);
                asignado_a.HasKey(e => e.Proyecto);

                //Relaciones de las tablas
                asignado_a.HasOne(c => c.Cientificos)
                    .WithMany(a => a.Asignado_As)
                    .HasForeignKey(cc => cc.Cientifico)
                    .HasConstraintName("FK__AsignadoACientifico__587RT8H5JD8TY85J");


                asignado_a.HasOne(p => p.Proyectos)
                   .WithMany(a => a.Asignado_As)
                   .HasForeignKey(pr => pr.Proyecto)
                   .HasConstraintName("FK__AsignadoAProyecto__15S48G8W4S8S1W9Q");

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