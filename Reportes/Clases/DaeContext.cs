using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reportes.Clases;

public partial class DaeContext : DbContext
{
    public DaeContext()
    {
    }

    public DaeContext(DbContextOptions<DaeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KK63NOB;Initial Catalog=dae;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("producto");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CostoProd).HasColumnName("costo_prod");
            entity.Property(e => e.IdProd)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_prod");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_prod");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
