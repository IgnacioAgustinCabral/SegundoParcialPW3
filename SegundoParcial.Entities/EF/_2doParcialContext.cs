using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SegundoParcial.Entities.EF
{
    public partial class _2doParcialContext : DbContext
    {
        public _2doParcialContext()
        {
        }

        public _2doParcialContext(DbContextOptions<_2doParcialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=IGNACIO\\IGNACIO;Database=2doParcial;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("Empleado");

                entity.Property(e => e.NombreCompleto).HasMaxLength(100);

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_Empleado_Sucursal");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal);

                entity.ToTable("Sucursal");

                entity.Property(e => e.Direccion).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
