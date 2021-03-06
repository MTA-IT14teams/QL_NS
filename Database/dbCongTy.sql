
ALTER DATABASE [CongTy] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CongTy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CongTy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CongTy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CongTy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CongTy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CongTy] SET ARITHABORT OFF 
GO
ALTER DATABASE [CongTy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CongTy] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CongTy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CongTy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CongTy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CongTy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CongTy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CongTy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CongTy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CongTy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CongTy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CongTy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CongTy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CongTy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CongTy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CongTy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CongTy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CongTy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CongTy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CongTy] SET  MULTI_USER 
GO
ALTER DATABASE [CongTy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CongTy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CongTy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CongTy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CongTy]
GO
/****** Object:  StoredProcedure [dbo].[DSNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DSNV](@TENPB nvarchar(50))
as
begin
	declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
end

GO
/****** Object:  StoredProcedure [dbo].[DSNV1]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DSNV1](@TENPB nvarchar(50))
as
begin
	declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
	select MaNV, TenNV from NhanVien where MaPB = @MAMB
end

GO
/****** Object:  StoredProcedure [dbo].[DSNV2]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DSNV2](@TENPB nvarchar(50))
as
begin
	/*declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
	select MaNV, TenNV from NhanVien where MaPB =  @MAMB*/
	select MaNV, TenNV, nv.MaPB 
	from NhanVien nv, PhongBan pb
	where nv.MaPB = pb.MaPB and TenPB = @TENPB

end

GO
/****** Object:  StoredProcedure [dbo].[DSNV3]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DSNV3](@TENPB nvarchar(50))
as
begin
	/*declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
	select MaNV, TenNV from NhanVien where MaPB =  @MAMB*/
	select MaNV, TenNV
	from NhanVien nv, PhongBan pb
	where nv.MaPB = pb.MaPB and pb.TenPB = @TENPB

end

GO
/****** Object:  StoredProcedure [dbo].[DSNV4]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Tạo thủ tục đưa ra danh sách nhân viên của phòng ban có tên gì đấy
create Procedure [dbo].[DSNV4](@TENPB nvarchar(50))
as
begin
	declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
	select MaNV, TenNV from NhanVien where MaPB =  @MAMB
	/*select MaNV, TenNV
	from NhanVien nv, PhongBan pb
	where nv.MaPB = pb.MaPB and pb.TenPB = @TENPB*/

end


GO
/****** Object:  StoredProcedure [dbo].[THEMPB1]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[THEMPB1](@MAPB CHAR(10), @TENPB NVARCHAR(50) )
AS 
BEGIN 
INSERT INTO PhongBan(MaPB, TenPB)
VALUES (@MAPB, @TENPB)
END

GO
/****** Object:  StoredProcedure [dbo].[TimDSNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[TimDSNV](@TENPB nvarchar(50))
as
begin
	declare @MAMB char(10)
	select @MAMB = MaPB
	from PhongBan
	where TenPB = @TENPB
	select MaNV, TenNV from NhanVien where MaPB =  @MAMB
END

GO
/****** Object:  UserDefinedFunction [dbo].[F_TongNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[F_TongNV] (@TENPB nvarchar(50))
returns @Bang table
(
	MaPB char(10),
	TenPB nvarchar(50),
	TongNV int
)
as 
begin 
declare @dem  int
select @dem = count(*) from PhongBan where TenPB = @TENPB
if(@TENPB = '') or (@TENPB is NULL) or (@dem = 0)
	insert into @Bang
	select pb.MaPB, TenPB, count(MaNV)
	from PhongBan pb, NhanVien nv
	where pb.MaPB = nv.MaPB
	group by pb.MaPB, TenPB
else
	insert into @Bang
	select pb.MaPB, TenPB, count(MaNV)
	from PhongBan pb, NhanVien nv
	where pb.MaPB = nv.MaNV and TenPB = @TENPB
	group by pb.MaPB, TenPB

return
end

GO
/****** Object:  UserDefinedFunction [dbo].[F2_DSNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[F2_DSNV] (@TENPB nvarchar(50))
 returns @Bang table
	(
	MAnv char(10),
	TENnv nvarchar(50) 
	)
as
begin
	declare @MAPB char(10)
	select @MAPB = MaPB
	from PhongBan
	where TenPB = @TENPB		
	insert into @Bang
	select MaNV, TenNV
	from NhanVien
	where MaPB = @MAPB
	return
		
end

GO
/****** Object:  UserDefinedFunction [dbo].[F3_DSNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[F3_DSNV] (@TENPB nvarchar(50))
 returns @Bang table
	(
	MAnv char(10),
	TENnv nvarchar(50) 
	)
as
begin

if (@TenPB is NULL)
	insert into @Bang(MAnv, TENnv)
	select MaNV, TenNV
	from NhanVien
ELSE 
	declare @MAPB char(10)
	select @MAPB = MaPB
	from PhongBan
	where TenPB = @TENPB 		
	insert into @Bang
	select MaNV, TenNV
	from NhanVien
	where MaPB = @MAPB

return	
end

GO
/****** Object:  UserDefinedFunction [dbo].[F3_DSNV1]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[F3_DSNV1] (@TENPB nvarchar(50))
 returns @Bang table
	(
	MAnv char(10),
	TENnv nvarchar(50) 
	)
as
begin

if (@TenPB is NULL)
	insert into @Bang
	select MaNV, TenNV
	from NhanVien
ELSE 
	declare @MAPB char(10)
	select @MAPB = MaPB
	from PhongBan
	where TenPB = @TENPB 		
	insert into @Bang
	select MaNV, TenNV
	from NhanVien
	where MaPB = @MAPB

return	
end

GO
/****** Object:  UserDefinedFunction [dbo].[thu]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[thu](@ngay DateTime) returns nvarchar(50)
as
begin
Declare @st nvarchar(50)
select @st = case DATEPART(DW, @ngay)
when 1 then 'chủ nhật'
when 2 then 'thứ hai'
when 3 then 'thứ ba' end
return (@st)
end

GO
/****** Object:  UserDefinedFunction [dbo].[thu1]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[thu1](@ngay DateTime) returns nvarchar(50)
as
begin
Declare @st nvarchar(50)
select @st = case DATEPART(DW, @ngay)
when 1 then 'chủ nhật'
when 2 then 'thứ hai'
when 3 then 'thứ ba'
when 4 then 'thứ tư'
when 5 then 'thứ năm'
when 6 then 'thứ sáu' 
else 'thứ bảy' end
return @st
end

GO
/****** Object:  UserDefinedFunction [dbo].[thu2]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[thu2](@ngay DateTime) returns nvarchar(10)
as
begin
Declare @st nvarchar(10)
select @st = case DATEPART(DW, @ngay)
when 1 then 'chủ nhật'
when 2 then 'thứ hai'
when 3 then 'thứ ba'
when 4 then 'thứ tư'
when 5 then 'thứ năm'
when 6 then 'thứ sáu' 
else 'thứ bảy' end
return @st
end

GO
/****** Object:  UserDefinedFunction [dbo].[thu3]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[thu3](@ngay Datetime) returns nvarchar(10)
as
begin
Declare @st nvarchar(10)
select @st = case DATEPART(DW, @ngay)
when 1 then 'chủ nhật'
when 2 then 'thứ hai'
when 3 then 'thứ ba'
when 4 then 'thứ tư'
when 5 then 'thứ năm'
when 6 then 'thứ sáu' 
else 'thứ bảy' end
return @st
end

GO
/****** Object:  Table [dbo].[DuAn]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DuAn](
	[MaDA] [char](10) NOT NULL,
	[TenDA] [nvarchar](10) NULL,
	[DiaDiem] [nvarchar](50) NULL,
	[MaPB] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [char](10) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Luong] [int] NULL,
	[MaNGS] [char](10) NULL,
	[MaPB] [char](10) NULL,
 CONSTRAINT [PK__NhanVien__2725D70A6134B24A] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaNV] [char](10) NULL,
	[MaDA] [char](10) NULL,
	[SoGio] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [char](10) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[MaTP] [char](10) NULL,
	[DiaDiem] [nvarchar](50) NULL,
	[NgayNC] [nvarchar](50) NULL,
 CONSTRAINT [PK__PhongBan__2725E7E448C8C288] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_users](
	[id_user] [int] NULL,
	[user_name] [varchar](50) NULL,
	[pass] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[F_DANV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[F_DANV] (@TENPB nvarchar(50)) returns table
as
return
(
	select MaNV, TenNV, pb.MaPB 
	from NhanVien nv, PhongBan pb
	where nv.MaPB = pb.MaPB and TenPB = @TENPB
)

GO
/****** Object:  UserDefinedFunction [dbo].[Func_XemNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[Func_XemNV] (@maphong char(10)) returns table
as
return(select MANV, TenNV 
from NhanVien inner join PhongBan
on NhanVien.MaPB = PhongBan.MaPB
where NhanVien.MaPB = @maphong)

GO
/****** Object:  UserDefinedFunction [dbo].[TongNV]    Script Date: 08/06/2018 09:25:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[TongNV] (@maphong char(10)) returns table
as
return(
 select PhongBan.MaPB, TenPB, count(MaNV) as sonv
 from NhanVien, PhongBan
 where PhongBan.MaPB = @maphong and PhongBan.MaPB = NhanVien.MaPB
 group by PhongBan.MaPB, TenPB
)

GO
INSERT [dbo].[DuAn] ([MaDA], [TenDA], [DiaDiem], [MaPB]) VALUES (N'da001     ', N'Dự Án 1', N'Bắc Từ Liêm', N'pb001     ')
INSERT [dbo].[DuAn] ([MaDA], [TenDA], [DiaDiem], [MaPB]) VALUES (N'da002     ', N'Dự Án 2', N'Bắc Từ Liêm', N'pb002     ')
INSERT [dbo].[DuAn] ([MaDA], [TenDA], [DiaDiem], [MaPB]) VALUES (N'da003     ', N'Dự Án 3', N'Cầu Giấy', N'pb003     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv001     ', N'Vũ Mạnh Tuấn', N'Nam       ', CAST(0x26200B00 AS Date), N'Kiều Mai - Hà Nội', 22500501, N'nv002     ', N'pb001     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv002     ', N'Đàm Ngọc Thiện', N'Nam       ', CAST(0x1A200B00 AS Date), N'Hoài Đức - Hà Nội', 22500501, N'nv001     ', N'pb001     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv003     ', N'Nguyễn Văn Giáp', N'Nam       ', CAST(0xFE1F0B00 AS Date), N'Bắc Từ Liêm - Hà Nội', 61500501, N'nv002     ', N'pb001     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv004     ', N'Đào Thanh Tú', N'Nu        ', CAST(0xC31F0B00 AS Date), N'Cầu Giấy - Hà Nội', 20500501, N'nv002     ', N'pb001     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv005     ', N'Thạch Thùy Chinh', N'Nu        ', CAST(0xEC1F0B00 AS Date), N'Cầu Giấy - Hà Nội', 18500501, N'nv002     ', N'pb002     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv006     ', N'Nguyễn Văn An', N'Nam       ', CAST(0x7E1E0B00 AS Date), N'Nam Từ Liêm - Hà Nội', 18500501, N'nv002     ', N'pb002     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv007     ', N'Nguyễn Thanh Bình', N'Nam       ', CAST(0xF71E0B00 AS Date), N'Đống Đa - Hà Nội', 21500501, N'nv002     ', N'pb002     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv008     ', N'Nguyễn Thị Hạnh', N'Nu        ', CAST(0x461F0B00 AS Date), N'Đống Đa - Hà Nội', 21500501, N'nv002     ', N'pb002     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv009     ', N'Nguyễn Thị Linh', N'Nam       ', CAST(0x831F0B00 AS Date), N'Cổ Nhuế - Hà Nội', 21500501, N'nv002     ', N'pb002     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv010     ', N'Hoàng Văn Long', N'Nam       ', CAST(0x17210B00 AS Date), N'Hoàn Kiếm - Hà Nội', 10100051, N'nv002     ', N'pb003     ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [Luong], [MaNGS], [MaPB]) VALUES (N'nv0101    ', N'Hoàng Văn Long', N'Nam       ', CAST(0x17210B00 AS Date), N'Hoàn Kiếm - Hà Nội', 10100051, N'nv002     ', N'pb003     ')
INSERT [dbo].[PhanCong] ([MaNV], [MaDA], [SoGio]) VALUES (N'nv001     ', N'da001     ', 10)
INSERT [dbo].[PhanCong] ([MaNV], [MaDA], [SoGio]) VALUES (N'nv002     ', N'da001     ', 10)
INSERT [dbo].[PhanCong] ([MaNV], [MaDA], [SoGio]) VALUES (N'nv001     ', N'da002     ', 10)
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb001     ', N'Phòng Kỹ Thuật', N'nv001     ', N'Cầu Giấy', N'12-Oct-14')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb002     ', N'Phòng kinh doanh', N'nv002     ', N'Cầu Giấy', N'2018-10-12')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb003     ', N'Phòng thiết kế', N'nv003     ', N'Cầu Giấy', N'12-Oct-17')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb004     ', N'Phòng kiểm toán', N'nv003     ', N'Cầu Giấy', N'12-Oct-17')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb005     ', N'Phòng Kế Toán', N'nv004     ', N'Cầu Giấy', N'12-Oct-14')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb009     ', N'Phòng Kỹ Thuật ưewq', N'nv001     ', N'Cầu Giấy', N'12-Oct-14')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [MaTP], [DiaDiem], [NgayNC]) VALUES (N'pb01      ', N'aaaaa', N'nv01      ', N'HN', NULL)
INSERT [dbo].[tbl_users] ([id_user], [user_name], [pass]) VALUES (1, N'admin', N'1')
ALTER TABLE [dbo].[DuAn]  WITH CHECK ADD  CONSTRAINT [FK__DuAn__MaPB__164452B1] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[DuAn] CHECK CONSTRAINT [FK__DuAn__MaPB__164452B1]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaPB__1CF15040] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaPB__1CF15040]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaDA])
REFERENCES [dbo].[DuAn] ([MaDA])
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK__PhanCong__MaNV__22AA2996] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK__PhanCong__MaNV__22AA2996]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [CK__NhanVien__GioiTi__1BFD2C07] CHECK  (([GioiTinh]='Nu' OR [GioiTinh]='Nam'))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [CK__NhanVien__GioiTi__1BFD2C07]
GO
USE [master]
GO
ALTER DATABASE [CongTy] SET  READ_WRITE 
GO
