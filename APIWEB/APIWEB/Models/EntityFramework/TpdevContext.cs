using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIWEB.Models.EntityFramework;

public partial class TpdevContext : DbContext
{
    public TpdevContext()
    {
    }

    public TpdevContext(DbContextOptions<TpdevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Serie> Series { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=postgresql-laulouis.alwaysdata.net;port=5432;Database=laulouis_seriedb; uid=laulouis; password=AlexBaka74;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.Serieid).HasName("serie_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
