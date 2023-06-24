create database QLBR
use QLBR

create table DungLuong
(
	madungluong		nvarchar(20) not null primary key,
	tendungluong	nvarchar(20) not null
);

create table Loai
(
	maloai			nvarchar(20) not null primary key,
	tenloai			nvarchar(20) not null
);

create table CongDung
(
	macongdung		nvarchar(20) not null primary key,
	tencongdung		nvarchar(20) not null
);

create table ChatLieu
(
	machatlieu		nvarchar(20) not null primary key,
	tenchatlieu		nvarchar(20) not null
);

create table NuocSanXuat
(
	manuocsx		nvarchar(20) not null primary key,
	tennuocsx		nvarchar(20) not null
);

create table MauSac
(
	mamau			nvarchar(20) not null primary key,
	tenmau			nvarchar(20) not null
);

create table HinhDang
(
	mahinhdang		nvarchar(20) not null primary key,
	tenhinhdang		nvarchar(20) not null
);

create table DoRuou
(
	mado			nvarchar(20) not null primary key,
	tendo			nvarchar(20) not null
);

create table NhanVien
(
	manhanvien		nvarchar(20)	not null primary key,
	tennhanvien		nvarchar(20)	not null,
	gioitinh		nvarchar(5)		not null,
	ngaysinh		date			not null,
	dienthoai		nvarchar(10)	not null,
	diachi			nvarchar(50)	not null,
	macv			nvarchar(20)	not null Foreign key references CongViec(macv)
);

create table HoaDonBan
(
	sohdb			nvarchar(20) not null primary key,
	manhanvien		nvarchar(20) not null foreign key references NhanVien(manhanvien),
	ngayban			date not null,
	makhach			nvarchar(20) not null foreign key references Khachhang(makhach),
	tongtien		float not null
);

create table HoaDonNhap
(
	sohdn			nvarchar(20)	not null primary key,
	manhanvien		nvarchar(20)	not null foreign key references NhanVien(manhanvien),
	ngaynhap		date			not null,
	mancc			nvarchar(20)	not null foreign key references NhaCungCap(mancc),
	tongtien		float			not null
);

create table Khachhang
(
	makhach			nvarchar(20)	not null primary key,
	tenkhach		nvarchar(30)	not null,
	diachi			nvarchar(50)	not null,
	dienthoai		nvarchar(10)	not null
);

create table CongViec
(
	macv			nvarchar(20)	not null primary key,
	tencv			nvarchar(20)	not null,
	mucluong		float			not null
);

create table NhaCungCap
(
	mancc			nvarchar(20)	not null primary key,
	tenncc			nvarchar(30)	not null,
	diachi			nvarchar(50)	not null,
	dienthoai		nvarchar(10)	not null
);


create table DMHangHoa
(
	mahang			nvarchar(20)	not null primary key,
	tenhang			nvarchar(20)	not null,
	maloai			nvarchar(20)	not null foreign key references Loai(maloai),
	madungluong		nvarchar(20)	not null foreign key references DungLuong(madungluong),
	macongdung		nvarchar(20)	not null foreign key references CongDung(macongdung),
	machatlieu		nvarchar(20)	not null foreign key references ChatLieu(machatlieu),
	mahinhdang		nvarchar(20)	not null foreign key references HinhDang(mahinhdang),
	mado			nvarchar(20)	not null foreign key references DoRuou(mado),
	mamau			nvarchar(20)	not null foreign key references MauSac(mamau),
	manuocsx		nvarchar(20)	not null foreign key references NuocSanXuat(manuocsx),
	soluong			int				not null,
	dongianhap		float			not null,
	dongiaban		float			not null,
	thoigianbaohanh nvarchar(10)	not null,
	ghichu			nvarchar(200)	not null
);


create table ChiTietHoaDonBan
(
	sohdb			nvarchar(20)	not null foreign key references HoaDonBan(sohdb),
	mahang			nvarchar(20)	not null foreign key references DMHangHoa(mahang),
	soluong			int				not null,
	dongia			float			not null,
	giamgia			float			not null,
	thanhtien		float			not null,
	constraint PK_CTB primary key (sohdb, mahang)
);

create table ChiTietHoaDonNhap
(
	sohdn			nvarchar(20)	not null foreign key references HoaDonNhap(sohdn),
	mahang			nvarchar(20)	not null foreign key references DMHangHoa(mahang),
	soluong			int				not null,
	dongia			float			not null,
	giamgia			float			not null,
	thanhtien		float			not null,
	constraint PK_CTN primary key (sohdn, mahang),
);


