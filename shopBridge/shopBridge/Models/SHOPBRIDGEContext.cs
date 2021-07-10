using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace shopBridge.Models
{
    //Dbcontext file for the databse
    public partial class SHOPBRIDGEContext : DbContext
    {
        public SHOPBRIDGEContext()
        {
        }

        public SHOPBRIDGEContext(DbContextOptions<SHOPBRIDGEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SHOPBRIDGE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.ToTable("INVENTORY");

                entity.Property(e => e.Itemid)
                    .ValueGeneratedNever()
                    .HasColumnName("ITEMID");

                entity.Property(e => e.Itemadddate)
                    .HasColumnType("date")
                    .HasColumnName("ITEMADDDATE");

                entity.Property(e => e.Itemdescription)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("ITEMDESCRIPTION");

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNAME");

                entity.Property(e => e.Itemprice).HasColumnName("ITEMPRICE");

                entity.Property(e => e.Itemquantity).HasColumnName("ITEMQUANTITY");
            });

            modelBuilder.HasSequence("ITEMID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
