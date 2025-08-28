using Microsoft.EntityFrameworkCore;
using Pos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Context
{
    public class PosContext : DbContext
    {
        public PosContext(DbContextOptions<PosContext> options) : base(options) { }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Negocio> Negocios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>(static entity =>
            {
                entity.HasKey(r => r.IdRol);

                entity.Property(r => r.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(r => r.Estado)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

                entity.Property(r => r.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                entity.HasIndex(r => r.Descripcion).IsUnique();
            });

            modelBuilder.Entity<Usuario>(static entity =>
            {
                entity.HasKey(r => r.IdUsuario);

                entity.Property(r => r.Nombres)
                .IsRequired()
                .HasMaxLength(35)
                .IsUnicode(false);

                entity.HasOne(r => r.Rol)
                .WithMany(u => u.Usuarios)
                .IsRequired()
                .HasForeignKey(r => r.IdRol);

                entity.Property(r => r.Telefono)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

                entity.Property(r => r.Estado)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);


                entity.Property(r => r.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                entity.HasIndex(r => r.Telefono).IsUnique();
            });

            modelBuilder.Entity<Negocio>(static entity => {
                entity.HasKey(n => n.IdNegocio);

                entity.Property(n => n.RUC)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(n => n.RazonSocial)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(n => n.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(n => n.Telefono)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(n => n.Direccion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(n => n.Propietario)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(n => n.Descuento)
                .IsRequired()
                .HasDefaultValue(0)
                .HasPrecision(4,2)
                .IsUnicode(false);

                entity.Property(n => n.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            });

        }
    }
}
