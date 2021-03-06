USE [CaseStudy]
GO
/****** Object:  StoredProcedure [dbo].[ChiTietDiemDanhTheoNhanVienId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ChiTietDiemDanhTheoNhanVienId]
(
	@Id INT,
	@Thang INT,
	@Nam INT
)
AS
BEGIN
SELECT [Id]
      ,[NhanVienId]
      ,[QuanLyId]
      ,CASE WHEN TrangThai = 1 THEN N'Có Mặt'
	  WHEN TrangThai = 2 THEN N'Trễ'
	  WHEN TrangThai = 3 THEN N'Vắng Không Phép'
	  WHEN TrangThai = 4 THEN N'Vắng Có Phép'
	  WHEN TrangThai = 5 THEN N'Vắng Theo Quy Định'
		END AS TrangThai
      ,FORMAT(Ngay,'ddd dd/MM/yyyy')AS Ngay
      ,[NgayTao]
      ,[NgaySua]
  FROM [dbo].[DiemDanh]
  WHERE NhanVienId = @Id AND MONTH(Ngay) = @Thang AND YEAR(Ngay) = @Nam
END

GO
/****** Object:  StoredProcedure [dbo].[LayNhanVienTheoId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LayNhanVienTheoId]
	@Id INT
AS 
BEGIN
SELECT nv.[Id]
	  ,CONCAT(nv.Ho,' ',nv.Ten) AS HoTen
      ,
		CASE WHEN GioiTinh = 0 THEN N'Nữ'
			ELSE N'Nam'
		END AS GioiTinh
      ,nv.[NgaySinh]
      ,nv.[SoChungMinh]
      ,nv.[SoDienThoai]
      ,nv.[Email]
      ,nv.[DiaChi]
      ,nv.[MaSoThue]
      ,nv.[HinhAnh]
      ,nv.[NgayTao]
      ,nv.[NgaySua]
      ,nv.[DangLamViec]
      ,nv.[DaXoa]
	  ,bp.Ten AS BoPhan
	  ,cv.Ten AS ChucVu
  FROM [dbo].[NhanVien] nv
		JOIN dbo.ChucVuNhanVien cvnv ON cvnv.NhanVienId = nv.Id
		JOIN dbo.ChucVu cv ON cv.Id = cvnv.ChucVuId
		JOIN dbo.BoPhan bp ON bp.Id = cvnv.BoPhanId
  WHERE nv.Id = @Id AND nv.DaXoa = 0 AND DangLamViec = 1
END

GO
/****** Object:  StoredProcedure [dbo].[sp_CapPhepNam]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <15/10/2019,,>
-- Description:	<Cấp Phép Năm Cho Nhân Viên,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapPhepNam]	
	(@NhanVienId INT,
	@Nam INT,
	@SoPhep TINYINT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    UPDATE PhepNam SET
	Nam=@Nam,
	SoPhep=@SoPhep
	WHERE NhanVienId=@NhanVienId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapPhepNamGet]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <15/10/2019,,>
-- Description:	<Cấp Phép Năm Cho Nhân Viên,get ra để update lại số ngày,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CapPhepNamGet]
	(@NhanVienId INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT top 1 NhanVienId,Nam,SoPhep FROM PhepNam
		WHERE NhanVienId=@NhanVienId AND
		YEAR(GETDATE())=Nam
    
END

GO
/****** Object:  StoredProcedure [dbo].[sp_HienThiThongTinNhanVien]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HienThiThongTinNhanVien](
	@Id INT
 )
AS
BEGIN
	SELECT nv.Id,
		nv.Ho,
		nv.Ten,
		nv.GioiTinh,
		nv.NgaySinh,
		nv.SoChungMinh,
		nv.SoDienThoai,
		nv.Email,
		nv.DiaChi,
		nv.MaSoThue,
		nv.HinhAnh,
		nv.NgayTao,
		nv.NgaySua,
		nv.DangLamViec,
		tk.Id,
		cvnv.ChucVuId,
		cvnv.BoPhanId
	FROM NhanVien nv JOIN TaiKhoan tk ON nv.Id = tk.Id
	JOIN ChucVuNhanVien cvnv ON cvnv.NhanVienId=nv.Id
	WHERE nv.Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayBoPhan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <10/10/2019>
-- Description:	<Lấy Bộ Phận để viết viewbag>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayBoPhan]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,Ten FROM BoPhan
	WHERE DangHoatDong=1 AND DaXoa=0
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayBoPhanTheoId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <11/10/2019>
-- Description:	<Sua bộ phận>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayBoPhanTheoId]
			(@Id INT)
AS
BEGIN
	SELECT Id, Ten,DangHoatDong FROM BoPhan
	WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_layChucVu]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <10/10/2019>
-- Description:	<lấy Chức Vụ>
-- =============================================
CREATE PROCEDURE [dbo].[sp_layChucVu]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM ChucVu
	WHERE DangHoatDong=1 AND DaXoa=0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayNhanVienId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Tú>
-- Create date: <Create 15/10/2019,,>
-- Description:	<Lấy Id nhân viên để cấp phép năm>
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayNhanVienId]
	(@Id INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT 1 FROM PhepNam
							WHERE NhanVienId=@Id AND
							YEAR(GETDATE())=Nam)
	BEGIN
	DECLARE @Ngay INT
	IF ((SELECT DATEDIFF(yyyy,NgayTao,GETDATE()) FROM NhanVien nv WHERE nv.Id = @Id)<1)
		BEGIN
			SELECT TOP(1) @Ngay = DATEDIFF(month,NgayTao,GETDATE())  FROM NhanVien nv  WHERE nv.Id=@Id
		END
		ELSE
		BEGIN
			SELECT @Ngay=12
		END
		INSERT INTO PhepNam(NhanVienId,Nam,SoPhep )
		VALUES(@Id,YEAR(GETDATE()),@Ngay)
	END
	SELECT  NhanVienId,Nam,SoPhep FROM PhepNam
	WHERE NhanVienId=@Id AND
	YEAR(GETDATE())=Nam
END
GO
/****** Object:  StoredProcedure [dbo].[sp_layQuyenTruyCap]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <10/10/2019>
-- Description:	<lấy Quyền Truy Cập>
-- =============================================
CREATE PROCEDURE [dbo].[sp_layQuyenTruyCap]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT Id,Quyen  FROM QuyenTruyCap
		WHERE DangHoatDong=1 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaboPhan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <11/10/2019>
-- Description:	<Sua bộ phận>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SuaboPhan]
			(@Id INT,
			@Ten NVARCHAR(100),
			@DangHoatDong BIT)
AS
BEGIN
	UPDATE BoPhan SET
	Ten=@Ten,
	DangHoatDong=@DangHoatDong
	WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaThongTinNhanVien]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuaThongTinNhanVien](
	@Id INT
      ,@Ho NVARCHAR(50)
      ,@Ten NVARCHAR(50)
      ,@GioiTinh BIT
      ,@NgaySinh DATE
	  ,@SoChungMinh NVARCHAR(100)
      ,@SoDienThoai NVARCHAR(50)
      ,@Email NVARCHAR(100)
      ,@DiaChi NVARCHAR(500)
      ,@MaSoThue NVARCHAR(50)
      ,@HinhAnh NVARCHAR(MAX)
      ,@NgayTao DATE
      ,@NgaySua DATE
      ,@DangLamViec BIT
	  ,@QuyenId INT
	  ,@ChucVuId INT
	  ,@BoPhanId INT
      )
AS
BEGIN
	UPDATE NhanVien SET
	Ho=@Ho,
	Ten=@Ten,
	GioiTinh=@GioiTinh,
	NgaySinh=@NgaySinh,
	SoChungMinh=@SoChungMinh,
	SoDienThoai=@SoDienThoai,
	Email=@Email,
	DiaChi=@DiaChi,
	MaSoThue=@MaSoThue,
	HinhAnh=@HinhAnh,
	NgayTao=@NgayTao,
	NgaySua=@NgaySua,
	DangLamViec=@DangLamViec
	WHERE NhanVien.Id=@Id
	UPDATE TaiKhoan  SET
	QuyenId=@QuyenId,
	Email=@Email
	WHERE Id=@Id
	UPDATE ChucVuNhanVien SET
	ChucVuId=@ChucVuId,
	BoPhanId=@BoPhanId
	WHERE NhanVienId=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoMoiBoPhan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <11/10/2019>
-- Description:	<tạo mới bộ phận>
-- =============================================
CREATE PROCEDURE [dbo].[sp_TaoMoiBoPhan]
			(@Ten NVARCHAR(50))
AS
BEGIN
	INSERT INTO BoPhan (Ten,DangHoatDong,DaXoa) 
	VALUES(@Ten,1,0)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemNhanVien](
	
       @Ho NVARCHAR(50)
      ,@Ten NVARCHAR(50)
      ,@GioiTinh BIT
      ,@NgaySinh DATE
	  ,@SoChungMinh NVARCHAR(100)
      ,@SoDienThoai NVARCHAR(50)
      ,@Email NVARCHAR(100)
      ,@DiaChi NVARCHAR(500)
      ,@MaSoThue NVARCHAR(50)
      ,@HinhAnh NVARCHAR(MAX)
	  ,@QuyenId INT
	  ,@ChucVuId INT
	  ,@BoPhanId INT
	  ,@MatKhau NVARCHAR(100)
      )
AS
BEGIN

	DECLARE @ID INT
	INSERT INTO NhanVien(Ho,Ten,GioiTinh,NgaySinh,SoChungMinh,SoDienThoai,Email,DiaChi,MaSoThue,HinhAnh,NgayTao,NgaySua,DangLamViec,DaXoa) 
	VALUES(@Ho,@Ten,@GioiTinh,@NgaySinh,@SoChungMinh,@SoDienThoai,@Email,@DiaChi,@MaSoThue,@HinhAnh,GETDATE(),GETDATE(),1,0)
	SET @ID = SCOPE_IDENTITY()
	INSERT INTO TaiKhoan VALUES (@ID,@QuyenId,@Email,@MatKhau,1)
	INSERT INTO ChucVuNhanVien VALUES(@ID,@ChucVuId,@BoPhanId)
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongkeNhanVien]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Tú>
-- Create date: <15/10/2019>
-- Description:	<Thống kê tình trạng nhân viên,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ThongkeNhanVien]
	(@Id INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CoMat,Tre,KhongPhep,CoPhep,TheoQuyDinh,SoPhepConLai,Thang,Nam FROM ThongKe
	WHERE NhanVienId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThongTinBoPhanTheoId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThongTinBoPhanTheoId](
	@Id INT)
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT bp.Id,bp.Ten,bp.DangHoatDong,(SELECT COUNT(*)  FROM  NhanVien nv JOIN ChucVuNhanVien cvnv ON nv .Id=cvnv.NhanVienId WHERE cvnv.BoPhanId=bp.Id AND
	 nv.DangLamViec=1)as SoLuong FROM BoPhan bp	
	 WHERE bp.Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_thongTinPhongBan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_thongTinPhongBan]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT bp.Id,bp.Ten,(SELECT COUNT(*)  FROM  NhanVien nv JOIN ChucVuNhanVien cvnv ON nv .Id=cvnv.NhanVienId WHERE cvnv.BoPhanId=bp.Id AND
	 nv.DangLamViec=1)as SoLuong FROM BoPhan bp	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_XemThongTinNhanVienTheoPhongBan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tu Nguyen
-- Create date: <9/10/2019>
-- Description:	<danh sach Thong tin nhan vien theo ID  phong ban>
-- =============================================
CREATE PROCEDURE [dbo].[sp_XemThongTinNhanVienTheoPhongBan](
	@Id int)
	
AS
BEGIN
		SELECT nv.Id,nv.Ho,nv.Ten,nv.GioiTinh,nv.Email,nv.SoDienThoai FROM NhanVien nv
		JOIN ChucVuNhanVien cvnv ON nv.Id=cvnv.NhanVienId
		WHERE cvnv.BoPhanId=@Id AND
		nv.DangLamViec=1 AND
		nv.DaXoa=0

END
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaBoPhan]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <11/10/2019>
-- Description:	<Xóa bộ phận>
-- =============================================
CREATE PROCEDURE [dbo].[sp_XoaBoPhan]
			(@Id INT)
AS
BEGIN
	UPDATE BoPhan SET
	DangHoatDong=0,
	DaXoa=1
	WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNhanVien]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tú>
-- Create date: <10/10/2019>
-- Description:	<Delete NhanVien>
-- =============================================
CREATE PROCEDURE [dbo].[sp_XoaNhanVien](
	@Id INT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE NhanVien SET DaXoa=1 
   WHERE NhanVien.Id=@Id
   UPDATE TaiKhoan SET DangHoatDong=0
   WHERE TaiKhoan.Id=@Id
   DELETE  FROM ChucVuNhanVien
   WHERE NhanVienId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[TaoDonXinPhep]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Báo
-- Create date: 2019/10/09
-- Description:	Viết Đơn Xin Phép
-- =============================================
CREATE PROCEDURE [dbo].[TaoDonXinPhep]
(
	@NhanVienId INT,
	@QuanLyId INT,
	@TinhTrang INT,
	@NgayBatDau DATE,
	@NgayKetThuc DATE,
	@SoPhepConLai TINYINT,
	@SoNgayDaNghi TINYINT,
	@NgayGui DATE,
	@NgayPhanHoi DATE,
	@GhiChu NVARCHAR(MAX),
	@TraLoi NVARCHAR(MAX)
)
AS
BEGIN
INSERT INTO [dbo].[DonXinPhep]
           ([NhanVienId]
           ,[QuanLyId]
           ,[TinhTrang]
           ,[NgayBatDau]
           ,[NgayKetThuc]
           ,[SoPhepConLai]
           ,[SoNgayDaNghi]
           ,[NgayGui]
           ,[NgayPhanHoi]
           ,[GhiChu]
           ,[TraLoi])
     VALUES
           (@NhanVienId
           ,@QuanLyId
           ,@TinhTrang
           ,@NgayBatDau
           ,@NgayKetThuc
           ,@SoPhepConLai
           ,@SoNgayDaNghi
           ,@NgayGui
           ,@NgayPhanHoi
           ,@GhiChu
           ,@TraLoi)
END

GO
/****** Object:  StoredProcedure [dbo].[TaoDonXinPhepView]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Báo
-- Create date: 2019/10/09
-- Description:	Xem Đơn Xin Phép
-- =============================================
CREATE PROCEDURE  [dbo].[TaoDonXinPhepView]
(
	@Id INT
)
AS
BEGIN
DECLARE @NgayHienTai DATE = GETDATE()
SELECT tk.[NhanVienId]
      ,CONCAT(nv.Ho,' ',nv.Ten) AS HoTen
	  ,bp.Ten AS BoPhan
      ,tk.[Tre]
      ,tk.[KhongPhep]
      ,tk.[SoPhepConLai]
FROM [dbo].[ThongKe] tk JOIN dbo.NhanVien nv ON nv.Id = tk.NhanVienId
	JOIN dbo.ChucVuNhanVien cvnv ON cvnv.NhanVienId = nv.Id
	JOIN dbo.BoPhan bp ON bp.Id = cvnv.BoPhanId
	WHERE tk.NhanVienId = @Id AND tk.Thang = MONTH(@NgayHienTai) AND tk.Nam = YEAR(@NgayHienTai) 
END

GO
/****** Object:  StoredProcedure [dbo].[ThongKeNhanVienTheoId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThongKeNhanVienTheoId]
(
	@Id INT
)
AS
BEGIN
SELECT 
	  TK.[Id]
	  ,CONCAT(NV.Ho,' ',NV.Ten) AS HoTen
      ,TK.[NhanVienId]
      ,TK.[Thang]
      ,TK.[Nam]
      ,TK.[CoMat]
      ,TK.[Tre]
      ,TK.[KhongPhep]
      ,TK.[CoPhep]
      ,TK.[TheoQuyDinh]
      ,TK.[SoPhepConLai]
  FROM [dbo].[ThongKe] TK JOIN dbo.NhanVien NV ON NV.Id = TK.NhanVienId
  WHERE TK.NhanVienId = @Id AND NV.DaXoa = 0 AND NV.DangLamViec = 1
END

GO
/****** Object:  StoredProcedure [dbo].[XemDonXinPhepNhanVienTheoId]    Script Date: 10/17/2019 10:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Báo
-- Create date: 2019/10/09
-- Description:	Xem Đơn Xin Phép
-- =============================================
CREATE PROCEDURE [dbo].[XemDonXinPhepNhanVienTheoId]
(
	@Id INT
)
AS
BEGIN
SELECT dxp.[Id]
      ,dxp.[NhanVienId]
	  ,CONCAT(nv.Ho,' ',nv.Ten) AS HoTen
      ,dxp.[QuanLyId]
      ,dxp.[TinhTrang]
      ,dxp.[NgayBatDau]
      ,dxp.[NgayKetThuc]
      ,dxp.[SoPhepConLai]
      ,dxp.[SoNgayDaNghi]
      ,dxp.[NgayGui]
      ,dxp.[NgayPhanHoi]
      ,dxp.[GhiChu]
      ,dxp.[TraLoi]
  FROM [dbo].[DonXinPhep] dxp JOIN dbo.NhanVien nv ON nv.Id = dxp.NhanVienId
	WHERE nv.DaXoa = 0 AND nv.DangLamViec = 1 AND dxp.NhanVienId = @Id
  
END

GO
