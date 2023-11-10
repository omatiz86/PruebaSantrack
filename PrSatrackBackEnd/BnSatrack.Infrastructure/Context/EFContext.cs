using BnSatrack.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace BnSatrack.Infrastructure.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<Transacciones> Transacciones { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            getClientes(modelBuilder);
            getPProductos(modelBuilder);
            getTipoProducto(modelBuilder);
            getTransacciones(modelBuilder);
            getUbicacion(modelBuilder);
        }


        private static void getClientes(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.HasIndex(e => e.IdUbicacion, "IXFK_Clientes_Ubicacion");

                entity.HasIndex(e => e.IdUbicacion, "IXFK_Clientes_Ubicacion_02");

                entity.HasIndex(e => e.Documento, "UNQ_documento_identidad")
                    .IsUnique();               

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdUbicacion)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nit).HasColumnName("NIt");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Notas)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCliente)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_Clientes_Ubicacion_02");
            });

        }

        private static void getPProductos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.HasIndex(e => e.Idcliente, "IXFK_Productos_Clientes");

                entity.HasIndex(e => e.TipoProducto, "IXFK_Productos_TipoProducto");

                entity.HasIndex(e => e.Idtransaccion, "IXFK_Productos_Transacciones");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.FechaApertura).HasColumnType("date");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Idtransaccion).HasColumnName("IDTransaccion");

                entity.Property(e => e.InteresMensual).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Clientes");

                entity.HasOne(d => d.IdtransaccionNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idtransaccion)
                    .HasConstraintName("FK_Productos_Transacciones");

                entity.HasOne(d => d.TipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProducto)
                    .HasConstraintName("FK_Productos_TipoProducto");
            });
        }

        private static void getTipoProducto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto);

                entity.ToTable("TipoProducto");

                entity.Property(e => e.Activo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

        }
        private static void getTransacciones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacciones>(entity =>
            {
                entity.HasKey(e => e.Idtransaccion);

                entity.Property(e => e.Idtransaccion).HasColumnName("IDTransaccion");

                entity.Property(e => e.Documento)
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoTransaccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }

        private static void getUbicacion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.CodDivipola);

                entity.ToTable("Ubicacion");

                entity.Property(e => e.CodDivipola)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Activo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdHijo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdPapa)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdUbicacion).ValueGeneratedOnAdd();

                entity.Property(e => e.Indicativo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });
        }
    }
}
