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
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }   
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<NumeroDocumento> NumeroDocumentos { get; set; }


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

            modelBuilder.Entity<Categoria>(static entity =>
            {
                entity.HasKey(c => c.IdCategoria);

                entity.Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

                entity.Property(c => c.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                //Relación con producto
                object value = entity.HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(c => c.Descripcion).IsUnique();
            });

            modelBuilder.Entity<Producto>(static entity =>
            {
                entity.HasKey(p => p.IdProducto);

                entity.Property(p => p.CodigoBarra)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

                entity.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(p => p.Categoria)
                .WithMany()
                .IsRequired()
                .HasForeignKey(p => p.IdCategoria);

                entity.Property(p => p.PrecioVenta)
                .IsRequired()
                .HasPrecision(18,2)
                .IsUnicode(false);

                entity.Property(p => p.Stock)
                .IsRequired()
                .HasDefaultValue(0)
                .IsUnicode(false);
                
                entity.Property(p => p.StockMinimo)
                .IsRequired()
                .HasDefaultValue(5)
                .IsUnicode(false);

                entity.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

                entity.Property(p => p.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                entity.HasIndex(c => c.CodigoBarra).IsUnique();
                entity.HasIndex(c => c.Descripcion).IsUnique();
            });

            modelBuilder.Entity<Venta>(static entity =>
            {
                entity.HasKey(v => v.IdVenta);

                entity.Property(v => v.Factura)
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(v => v.Fecha)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                entity.Property(v => v.Dni)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(v => v.Cliente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(v => v.Descuento)
                .IsRequired()
                .HasDefaultValue(0)
                .HasPrecision(4,2)
                .IsUnicode(false);

                entity.Property(v => v.Total)
                .IsRequired()
                .HasDefaultValue(0)
                .HasPrecision(18, 2)
                .IsUnicode(false);

                entity.Property(v => v.Estado)
                .IsRequired()
                .HasConversion<string>();

                entity.Property(v => v.FechaAnulada)
                .IsRequired(false);

                entity.Property(v => v.Motivo)
                .IsRequired(false)
                .HasColumnType("TEXT");

                entity.Property(v => v.UsuarioAnula)
                .IsRequired(false);

                object value = entity.HasMany(v => v.DetalleVentas)
                .WithOne(dv => dv.Venta)
                .HasForeignKey(dv => dv.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(v => v.Factura).IsUnique();
            });

            modelBuilder.Entity<DetalleVenta>(static entity =>
            {
                entity.HasKey(dv => dv.IdDetalleVenta);

                entity.HasOne(dv => dv.Venta)
                .WithMany(v => v.DetalleVentas)
                .HasForeignKey(dv => dv.IdVenta)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(dv => dv.Producto)
                .WithMany()
                .HasForeignKey(dv => dv.IdProducto)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(dv => dv.NombreProducto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(dv => dv.Precio)
                .IsRequired()
                .HasPrecision(18,2)
                .IsUnicode(false);

                entity.Property(dv => dv.Cantidad)
                .IsRequired()
                .HasDefaultValue(1)
                .IsUnicode(false);

                entity.Property(dv => dv.Descuento)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(dv => dv.Total)
                .IsRequired()
                .IsUnicode(false);
                 
            });

            modelBuilder.Entity<NumeroDocumento>(static entity =>
            {
                entity.HasKey(d => d.IdNumeroDocumento);

                entity.Property(d => d.Documento)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(d => d.FechaRegistro)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

                entity.HasIndex(d => d.Documento).IsUnique();
            });
        }
    }
}
