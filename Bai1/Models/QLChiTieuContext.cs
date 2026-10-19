using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLChiTieu.Models;

public partial class QLChiTieuContext : DbContext
{
    public QLChiTieuContext()
    {
    }

    public QLChiTieuContext(DbContextOptions<QLChiTieuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTieu> ChiTieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = QLChiTieu.Config.AppConfig.Current.ConnectionStrings.DefaultConnection;
            if (string.IsNullOrWhiteSpace(connStr))
            {
                connStr = "Server=.\\SQLEXPRESS;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;";
            }
            optionsBuilder.UseSqlServer(connStr);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTieu>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK__ChiTieu__27258E748843CBFD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
