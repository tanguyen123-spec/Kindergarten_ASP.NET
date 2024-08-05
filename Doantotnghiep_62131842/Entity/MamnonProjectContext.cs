using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Doantotnghiep_62131842.Entity;

public partial class MamnonProjectContext : DbContext
{
    public MamnonProjectContext()
    {
    }

    public MamnonProjectContext(DbContextOptions<MamnonProjectContext> options)
        : base(options)
    {
    }

   

    public virtual DbSet<ChitietgiaovienLop> ChitietgiaovienLops { get; set; }

    public virtual DbSet<Chude> Chudes { get; set; }

    public virtual DbSet<Danhmonantheongay> Danhmonantheongays { get; set; }

    public virtual DbSet<Donnhaphoc> Donnhaphocs { get; set; }

    public virtual DbSet<DsthucDon> DsthucDons { get; set; }

    public virtual DbSet<Giaovien> Giaoviens { get; set; }

    public virtual DbSet<Hoatdong> Hoatdongs { get; set; }

    public virtual DbSet<Hocvien> Hocviens { get; set; }

    public virtual DbSet<ImagesTinhtrangsuckhoe> ImagesTinhtrangsuckhoes { get; set; }

    public virtual DbSet<Loaigiaovien> Loaigiaoviens { get; set; }

    public virtual DbSet<Loailop> Loailops { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Phieubengoan> Phieubengoans { get; set; }

    public virtual DbSet<Phieudiemdanh> Phieudiemdanhs { get; set; }

    public virtual DbSet<Phuhuynh> Phuhuynhs { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Suckhoedinhki> Suckhoedinhkis { get; set; }

    public virtual DbSet<Thoikhoabieu> Thoikhoabieus { get; set; }

    public virtual DbSet<Tiethoc> Tiethocs { get; set; }

    public virtual DbSet<Tinhtrangsuckhoe> Tinhtrangsuckhoes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Ykien> Ykiens { get; set; }
    public DbSet<Hoatdongchinh> Hoatdongchinhs { get; set; }
    public DbSet<Chiphichinh> Chiphichinhs { get; set; }

    public DbSet<Chiphiphu> Chiphiphus { get; set; }

    public DbSet<Bienlai> Bienlais { get; set; }
    public DbSet<BFdataset> BFdatasets { get; set; }
    public DbSet<Lunchdataset> Lunchdatasets { get; set; }
    public DbSet<AFnoondataset> AFnoondatasets { get; set; }
    public DbSet<Desertdataset> Desertdatasets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9DIIF9V;Initial Catalog=MamnonProject;Integrated Security=True; TrustServerCertificate=True");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<ChitietgiaovienLop>(entity =>
        {
            entity.HasKey(e => e.ChitietgvLId).HasName("PK__chitietg__CB1D01924CCC8BAE");

            entity.ToTable("chitietgiaovien_lop");

            entity.Property(e => e.ChitietgvLId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Chitietgv_lID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Namhoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("namhoc");

            entity.HasOne(d => d.Class).WithMany(p => p.ChitietgiaovienLops)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__chitietgi__Class__5AEE82B9");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.ChitietgiaovienLops)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__chitietgi__Magia__59FA5E80");
        });
        modelBuilder.Entity<BFdataset>(entity =>
        {
            entity.HasKey(e => e.BFastid).HasName("PK_BFdataset");

            entity.ToTable("BFdataset");

            entity.Property(e => e.BFastid)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FoodBF)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"

        entity.Property(e => e.tpdduongBF)
            .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"
        });

        modelBuilder.Entity<Lunchdataset>(entity =>
        {
            entity.HasKey(e => e.LunchId).HasName("PK_Lunchdataset");

            entity.ToTable("Lunchdataset");

            entity.Property(e => e.LunchId)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FoodLunch)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"

            entity.Property(e => e.tpdduongL)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"
        });

        modelBuilder.Entity<AFnoondataset>(entity =>
        {
            entity.HasKey(e => e.AFnoonid).HasName("PK_AFnoondataset");

            entity.ToTable("AFnoondataset");

            entity.Property(e => e.AFnoonid)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FoodAF)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"

            entity.Property(e => e.tpdduongAF)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"
        });

        modelBuilder.Entity<Desertdataset>(entity =>
        {
            entity.HasKey(e => e.DSertid).HasName("PK_Desertdataset");

            entity.ToTable("Desertdataset");

            entity.Property(e => e.DSertid)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FoodDS)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"

            entity.Property(e => e.tpdduongDS)
                .HasColumnType("nvarchar(MAX)"); // Thay đổi kiểu dữ liệu thành "text"
        });
        modelBuilder.Entity<Chude>(entity =>
        {
            entity.HasKey(e => e.Machude).HasName("PK__Chude__3B703D0CBF7CF768");

            entity.ToTable("Chude");

            entity.Property(e => e.Machude)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("machude");
            entity.Property(e => e.Tenchude)
                .HasMaxLength(30)
                .HasColumnName("tenchude");
        });
        modelBuilder.Entity<Chiphichinh>(entity =>
        {
            entity.HasKey(e => e.Machiphichinh).HasName("PK__Chiphichinh__3B703D0CBF7CF768");

            entity.ToTable("Chiphichinh");

            entity.Property(e => e.Machiphichinh)
                .HasColumnName("machiphichinh");

            entity.Property(e => e.Mahoatdong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mahoatdong");

            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.thang_namhoc)
               .HasMaxLength(10)
               .IsUnicode(false)
               .HasColumnName("thang_namhoc");

           
            entity.HasOne(e => e.Hoatdong)
                .WithMany()
                .HasForeignKey(e => e.Mahoatdong)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.hocvien)
                .WithMany()
                .HasForeignKey(e => e.ChildResumeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Bienlai>(entity =>
        {
            entity.HasKey(e => e.Mabienlai);
            entity.ToTable("Bienlai");

            entity.Property(e => e.Mabienlai)
                .HasMaxLength(10)
                .IsRequired();

            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsRequired();

            entity.Property(e => e.tongchiphiphaitra)
                .IsRequired();

            entity.Property(e => e.trangthai)
                .IsRequired();
            entity.Property(e => e.thang_namhoc)
            .IsRequired();

            entity.HasOne(e => e.Hocvien)
                .WithOne()
                .HasForeignKey<Bienlai>(e => e.ChildResumeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Hocvien>(entity =>
        {
            entity.HasKey(e => e.ChildResumeId);
            // Định nghĩa các thuộc tính khác của bảng Hocvien

        });
        modelBuilder.Entity<Danhmonantheongay>(entity =>
        {
            entity.HasKey(e => e.Malichngay).HasName("PK__Danhmona__A3162DB41A6B35E6");

            entity.ToTable("Danhmonantheongay");

            entity.Property(e => e.Malichngay)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Buoichieu)
                .HasMaxLength(100)
                .HasColumnName("buoichieu");
            entity.Property(e => e.Buoisang)
                .HasMaxLength(100)
                .HasColumnName("buoisang");
            entity.Property(e => e.Buoitrua)
                .HasMaxLength(100)
                .HasColumnName("buoitrua");
            entity.Property(e => e.MenuId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Menu_ID");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("ngay");
            entity.Property(e => e.Trangmieng)
                .HasMaxLength(100)
                .HasColumnName("trangmieng");

            entity.HasOne(d => d.Menu).WithMany(p => p.Danhmonantheongays)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__Danhmonan__Menu___5165187F");
        });

        modelBuilder.Entity<Donnhaphoc>(entity =>
        {
            entity.HasKey(e => e.AfaId).HasName("PK__Donnhaph__2936EA35D0ABCAF8");

            entity.ToTable("Donnhaphoc");

            entity.Property(e => e.AfaId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AFA_ID");
            entity.Property(e => e.Batdauhoc)
                .HasColumnType("datetime")
                .HasColumnName("batdauhoc");
            entity.Property(e => e.Lophocmongmuon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lophocmongmuon");
            entity.Property(e => e.Namhoc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("namhoc");
            entity.Property(e => e.Ngaytaodon).HasColumnType("datetime");
            entity.Property(e => e.SdtLienhe)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Sdt_lienhe");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<DsthucDon>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__DSThucDo__69E7231872E0A6D3");

            entity.ToTable("DSThucDon");

            entity.Property(e => e.MenuId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Menu_ID");
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("datetime")
                .HasColumnName("ngaybatdau");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("datetime")
                .HasColumnName("ngayketthuc");
        });

        modelBuilder.Entity<Giaovien>(entity =>
        {
            entity.HasKey(e => e.Magiaovien).HasName("PK__Giaovien__38993AE7A5975DCD");

            entity.ToTable("Giaovien");

            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Diachi)
                .HasMaxLength(30)
                .HasColumnName("diachi");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Maloaigiaovien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maloaigiaovien");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sodienthoai");
            entity.Property(e => e.Tengiaovien).HasMaxLength(20);

            entity.HasOne(d => d.MaloaigiaovienNavigation).WithMany(p => p.Giaoviens)
                .HasForeignKey(d => d.Maloaigiaovien)
                .HasConstraintName("FK__Giaovien__maloai__398D8EEE");
        });

        modelBuilder.Entity<Hoatdong>(entity =>
        {
            entity.HasKey(e => e.Mahoatdong).HasName("PK__Hoatdong__698E65434BF059F9");

            entity.ToTable("Hoatdong");

            entity.Property(e => e.Mahoatdong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Chiphi).HasColumnName("chiphi");
            entity.Property(e => e.Tenhoatdong)
                .HasMaxLength(100)
                .HasColumnName("tenhoatdong");
        });
        modelBuilder.Entity<Hoatdongchinh>(entity =>
        {
            entity.HasKey(e => e.MaHoatdongchinh).HasName("PK_Hoatdongchinh");

            entity.ToTable("Hoatdongchinh");

            entity.Property(e => e.MaHoatdongchinh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maHoatdongchinh");

            entity.Property(e => e.Mahoatdong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mahoatdong");
        });
        modelBuilder.Entity<Hocvien>(entity =>
        {
            entity.HasKey(e => e.ChildResumeId).HasName("PK__Hocvien__7FE0700297BEBB61");

            entity.ToTable("Hocvien");

            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.AfaId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AFA_ID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.CurrentHealthStatus)
                .HasMaxLength(100)
                .HasColumnName("current_health_status");
            entity.Property(e => e.Diachi)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("diachi");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InformationDif)
                .HasMaxLength(100)
                .HasColumnName("information_dif");
            entity.Property(e => e.MedicalHistory)
                .HasMaxLength(100)
                .HasColumnName("medical_history");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Parent_resume_ID");

            entity.HasOne(d => d.Afa).WithMany(p => p.Hocviens)
                .HasForeignKey(d => d.AfaId)
                .HasConstraintName("FK__Hocvien__AFA_ID__45F365D3");

            entity.HasOne(d => d.Class).WithMany(p => p.Hocviens)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Hocvien__ClassID__46E78A0C");

            entity.HasOne(d => d.ParentResume).WithMany(p => p.Hocviens)
                .HasForeignKey(d => d.ParentResumeId)
                .HasConstraintName("FK__Hocvien__Parent___44FF419A");
        });

        modelBuilder.Entity<ImagesTinhtrangsuckhoe>(entity =>
        {
            entity.HasKey(e => e.ImagesTinhtrangsuckhoeId).HasName("PK__ImagesTi__DC283E3D8724F0C3");

            entity.ToTable("ImagesTinhtrangsuckhoe");

            entity.Property(e => e.ImagesTinhtrangsuckhoeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ImagesTinhtrangsuckhoeID");

            entity.Property(e => e.TtskId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ttsk_id");

            entity.Property(e => e.LinkImage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LinkUrl");

            entity.HasOne(d => d.Ttsk).WithMany(p => p.ImagesTinhtrangsuckhoes)
                .HasForeignKey(d => d.TtskId)
                .HasConstraintName("FK__ImagesTin__ttsk___656C112C");
        });

        modelBuilder.Entity<Loaigiaovien>(entity =>
        {
            entity.HasKey(e => e.Maloaigiaovien).HasName("PK__Loaigiao__F615CD290B497571");

            entity.ToTable("Loaigiaovien");

            entity.Property(e => e.Maloaigiaovien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maloaigiaovien");
            entity.Property(e => e.Tenloaigiaovien)
                .HasMaxLength(20)
                .HasColumnName("tenloaigiaovien");
        });

        modelBuilder.Entity<Loailop>(entity =>
        {
            entity.HasKey(e => e.ClasstypeId).HasName("PK__Loailop__A454543F9567BAAA");

            entity.ToTable("Loailop");

            entity.Property(e => e.ClasstypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Classtype_ID");
            entity.Property(e => e.NameClasstype)
                .HasMaxLength(30)
                .HasColumnName("Name_classtype");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Lop__CB1927A05562A173");

            entity.ToTable("Lop");

            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.ClasstypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Classtype_ID");
            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .HasColumnName("Name_class");
            entity.Property(e => e.Namhoc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("namhoc");
            entity.Property(e => e.Siso).HasColumnName("siso");

            entity.HasOne(d => d.Classtype).WithMany(p => p.Lops)
                .HasForeignKey(d => d.ClasstypeId)
                .HasConstraintName("FK__Lop__Classtype_I__403A8C7D");
        });

        modelBuilder.Entity<Phieubengoan>(entity =>
        {
            entity.HasKey(e => e.PhbnId).HasName("PK__Phieuben__AC209BDBB35BB4E5");

            entity.ToTable("Phieubengoan");

            entity.Property(e => e.PhbnId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHBN_ID");
            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.Hanhvi)
                .HasMaxLength(100)
                .HasColumnName("hanhvi");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ngaydanhgia).HasColumnType("datetime");
            entity.Property(e => e.Thaido)
                .HasMaxLength(100)
                .HasColumnName("thaido");
            entity.Property(e => e.Thanhtich)
                .HasMaxLength(100)
                .HasColumnName("thanhtich");

            entity.HasOne(d => d.ChildResume).WithMany(p => p.Phieubengoans)
                .HasForeignKey(d => d.ChildResumeId)
                .HasConstraintName("FK__Phieubeng__Child__5DCAEF64");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.Phieubengoans)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__Phieubeng__Magia__5EBF139D");
        });

        modelBuilder.Entity<Phieudiemdanh>(entity =>
        {
            entity.HasKey(e => e.DiemdanhId).HasName("PK__Phieudie__0AEC22A8655AA399");

            entity.ToTable("Phieudiemdanh");

            entity.Property(e => e.DiemdanhId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diemdanh_id");
            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.Namhoc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("namhoc");
            entity.Property(e => e.Ngayhoc)
                .HasColumnType("datetime")
                .HasColumnName("ngayhoc");
            entity.Property(e => e.thang_namhoc)
               
               .HasColumnName("thang_namhoc");

            entity.HasOne(d => d.ChildResume).WithMany(p => p.Phieudiemdanhs)
                .HasForeignKey(d => d.ChildResumeId)
                .HasConstraintName("FK__Phieudiem__Child__68487DD7");
        });

        modelBuilder.Entity<Phuhuynh>(entity =>
        {
            entity.HasKey(e => e.ParentResumeId).HasName("PK__Phuhuynh__42CFE641FFCBACBF");

            entity.ToTable("Phuhuynh");

            entity.Property(e => e.ParentResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Parent_resume_ID");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.Diachi)
                .HasMaxLength(30)
                .HasColumnName("diachi");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.JobParent)
                .HasMaxLength(100)
                .HasColumnName("Job_parent");
            entity.Property(e => e.NameP).HasMaxLength(20);
            entity.Property(e => e.NameP2).HasMaxLength(20);
            entity.Property(e => e.NumberOfChildren).HasColumnName("number_of_children");
            entity.Property(e => e.Phone1)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Phone2)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.JwtId).HasColumnName("JwtID");
            entity.Property(e => e.NguoidungUsername)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.NguoidungUsernameNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.NguoidungUsername)
                .HasConstraintName("FK_RefreshTokens_Nguoidung_Username");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3ACB81125A");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RoleID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Suckhoedinhki>(entity =>
        {
            entity.HasKey(e => e.SkdkId).HasName("PK__Suckhoed__0D4A67825ED6C99D");

            entity.ToTable("Suckhoedinhki");

            entity.Property(e => e.SkdkId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("skdk_id");
            entity.Property(e => e.Benhlykhac)
                .HasMaxLength(100)
                .HasColumnName("benhlykhac");
            entity.Property(e => e.Cannang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cannang");
            entity.Property(e => e.Chieucao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("chieucao");
            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.Ghichubacsy)
                .HasMaxLength(100)
                .HasColumnName("ghichubacsy");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.Ngaykiemtra)
                .HasColumnType("datetime")
                .HasColumnName("ngaykiemtra");

            entity.HasOne(d => d.ChildResume).WithMany(p => p.Suckhoedinhkis)
                .HasForeignKey(d => d.ChildResumeId)
                .HasConstraintName("FK__Suckhoedi__Child__571DF1D5");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.Suckhoedinhkis)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__Suckhoedi__Magia__5629CD9C");
        });

        modelBuilder.Entity<Thoikhoabieu>(entity =>
        {
            entity.HasKey(e => e.Matkb).HasName("PK__Thoikhoa__1489A4D151953889");

            entity.ToTable("Thoikhoabieu");

            entity.Property(e => e.Matkb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkb");
            entity.Property(e => e.ClassId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClassID");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("datetime")
                .HasColumnName("ngaybatdau");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("datetime")
                .HasColumnName("ngayketthuc");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.Thoikhoabieus)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__Thoikhoab__Magia__6FE99F9F");
        });

        modelBuilder.Entity<Tiethoc>(entity =>
        {
            entity.HasKey(e => e.Tiethocid).HasName("PK__Tiethoc__FB62F9B479824779");

            entity.ToTable("Tiethoc");

            entity.Property(e => e.Tiethocid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tiethocid");
            entity.Property(e => e.Matkb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkb");
            entity.Property(e => e.Ngayhoc)
                .HasColumnType("datetime")
                .HasColumnName("ngayhoc");
            entity.Property(e => e.Thoigianbatdauhoc)
                .HasColumnType("datetime")
                .HasColumnName("thoigianbatdauhoc");
            entity.Property(e => e.Thoigianketthuchoc)
                .HasColumnType("datetime")
                .HasColumnName("thoigianketthuchoc");
            entity.Property(e => e.Tieuthoc)
                .HasMaxLength(30)
                .HasColumnName("tieuthoc");

            entity.HasOne(d => d.MatkbNavigation).WithMany(p => p.Tiethocs)
                .HasForeignKey(d => d.Matkb)
                .HasConstraintName("FK__Tiethoc__matkb__72C60C4A");
        });

        modelBuilder.Entity<Tinhtrangsuckhoe>(entity =>
        {
            entity.HasKey(e => e.TtskId).HasName("PK__Tinhtran__43E94AF57479EDED");

            entity.ToTable("Tinhtrangsuckhoe");

            entity.Property(e => e.TtskId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ttsk_id");
            entity.Property(e => e.ChildResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Child_resume_ID");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ngaykiemtra)
                .HasColumnType("datetime")
                .HasColumnName("ngaykiemtra");
            entity.Property(e => e.Nhietdo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("nhietdo");
            entity.Property(e => e.Thaidohochanh)
                .HasMaxLength(20)
                .HasColumnName("thaidohochanh");
            entity.Property(e => e.Trangthaian)
                .HasMaxLength(20)
                .HasColumnName("trangthaian");
            entity.Property(e => e.Trangthaingu)
                .HasMaxLength(20)
                .HasColumnName("trangthaingu");

            entity.HasOne(d => d.ChildResume).WithMany(p => p.Tinhtrangsuckhoes)
                .HasForeignKey(d => d.ChildResumeId)
                .HasConstraintName("FK__Tinhtrang__Child__619B8048");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.Tinhtrangsuckhoes)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__Tinhtrang__Magia__628FA481");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF730E990");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ParentResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Parent_resume_ID");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__Users__Magiaovie__787EE5A0");

            entity.HasOne(d => d.ParentResume).WithMany(p => p.Users)
                .HasForeignKey(d => d.ParentResumeId)
                .HasConstraintName("FK__Users__Parent_re__797309D9");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__778AC167");
        });

        modelBuilder.Entity<Ykien>(entity =>
        {
            entity.HasKey(e => e.OpinionId).HasName("PK__Ykien__3906968FA209ED15");

            entity.ToTable("Ykien");

            entity.Property(e => e.OpinionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("opinion_ID");
            entity.Property(e => e.Giaiphap)
                .HasMaxLength(200)
                .HasColumnName("giaiphap");
            entity.Property(e => e.Machude)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("machude");
            entity.Property(e => e.NoteOpinion)
                .HasMaxLength(100)
                .HasColumnName("Note_Opinion");
            entity.Property(e => e.ParentResumeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Parent_resume_ID");

            entity.HasOne(d => d.MachudeNavigation).WithMany(p => p.Ykiens)
                .HasForeignKey(d => d.Machude)
                .HasConstraintName("FK__Ykien__machude__4BAC3F29");

            entity.HasOne(d => d.ParentResume).WithMany(p => p.Ykiens)
                .HasForeignKey(d => d.ParentResumeId)
                .HasConstraintName("FK__Ykien__Parent_re__4CA06362");
        });
        modelBuilder.Entity<Chiphiphu>(entity =>
        {
            entity.ToTable("Chiphiphu");

            entity.HasKey(e => e.Machiphiphu);

            entity.Property(e => e.Machiphiphu)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("varchar(10)");

            entity.Property(e => e.Mahoatdong)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("varchar(10)");

            entity.Property(e => e.Child_resume_id)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("varchar(10)");

            entity.Property(e => e.Thang_namhoc)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("varchar(10)");

            // Định nghĩa các quan hệ hoặc ràng buộc khác (nếu có)
            entity.HasOne(e => e.Hoatdong)
                .WithMany()
                .HasForeignKey(e => e.Mahoatdong)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Hocvien)
                .WithMany()
                .HasForeignKey(e => e.Child_resume_id)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
