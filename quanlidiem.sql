create database [quanlydiem]
GO
USE [quanlydiem]
GO
/****** Object:  Table [dbo].[tblGIANG_VIEN]    Script Date: 11/13/2021 9:05:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGIANG_VIEN](
	[MaGV] [nvarchar](10) NOT NULL,
	[TenGV] [nvarchar](30) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKET_QUA]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKET_QUA](
	[MaSV] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[MaLop] [nvarchar](10) NULL,
	[MaMon] [nvarchar](10) NULL,
	[DiemTB] [money] NULL,
	[DiemThi] [money] NULL,
	[DiemTongKet] [money] NULL,
	[HocKi] [nvarchar](10) NULL,
	[GhiChu] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKHOA]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKHOA](
	[MaKhoa] [nvarchar](10) NOT NULL,
	[TenKhoa] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLOGIN]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLOGIN](
	[TenDN] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[MaSo] [nvarchar](50) NULL,
	[Quyen] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLOP]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLOP](
	[MaKhoa] [nvarchar](10) NULL,
	[MaLop] [nvarchar](10) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMON]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMON](
	[MaMon] [nvarchar](10) NOT NULL,
	[TenMon] [nvarchar](50) NOT NULL,
	[MaGV] [nvarchar](10) NULL,
	[HocKi] [nvarchar](10) NULL,
	[MaKhoa] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSINH_VIEN]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSINH_VIEN](
	[MaSv] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [nvarchar](10) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[MaLop] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTeach]    Script Date: 11/13/2021 9:05:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTeach](
	[MaMon] [nvarchar](10) NULL,
	[MaGV] [nvarchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email]) VALUES (N'GV01', N'Nguyen Tien Dat', N'Nam', N'097905206', N'dat@gmail.com')
INSERT [dbo].[tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email]) VALUES (N'GV02', N'Nguyen Van Nam', N'Nam', N'097905206', N'nam@gmail.com')
INSERT [dbo].[tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email]) VALUES (N'GV03', N'Ngo Van Binh', N'Nam', N'0125563231', N'binh@gmail.com')
INSERT [dbo].[tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email]) VALUES (N'GV04', N'Nguyen Thi Lan', N'Nu', N'097905676', N'lan@gmail.com')
GO
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV04', N'Nguyen Thi Hien', N'KTPM01', N'JAVA', 5.0000, 5.0000, 5.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV05', N'Nguyen Dang Nam', N'KTPM01', N'JAVA', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV06', N'Nguyen Van Anh', N'KTPM01', N'JAVA', 4.0000, 5.0000, 4.5000, N'5', N'Thi lai')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV07', N'Nguyen Van Khoi', N'KTPM01', N'JAVA', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV08', N'Nguyen Thi Lan', N'KTPM01', N'JAVA', 5.0000, 3.0000, 4.0000, N'5', N'Thi lai')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV09', N'Nguyen Van Nam', N'KTPM02', N'JAVA', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV10', N'Nguyen Van Hai', N'KTPM02', N'CTDL', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV11', N'Nguyen Van Cuong', N'KTPM02', N'CTDL', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV12', N'Nguyen Dang Vu', N'KTPM02', N'CTDL', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV08', N'Nguyen Thi Lan', N'AI01', N'AI', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV09', N'Nguyen Van Nam', N'AI01', N'AI', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV10', N'Nguyen Van Hai', N'AI01', N'AI', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV11', N'Nguyen Van Cuong', N'AI01', N'AI', 7.0000, 7.0000, 7.0000, N'5', N'')
INSERT [dbo].[tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [DiemTB], [DiemThi], [DiemTongKet], [HocKi], [GhiChu]) VALUES (N'SV12', N'Nguyen Dang Vu', N'AI01', N'AI', 7.0000, 7.0000, 7.0000, N'5', N'')
GO
INSERT [dbo].[tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'CNTT', N'Cong nghe thong tin')
INSERT [dbo].[tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'KT', N'Ke Toan')
INSERT [dbo].[tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'TCNH', N'Tai chinh ngan hang')
GO
INSERT [dbo].[tblLOGIN] ([TenDN], [MatKhau], [HoTen], [MaSo], [Quyen]) VALUES (N'student', N'123', N'Nguyen Van Chung', N'SV02', N'SV')
INSERT [dbo].[tblLOGIN] ([TenDN], [MatKhau], [HoTen], [MaSo], [Quyen]) VALUES (N'teacher', N'123', N'Nguyen Tien Dat', N'GV01', N'GV')
INSERT [dbo].[tblLOGIN] ([TenDN], [MatKhau], [HoTen], [MaSo], [Quyen]) VALUES (N'namngoc', N'123', N'Bui Nam Ngoc', N'AD', N'Admin')
INSERT [dbo].[tblLOGIN] ([TenDN], [MatKhau], [HoTen], [MaSo], [Quyen]) VALUES (N'admin', N'123', N'Nguyen Duy Phuc', N'AD01', N'Admin')
GO
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'AI01', N'AI1401')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'AI02', N'AI1402')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'KT', N'KT01', N'BS1411')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'KT', N'KT02', N'BS1412')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'KTPM01', N'KT1413')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'KTPM02', N'KT1415')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'KTPM03', N'KT1416')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'KT', N'KTTC01', N'FIN1411')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'KT', N'KTTC02', N'FIN1514')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'TCNH', N'TC01', N'TC1421')
INSERT [dbo].[tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'TCNH', N'TC02', N'TC1430')
GO
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'AI', N'Artificial intelligence', N'GV02', N'5', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'AI01', N'AI', N'GV02', N'6', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'AI2', N'Ain of 2', N'GV03', N'9', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'BCC', N'Tai chinh - Tien te', N'GV01', N'3', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'CTDL', N'Cau truc du lieu va giai thuat', N'GV01', N'5', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'ECL', N'Luat kinh te', N'GV04', N'3', N'KT        ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'JAVA', N'JAVA', N'GV01', N'5', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'KTCSDL', N'Kien truc co so du lieu', N'GV01', N'5', N'CNTT      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'MKT', N'Tiep thi ngan hang', N'GV02', N'1', N'TCNH      ')
INSERT [dbo].[tblMON] ([MaMon], [TenMon], [MaGV], [HocKi], [MaKhoa]) VALUES (N'Web', N'JAVA Web', N'GV03', N'4', N'CNTT      ')
GO
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV01', N'Nguyen Dang Phat', N'06/09/2000', N'Nam', N'Bac Ninh', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV02', N'Nguyen Van Chung', N'05/02/2000', N'Nam', N'Bac Giang', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV03', N'Nguyen Van Duc', N'19/01/2000', N'Nam', N'Ha Noi', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV04', N'Nguyen Thi Hien', N'19/01/2000', N'Nu', N'Ha Noi', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV05', N'Nguyen Dang Nam', N'06/09/2000', N'Nam', N'Bac Ninh', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV06', N'Nguyen Van Anh', N'05/02/2000', N'Nam', N'Bac Giang', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV07', N'Nguyen Van Khoi', N'19/01/2000', N'Nam', N'Ha Noi', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV08', N'Nguyen Thi Lan', N'19/01/2000', N'Nu', N'Ha Noi', N'KTPM01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV09', N'Nguyen Van Nam', N'24/02/2000', N'Nam', N'Nam Dinh', N'KTPM02')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV10', N'Nguyen Van Hai', N'24/02/2000', N'Nam', N'Nam Dinh', N'KTPM02')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV11', N'Nguyen Van Cuong', N'24/02/2000', N'Nam', N'Nam Dinh', N'KTPM02')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV12', N'Nguyen Van Vu', N'24/02/2000', N'Nam', N'Nam Dinh', N'KTPM02')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV13', N'Nguyen Van Son', N'26/03/2000', N'Nam', N'Thai Binh', N'AI01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV15', N'Nguyen Van Quoc Anh', N'26/03/2000', N'Nam', N'Thai Binh', N'AI01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV16', N'Nguyen Van Hai Nam', N'26/03/2000', N'Nam', N'Thai Binh', N'AI01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV17', N'Nguyen Van A', N'26/03/2000', N'Nam', N'Thai Binh', N'AI01')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV18', N'Nguyen Van Minh', N'26/03/2000', N'Nam', N'Thai Binh', N'KTPM03')
INSERT [dbo].[tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [MaLop]) VALUES (N'SV30', N'Nguyen Van A', N'26/03/2000', N'Nam', N'Thai Binh', N'KTPM01')
GO
ALTER TABLE [dbo].[tblKET_QUA]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[tblSINH_VIEN] ([MaSv])
GO
ALTER TABLE [dbo].[tblKET_QUA]  WITH CHECK ADD  CONSTRAINT [FK_tblKET_QUA_tblMON] FOREIGN KEY([MaMon])
REFERENCES [dbo].[tblMON] ([MaMon])
GO
ALTER TABLE [dbo].[tblKET_QUA] CHECK CONSTRAINT [FK_tblKET_QUA_tblMON]
GO
ALTER TABLE [dbo].[tblLOP]  WITH CHECK ADD FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[tblKHOA] ([MaKhoa])
GO
ALTER TABLE [dbo].[tblSINH_VIEN]  WITH CHECK ADD FOREIGN KEY([MaLop])
REFERENCES [dbo].[tblLOP] ([MaLop])
GO
ALTER TABLE [dbo].[tblTeach]  WITH CHECK ADD  CONSTRAINT [FK_tblTeach_tblGIANG_VIEN] FOREIGN KEY([MaGV])
REFERENCES [dbo].[tblGIANG_VIEN] ([MaGV])
GO
ALTER TABLE [dbo].[tblTeach] CHECK CONSTRAINT [FK_tblTeach_tblGIANG_VIEN]
GO
ALTER TABLE [dbo].[tblTeach]  WITH CHECK ADD  CONSTRAINT [FK_tblTeach_tblMON] FOREIGN KEY([MaMon])
REFERENCES [dbo].[tblMON] ([MaMon])
GO
ALTER TABLE [dbo].[tblTeach] CHECK CONSTRAINT [FK_tblTeach_tblMON]
GO
