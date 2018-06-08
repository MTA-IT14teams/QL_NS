USE [CongTy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[THEMDUAN]
(    
	@MaDA char(10),
	@TenDA nvarchar(50),
	@DiaDiem nvarchar(50),
	@MaPB char(10)
) 
AS 
INSERT INTO DuAn(MaDA,TenDA,DiaDiem,MaPB) 
VALUES(@MaDA,@TenDA,@DiaDiem,@MaPB)
go

USE [CongTy]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SUADUAN]
(    
	@MaDA char(10),
	@TenDA nvarchar(50),
	@DiaDiem nvarchar(50),
	@MaPB char(10)
  ) 
AS 
UPDATE DuAn
SET TenDA = @TenDA, DiaDiem = @DiaDiem, MaPB = @MaPB
WHERE MaDA = @MaDA
go

USE [CongTy]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[XOADUAN](@MaDA CHAR(10))
AS
BEGIN
DELETE DUAN
WHERE MaDA = @MaDA
END