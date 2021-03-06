create database  QL_NhanSu 
go

USE [QL_NHANSU]
GO
/****** Object:  Table [dbo].[DUAN]    Script Date: 03/05/2018 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DUAN](
	[MADA] [char](10) NOT NULL,
	[TENDA] [nvarchar](50) NULL,
	[DIADIEM] [nvarchar](50) NULL,
	[MAPB] [char](10) NULL,
	[TONGSOGIO] [float] NULL,
 CONSTRAINT [PK_DUAN] PRIMARY KEY CLUSTERED 
(
	[MADA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_THEMDUAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ tục thêm mới DỰ ÁN*/ 
CREATE PROC [dbo].[SP_THEMDUAN]
(    @MADA char(10),
     @TENDA nvarchar(50),
     @DIADIEM NVARCHAR(50),
     @MAPB CHAR(10),
     @TONGSOGIO FLOAT
  ) 
AS 
INSERT INTO DUAN(MADA,TENDA,DIADIEM,MAPB,TONGSOGIO) 
VALUES(@MADA,@TENDA,@DIADIEM,@MAPB,@TONGSOGIO)
GO
/****** Object:  StoredProcedure [dbo].[SP_XOADUAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ xóa một DỰ ÁN*/ 
CREATE PROC [dbo].[SP_XOADUAN]
( 
     @MADA char(10) 
) 
AS 
DELETE DUAN 
WHERE MADA = @MADA
GO
/****** Object:  StoredProcedure [dbo].[SP_SUADUAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[SP_SUADUAN]
( 
     @MADA char(10),
     @TENDA nvarchar(50),
     @DIADIEM NVARCHAR(50),
     @MAPB CHAR(10),
     @TONGSOGIO FLOAT 
     ) 
AS 
UPDATE DUAN 
SET TENDA = @TENDA, DIADIEM = @DIADIEM,MAPB = @MAPB 
 WHERE MADA = @MADA
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [char](10) NOT NULL,
	[TENNV] [nvarchar](50) NULL,
	[NGAYSINH] [date] NULL,
	[GT] [nvarchar](50) NULL,
	[MANGS] [char](10) NULL,
	[MAPB] [char](10) NULL,
	[BACLUONG] [int] NULL,
	[QUEQUAN] [nvarchar](50) NULL,
	[ACCOUNT] [varchar](50) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MAPB] [char](10) NOT NULL,
	[TENPB] [nvarchar](50) NULL,
	[MATP] [char](10) NULL,
	[DIADIEM] [nvarchar](50) NULL,
	[NGAYNC] [date] NULL,
 CONSTRAINT [PK_PHONGBAN] PRIMARY KEY CLUSTERED 
(
	[MAPB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_THEMPHONGBAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ tục thêm mới phòng ban*/ 
CREATE PROC [dbo].[SP_THEMPHONGBAN]
(    @MAPB char(10), 
     @TENPB nvarchar(50),
     @MATP CHAR(10),
     @DIADIEM NVARCHAR(50),
     @NGAYNC DATE
  ) 
AS 
INSERT INTO PHONGBAN(MAPB,TENPB,MATP,DIADIEM,NGAYNC) 
VALUES(@MAPB,@TENPB,@MATP,@DIADIEM,@NGAYNC)
GO
/****** Object:  StoredProcedure [dbo].[SP_SUAPHONGBAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[SP_SUAPHONGBAN]
( 
     @MAPB char(10), 
     @TENPB nvarchar(50),
     @MATP CHAR(10),
     @DIADIEM NVARCHAR(50),
     @NGAYNC DATE 
     ) 
AS 
UPDATE PHONGBAN 
SET TENPB = @TENPB, MATP = @MATP, DIADIEM = @DIADIEM, NGAYNC = @NGAYNC 
 WHERE MAPB = @MAPB
GO
/****** Object:  Table [dbo].[PHANCONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANCONG](
	[MANV] [char](10) NOT NULL,
	[MADA] [char](10) NOT NULL,
	[SOGIO] [float] NULL,
 CONSTRAINT [PK_PHANCONG] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC,
	[MADA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_SUAPHANCONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ tục sửa thông tin 1 NHÂN VIÊN*/ 
CREATE PROC  [dbo].[SP_SUAPHANCONG]
( 
    @MANV CHAR(10),
    @MADA CHAR(10),
    @SOGIO FLOAT
) 
AS 
UPDATE PHANCONG
SET MADA = @MADA, SOGIO = @SOGIO
WHERE MANV = @MANV
GO
/****** Object:  Table [dbo].[THANNHAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THANNHAN](
	[HOTEN] [nvarchar](50) NOT NULL,
	[NGAYSINH] [date] NULL,
	[GT] [nvarchar](50) NULL,
	[MANV] [char](10) NOT NULL,
	[QUANHE] [nvarchar](50) NULL,
 CONSTRAINT [PK_THANNHAN] PRIMARY KEY CLUSTERED 
(
	[HOTEN] ASC,
	[MANV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_XOANHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_XOANHANVIEN]
( 
     @MANV char(10) 
) 
AS 
DELETE NHANVIEN
WHERE MANV = @MANV
GO
/****** Object:  Table [dbo].[LUONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUONG](
	[BACLUONG] [int] NOT NULL,
	[LUONGCOBAN] [int] NULL,
	[HESOLUONG] [float] NULL,
	[HESOPHUCAP] [float] NULL,
 CONSTRAINT [PK_LUONG] PRIMARY KEY CLUSTERED 
(
	[BACLUONG] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[ACCOUNT] [varchar](50) NOT NULL,
	[PASSWORD] [varchar](50) NULL,
	[ACCESS] [nchar](3) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[ACCOUNT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_XOALUONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ xóa một LƯƠNG*/ 
CREATE PROC [dbo].[SP_XOALUONG]
( 
     @BACLUONG char(10) 
) 
AS 
DELETE LUONG
WHERE BACLUONG = @BACLUONG
GO
/****** Object:  StoredProcedure [dbo].[SP_THEMLUONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_THEMLUONG]
(    
	@BACLUONG INT,
	@LUONGCOBAN INT,
	@HESOLUONG FLOAT,
	@HESOPHUCAP FLOAT
  ) 
AS 
INSERT INTO LUONG(BACLUONG,LUONGCOBAN,HESOLUONG,HESOPHUCAP) 
VALUES(@BACLUONG,@LUONGCOBAN,@HESOLUONG,@HESOPHUCAP)
GO
/****** Object:  StoredProcedure [dbo].[SP_SUALUONG]    Script Date: 03/05/2018 17:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Thủ tục sửa thông tin 1 LƯƠNG*/ 
CREATE PROC  [dbo].[SP_SUALUONG]
( 
     @BACLUONG INT,
	@LUONGCOBAN INT,
	@HESOLUONG FLOAT,
	@HESOPHUCAP FLOAT 
) 
AS 
UPDATE LUONG
SET LUONGCOBAN = @LUONGCOBAN, HESOLUONG = @HESOLUONG, HESOPHUCAP = @HESOPHUCAP
 WHERE BACLUONG = @BACLUONG
GO
/****** Object:  ForeignKey [FK_NHANVIEN_NHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_NHANVIEN] FOREIGN KEY([MANGS])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_NHANVIEN]
GO
/****** Object:  ForeignKey [FK_NHANVIEN_PHONGBAN]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_PHONGBAN] FOREIGN KEY([MAPB])
REFERENCES [dbo].[PHONGBAN] ([MAPB])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_PHONGBAN]
GO
/****** Object:  ForeignKey [FK_PHONGBAN_NHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[PHONGBAN]  WITH CHECK ADD  CONSTRAINT [FK_PHONGBAN_NHANVIEN] FOREIGN KEY([MATP])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHONGBAN] CHECK CONSTRAINT [FK_PHONGBAN_NHANVIEN]
GO
/****** Object:  ForeignKey [FK_PHONGBAN_NHANVIEN1]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[PHONGBAN]  WITH CHECK ADD  CONSTRAINT [FK_PHONGBAN_NHANVIEN1] FOREIGN KEY([MATP])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHONGBAN] CHECK CONSTRAINT [FK_PHONGBAN_NHANVIEN1]
GO
/****** Object:  ForeignKey [FK_PHANCONG_DUAN1]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD  CONSTRAINT [FK_PHANCONG_DUAN1] FOREIGN KEY([MADA])
REFERENCES [dbo].[DUAN] ([MADA])
GO
ALTER TABLE [dbo].[PHANCONG] CHECK CONSTRAINT [FK_PHANCONG_DUAN1]
GO
/****** Object:  ForeignKey [FK_PHANCONG_NHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[PHANCONG]  WITH CHECK ADD  CONSTRAINT [FK_PHANCONG_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHANCONG] CHECK CONSTRAINT [FK_PHANCONG_NHANVIEN]
GO
/****** Object:  ForeignKey [FK_THANNHAN_NHANVIEN]    Script Date: 03/05/2018 17:10:43 ******/
ALTER TABLE [dbo].[THANNHAN]  WITH CHECK ADD  CONSTRAINT [FK_THANNHAN_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[THANNHAN] CHECK CONSTRAINT [FK_THANNHAN_NHANVIEN]
GO
