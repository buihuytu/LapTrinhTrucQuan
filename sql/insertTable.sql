use QLBR

insert into DungLuong values
('mdl1', '1L'),
('mdl2', '1.5L'),
('mdl3', '2L'),
('mdl4', '1.8L');

insert into Loai values
('ml1', 'Vang'),
('ml2', N'Ba Kích'),
('ml3', 'Nho'),
('ml4', N'Táo Mèo');

insert into CongDung values
('mcd1', N'Trang Trí'),
('mcd2', N'Cắm Hoa'),
('mcd3', N'Trưng Bày'),
('mcd4', N'Quà Tặng');

insert into CongDung values
('mcd5', N'Sử dụng');

insert into ChatLieu values
('mcl1', N'Lúa mạch'),
('mcl2', N'Rễ cây'),
('mcl3', N'Táo'),
('mcl4', 'Nho');

insert into ChatLieu values
('mcl5', N'Nhãn'),
('mcl6', N'Dâu'),
('mcl7', N'Chuối'),
('mcl8', N'Vải');

insert into NuocSanXuat values
('msx1', N'Việt Nam'),
('msx2', N'Trung Quốc'),
('msx3', N'Mỹ'),
('msx4', 'Canada');

insert into NuocSanXuat values
('msx5', N'Thái Lan');

insert into MauSac values
('mm1', N'Đỏ'),
('mm2', N'Cam'),
('mm3', N'Nâu'),
('mm4', N'Đen');

insert into MauSac values
('mm5', N'Vàng');

insert into NhaCungCap values
('ncc1','Kokomi',N'Hà Nội', '092382334'),
('ncc2','HaoHao',N'Hà Nam', '092222334'),
('ncc3','OmaChi',N'Hà Tây', '092367834'),
('ncc4','GauDo',N'Hà Bắc', '022282334');

insert into HinhDang values
('hd1',N'Chữ nhật'),
('hd2',N'Hình trụ'),
('hd3',N'Hình cầu'),
('hd4',N'Hình lập phương');

insert into CongViec values
('cv1',N'Thu ngân','5000000'),
('cv2',N'Bán rượu','6000000'),
('cv3',N'Kế toán','7000000'),
('cv4','Shipper','8000000');

insert into CongViec values
('cv5',N'Quản lý','10000000');

insert into DoRuou values 
('dr1',N'Cao cấp'),
('dr2',N'Trung cấp'),
('dr3',N'Cận cao cấp'),
('dr4',N'Cận trung cấp');


insert into NhanVien values
('nv1',N'QUANG','NAM','2000-10-12','093094938',N'HÀ NỘI','cv1'),
('nv2',N'QUANG HANH','NAM','2000-1-12','093494938',N'HÀ NAM','cv3'),
('nv3',N'PHÚ','NAM','1990-10-12','093344938',N'HÀ NỘI','cv2'),
('nv4',N'ĐẠT','NAM','1998-10-2','093094938',N'SÀI GÒN','cv3'),
('nv5',N'HIẾU','NAM','2001-1-12','093099838',N'NINH BÌNH','cv3'); 

insert into Khachhang values
('mkh1',N'Nguyễn Văn Bê','Ha Noi','0987567887'),
('mkh2', N'Lê Văn Long', N'Hà Nội', '0914435240'),
('mkh3', N'Nguyễn Văn Thắng', N'Hà Nam', '0914435241');

insert into DMHangHoa values
('mh1',N'Rượu táo','ml1','mdl1','mcd1','mcl1','hd1','dr1','mm1','msx1',0,0,0,N'1',N'Rượu hảo hạng');

insert into HoaDonNhap values
('hd01','nv2','2021-09-27','ncc1', 850000),
('hd02','nv3','2021-09-20','ncc2', 1050000),
('hd03','nv3','2020-07-02','ncc2', 300000),
('hd04','nv2','2021-01-17','ncc3', 900000),
('hd05','nv3','2022-01-07','ncc2', 1200000),
('hd06','nv3','2022-01-07','ncc2', 1200000),
('hd07','nv3','2022-01-07','ncc3', 1500000),
('hd08','nv3','2022-01-07','ncc2', 1800000)

insert into ChiTietHoaDonNhap values
('hd01','mh1',3, 850000, 50000, 800000),
('hd02','mh2',20, 1050000, 50000, 1000000),
('hd03','mh2',1, 300000, 150000, 150000),
('hd04','mh3',12, 900000, 100000, 800000),
('hd05','mh1',5, 1200000, 200000, 1000000),
('hd06','mh1',5, 1200000, 200000, 1000000),
('hd07','mh1',5, 1200000, 200000, 1000000),
('hd08','mh1',5, 1200000, 200000, 1000000)


insert into HoaDonBan values
('hdb01','nv1','2021-12-20', 'mkh1', 850000),
('hdb02','nv2','2021-12-02', 'mkh2', 900000),
('hdb03','nv3','2022-02-21', 'mkh2', 1200000),
('hdb04','nv4','2021-10-21', 'mkh3', 1500000),
('hdb05','nv5','2022-02-08', 'mkh2', 900000)

insert into ChiTietHoaDonBan values
('hdb01','mh1',3, 50000, 850000),
('hdb02','mh2',2, 50000, 900000),
('hdb03','mh2',5, 100000, 1200000),
('hdb04','mh3',3, 150000, 1500000),
('hdb05','mh2',8, 200000, 900000)
--cau 6
create proc Cau6
@maKH nvarchar(20)
as
 select top 3 H.makhach, K.tenkhach, C.mahang, D.tenhang, SUM(C.soluong) as TongSoluong from HoaDonBan as H inner join 
 ChiTietHoaDonBan as C on H.sohdb = C.sohdb inner join 
 Khachhang as K on H.makhach = K.makhach inner join 
 DMHangHoa as D on C.mahang = D.mahang 
 where H.makhach = @maKH 
 group by C.mahang, H.makhach, K.tenkhach, D.tenhang order by SUM(C.soluong) desc;

 -- cau 7
select * from HoaDonNhap
where mancc='ncc1';

select sum(tongtien) from HoaDonNhap where mancc='ncc1';

 --cau 8
 create proc Cau8
 @nam nvarchar(10)
 as
select Year(ngaynhap) as nam, SUM(tongtien) as tongtien 
  from HoaDonNhap where Year(ngaynhap) = @nam group by YEAR(ngaynhap)
   execute Cau8 '2022'

-- cau 9
create proc Cau9
@maHang nvarchar(20)
as
select ChiTietHoaDonBan.mahang, HoaDonBan.sohdb,HoaDonBan.manhanvien,HoaDonBan.tongtien,HoaDonBan.makhach,ngayban
from HoaDonBan inner join ChiTietHoaDonBan on HoaDonBan.sohdb=ChiTietHoaDonBan.sohdb
where mahang=@maHang;
 execute Cau9 'mh1'
