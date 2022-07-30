using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace entegre_servis.DataDB
{
    public partial class KRYPTONContext : DbContext
    {
        public KRYPTONContext()
        {
        }

        public KRYPTONContext(DbContextOptions<KRYPTONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kullanici> Kullanicis { get; set; } = null!;
        public virtual DbSet<Satıslar> Satıslars { get; set; } = null!;
        public virtual DbSet<Siparisler> Siparislers { get; set; } = null!;
        public virtual DbSet<Urunler> Urunlers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-R1TUS1N\\SQLEXPRESS;Database=KRYPTON;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.HasKey(e => e.KullaiciId);

                entity.ToTable("kullanici");
                
                entity.Property(e => e.KullaiciId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("kullaici_id");

                entity.Property(e => e.KullaniciIsim)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_isim");

                entity.Property(e => e.KullaniciSifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_sifre");
            });

            modelBuilder.Entity<Satıslar>(entity =>
            {
                entity.HasKey(e => e.SatisId);



                entity.ToTable("satıslar");

                entity.Property(e => e.GarsonAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("garson_adi");

                entity.Property(e => e.SatisId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("satis_id");

                entity.Property(e => e.SiparisTutar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siparis_tutar");
            });

            modelBuilder.Entity<Siparisler>(entity =>
            {
                entity.HasKey(e => e.SiparisId);

                entity.ToTable("siparisler");

                entity.Property(e => e.GarsonAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("garson_adi");

                entity.Property(e => e.MasaNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("masa_no");

                entity.Property(e => e.SiparisAcıklama)
                    .IsUnicode(false)
                    .HasColumnName("siparis_acıklama");

                entity.Property(e => e.SiparisId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("siparis_id");

                entity.Property(e => e.SiparisIsmi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siparis_ismi");

                entity.Property(e => e.SiparisTutarı)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siparis_tutarı");
            });

            modelBuilder.Entity<Urunler>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("urunler");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.UrunAdeti)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urun_adeti");

                entity.Property(e => e.UrunFiyati)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urun_fiyati");

                entity.Property(e => e.UrunIsim)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("urun_isim");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
