using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace entegre_servis.Models
{
    public partial class db_gulSistemContext : DbContext
    {
        public db_gulSistemContext()
        {
        }

        public db_gulSistemContext(DbContextOptions<db_gulSistemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAgirlik> TblAgirliks { get; set; } = null!;
        public virtual DbSet<TblAltKategori> TblAltKategoris { get; set; } = null!;
        public virtual DbSet<TblAltUrunler> TblAltUrunlers { get; set; } = null!;
        public virtual DbSet<TblDurum> TblDurums { get; set; } = null!;
        public virtual DbSet<TblFatura> TblFaturas { get; set; } = null!;
        public virtual DbSet<TblFirma> TblFirmas { get; set; } = null!;
        public virtual DbSet<TblHacim> TblHacims { get; set; } = null!;
        public virtual DbSet<TblKategori> TblKategoris { get; set; } = null!;
        public virtual DbSet<TblKullanici> TblKullanicis { get; set; } = null!;
        public virtual DbSet<TblLog> TblLogs { get; set; } = null!;
        public virtual DbSet<TblMagazaFiyatlari> TblMagazaFiyatlaris { get; set; } = null!;
        public virtual DbSet<TblMarka> TblMarkas { get; set; } = null!;
        public virtual DbSet<TblModel> TblModels { get; set; } = null!;
        public virtual DbSet<TblNumara> TblNumaras { get; set; } = null!;
        public virtual DbSet<TblOzellikler> TblOzelliklers { get; set; } = null!;
        public virtual DbSet<TblRenk> TblRenks { get; set; } = null!;
        public virtual DbSet<TblSipari> TblSiparis { get; set; } = null!;
        public virtual DbSet<TblUrun> TblUruns { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=db_gulSistem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAgirlik>(entity =>
            {
                entity.HasKey(e => e.AgirlikId);

                entity.ToTable("tbl_agirlik");

                entity.Property(e => e.AgirlikId).HasColumnName("agirlik_id");

                entity.Property(e => e.Agirlik).HasColumnName("agirlik");
            });

            modelBuilder.Entity<TblAltKategori>(entity =>
            {
                entity.HasKey(e => e.AltKategoriId);

                entity.ToTable("tbl_altKategori");

                entity.Property(e => e.AltKategoriId).HasColumnName("altKategori_id");

                entity.Property(e => e.AltKategori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("altKategori");
            });

            modelBuilder.Entity<TblAltUrunler>(entity =>
            {
                entity.HasKey(e => e.AltUrunId);

                entity.ToTable("tbl_altUrunler");

                entity.Property(e => e.AltUrunId).HasColumnName("altUrun_id");

                entity.Property(e => e.AltUrunAdi)
                    .HasMaxLength(50)
                    .HasColumnName("altUrunAdi");

                entity.Property(e => e.Fiyat)
                    .HasColumnType("money")
                    .HasColumnName("fiyat");

                entity.Property(e => e.UrunId).HasColumnName("urun_id");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.TblAltUrunlers)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_tbl_altUrunler_tbl_urun");
            });

            modelBuilder.Entity<TblDurum>(entity =>
            {
                entity.HasKey(e => e.DurumId);

                entity.ToTable("tbl_durum");

                entity.Property(e => e.DurumId).HasColumnName("durum_id");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .HasColumnName("durum")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblFatura>(entity =>
            {
                entity.HasKey(e => e.FaturaId);

                entity.ToTable("tbl_fatura");

                entity.Property(e => e.FaturaId).HasColumnName("fatura_id");

                entity.Property(e => e.EArsivSeri)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("eArsivSeri");

                entity.Property(e => e.EFaturaSeri)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("eFaturaSeri");

                entity.Property(e => e.EFaturaTipi)
                    .HasMaxLength(15)
                    .HasColumnName("eFaturaTipi")
                    .IsFixedLength();

                entity.Property(e => e.FaturaTipi)
                    .HasMaxLength(15)
                    .HasColumnName("faturaTipi")
                    .IsFixedLength();

                entity.Property(e => e.FirmaId).HasColumnName("firma_id");

                entity.Property(e => e.KargoKodu)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("kargoKodu");

                entity.Property(e => e.KargoVergiNo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("kargoVergiNo");

                entity.Property(e => e.KdvIstisnaDurum)
                    .HasMaxLength(10)
                    .HasColumnName("kdvIstisnaDurum")
                    .IsFixedLength();

                entity.Property(e => e.KullaniciId).HasColumnName("kullanici_id");

                entity.Property(e => e.UrunId).HasColumnName("urun_id");

                entity.Property(e => e.WebSiteUrl)
                    .HasMaxLength(200)
                    .HasColumnName("webSiteUrl")
                    .IsFixedLength();

                entity.HasOne(d => d.Firma)
                    .WithMany(p => p.TblFaturas)
                    .HasForeignKey(d => d.FirmaId)
                    .HasConstraintName("FK_tbl_fatura_tbl_firma");
            });

            modelBuilder.Entity<TblFirma>(entity =>
            {
                entity.HasKey(e => e.FirmaId);

                entity.ToTable("tbl_firma");

                entity.Property(e => e.FirmaId).HasColumnName("firma_id");

                entity.Property(e => e.Adres)
                    .HasColumnType("text")
                    .HasColumnName("adres");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .HasColumnName("alias");

                entity.Property(e => e.FirmaAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firmaAdi");

                entity.Property(e => e.Il)
                    .HasMaxLength(30)
                    .HasColumnName("il")
                    .IsFixedLength();

                entity.Property(e => e.Ilce)
                    .HasMaxLength(30)
                    .HasColumnName("ilce")
                    .IsFixedLength();

                entity.Property(e => e.Mail)
                    .HasMaxLength(30)
                    .HasColumnName("mail")
                    .IsFixedLength();

                entity.Property(e => e.SabitSiparisNotu)
                    .HasColumnType("text")
                    .HasColumnName("sabitSiparisNotu");

                entity.Property(e => e.Tel)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tel");

                entity.Property(e => e.VergiDairesi)
                    .HasMaxLength(50)
                    .HasColumnName("vergiDairesi");

                entity.Property(e => e.Vkn)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("vkn");
            });

            modelBuilder.Entity<TblHacim>(entity =>
            {
                entity.HasKey(e => e.HacimId);

                entity.ToTable("tbl_hacim");

                entity.Property(e => e.HacimId).HasColumnName("hacim_id");

                entity.Property(e => e.Desi).HasColumnName("desi");
            });

            modelBuilder.Entity<TblKategori>(entity =>
            {
                entity.HasKey(e => e.KategoriId);

                entity.ToTable("tbl_kategori");

                entity.Property(e => e.KategoriId).HasColumnName("kategori_id");

                entity.Property(e => e.AltKategoriId).HasColumnName("altKategori_id");

                entity.Property(e => e.Kategori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("kategori");

                entity.HasOne(d => d.AltKategori)
                    .WithMany(p => p.TblKategoris)
                    .HasForeignKey(d => d.AltKategoriId)
                    .HasConstraintName("FK_tbl_kategori_tbl_altKategori");
            });

            modelBuilder.Entity<TblKullanici>(entity =>
            {
                entity.HasKey(e => e.KullaniciId);

                entity.ToTable("tbl_kullanici");

                entity.Property(e => e.KullaniciId).HasColumnName("kullanici_id");

                entity.Property(e => e.KAd)
                    .HasMaxLength(32)
                    .HasColumnName("kAd")
                    .IsFixedLength();

                entity.Property(e => e.Sifre)
                    .HasMaxLength(32)
                    .HasColumnName("sifre")
                    .IsFixedLength();

                entity.Property(e => e.Tur).HasColumnName("tur");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("tbl_log");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.KullaniciId).HasColumnName("kullanici_id");

                entity.Property(e => e.UrunId).HasColumnName("urun_id");

                entity.Property(e => e.Zaman).HasColumnName("zaman");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.TblLogs)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_tbl_log_tbl_kullanici");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.TblLogs)
                    .HasForeignKey(d => d.UrunId)
                    .HasConstraintName("FK_tbl_log_tbl_urun");
            });

            modelBuilder.Entity<TblMagazaFiyatlari>(entity =>
            {
                entity.HasKey(e => e.MFiyatId);

                entity.ToTable("tbl_magazaFiyatlari");

                entity.Property(e => e.MFiyatId).HasColumnName("mFiyat_id");

                entity.Property(e => e.Amazon)
                    .HasColumnType("money")
                    .HasColumnName("amazon");

                entity.Property(e => e.Hepsiburada)
                    .HasColumnType("money")
                    .HasColumnName("hepsiburada");

                entity.Property(e => e.N11)
                    .HasColumnType("money")
                    .HasColumnName("n11");

                entity.Property(e => e.Trendyol)
                    .HasColumnType("money")
                    .HasColumnName("trendyol");
            });

            modelBuilder.Entity<TblMarka>(entity =>
            {
                entity.HasKey(e => e.MarkaId);

                entity.ToTable("tbl_marka");

                entity.Property(e => e.MarkaId).HasColumnName("marka_id");

                entity.Property(e => e.Marka)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marka");
            });

            modelBuilder.Entity<TblModel>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("tbl_model");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.MarkaId).HasColumnName("marka_id");

                entity.Property(e => e.Model)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.TblModels)
                    .HasForeignKey(d => d.MarkaId)
                    .HasConstraintName("FK_tbl_model_tbl_marka");
            });

            modelBuilder.Entity<TblNumara>(entity =>
            {
                entity.HasKey(e => e.NumaraId);

                entity.ToTable("tbl_numara");

                entity.Property(e => e.NumaraId).HasColumnName("numara_id");

                entity.Property(e => e.Numara).HasColumnName("numara");
            });

            modelBuilder.Entity<TblOzellikler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_ozellikler");

                entity.Property(e => e.AgirlikId).HasColumnName("agirlik_id");

                entity.Property(e => e.HacimId).HasColumnName("hacim_id");

                entity.Property(e => e.NumaraId).HasColumnName("numara_id");

                entity.Property(e => e.OzellikId).HasColumnName("ozellik_id");

                entity.Property(e => e.RenkId).HasColumnName("renk_id");

                entity.Property(e => e.Stok).HasColumnName("stok");

                entity.HasOne(d => d.Agirlik)
                    .WithMany()
                    .HasForeignKey(d => d.AgirlikId)
                    .HasConstraintName("FK_tbl_ozellikler_tbl_agirlik");

                entity.HasOne(d => d.AgirlikNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AgirlikId)
                    .HasConstraintName("FK_tbl_ozellikler_tbl_hacim");

                entity.HasOne(d => d.Numara)
                    .WithMany()
                    .HasForeignKey(d => d.NumaraId)
                    .HasConstraintName("FK_tbl_ozellikler_tbl_numara");

                entity.HasOne(d => d.Ozellik)
                    .WithMany()
                    .HasForeignKey(d => d.OzellikId)
                    .HasConstraintName("FK_tbl_ozellikler_tbl_urun");

                entity.HasOne(d => d.Renk)
                    .WithMany()
                    .HasForeignKey(d => d.RenkId)
                    .HasConstraintName("FK_tbl_ozellikler_tbl_renk");
            });

            modelBuilder.Entity<TblRenk>(entity =>
            {
                entity.HasKey(e => e.RenkId);

                entity.ToTable("tbl_renk");

                entity.Property(e => e.RenkId).HasColumnName("renk_id");

                entity.Property(e => e.Renk)
                    .HasMaxLength(25)
                    .HasColumnName("renk")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblSipari>(entity =>
            {
                entity.HasKey(e => e.SiparisId);

                entity.ToTable("tbl_siparis");

                entity.Property(e => e.SiparisId).HasColumnName("siparis_id");

                entity.Property(e => e.IptalEdilen).HasColumnName("iptalEdilen");

                entity.Property(e => e.StoktaOlmayan).HasColumnName("stoktaOlmayan");

                entity.Property(e => e.TeslimEdilen).HasColumnName("teslimEdilen");

                entity.Property(e => e.TeslimEdilmeyen).HasColumnName("teslimEdilmeyen");
            });

            modelBuilder.Entity<TblUrun>(entity =>
            {
                entity.HasKey(e => e.UrunId);

                entity.ToTable("tbl_urun");

                entity.Property(e => e.UrunId).HasColumnName("urun_id");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.AltAd)
                    .HasMaxLength(50)
                    .HasColumnName("altAd");

                entity.Property(e => e.Barkod)
                    .HasMaxLength(20)
                    .HasColumnName("barkod");

                entity.Property(e => e.DurumId).HasColumnName("durum_id");

                entity.Property(e => e.EklemeTipi)
                    .HasMaxLength(50)
                    .HasColumnName("eklemeTipi");

                entity.Property(e => e.FaturaId).HasColumnName("fatura_id");

                entity.Property(e => e.KategoriId).HasColumnName("kategori_id");

                entity.Property(e => e.MFiyatId).HasColumnName("mFiyat_id");

                entity.Property(e => e.MarkaId).HasColumnName("marka_id");

                entity.Property(e => e.OzellikId).HasColumnName("ozellik_id");

                entity.Property(e => e.Stok).HasColumnName("stok");

                entity.Property(e => e.StokDurum).HasColumnName("stokDurum");

                entity.Property(e => e.UrunAd)
                    .HasMaxLength(50)
                    .HasColumnName("urunAd");

                entity.Property(e => e.UrunDurum).HasColumnName("urunDurum");

                entity.Property(e => e.UrunKdv).HasColumnName("urunKdv");

                entity.Property(e => e.UrunKodu)
                    .HasMaxLength(20)
                    .HasColumnName("urunKodu");

                entity.Property(e => e.VaryantBarkod)
                    .HasMaxLength(20)
                    .HasColumnName("varyantBarkod");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.HasOne(d => d.Durum)
                    .WithMany(p => p.TblUruns)
                    .HasForeignKey(d => d.DurumId)
                    .HasConstraintName("FK_tbl_urun_tbl_durum");

                entity.HasOne(d => d.Fatura)
                    .WithMany(p => p.TblUruns)
                    .HasForeignKey(d => d.FaturaId)
                    .HasConstraintName("FK_tbl_urun_tbl_fatura");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.TblUruns)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_tbl_urun_tbl_kategori");

                entity.HasOne(d => d.MFiyat)
                    .WithMany(p => p.TblUruns)
                    .HasForeignKey(d => d.MFiyatId)
                    .HasConstraintName("FK_tbl_urun_tbl_magazaFiyatlari");

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.TblUruns)
                    .HasForeignKey(d => d.MarkaId)
                    .HasConstraintName("FK_tbl_urun_tbl_marka");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
