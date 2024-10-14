using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbNguoi
{
    [DisplayName("Id Người")]
    public int IdNguoi { get; set; }

    [DisplayName("Họ ")]
    public string? Ho { get; set; }

    [DisplayName("Tên ")]
    public string? Ten { get; set; }

    //ForeignKey trỏ vào table [DM].[dmQuocTich] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdQuocTich { get; set; }
    
    [DisplayName("Số CCCD ")]
    public string? SoCccd { get; set; }
    
    [DisplayName("Ngày Cấp CCCD ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayCapCccd { get; set; }

    [DisplayName("Nơi Cấp CCCD ")]
    public string? NoiCapCccd { get; set; }
    
    [DisplayName("Ngày Sinh ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgaySinh { get; set; }

    //ForeignKey trỏ vào table [DM].[dmGioiTinh] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdGioiTinh { get; set; }

    //ForeignKey trỏ vào table [DM].[dmDanToc] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdDanToc { get; set; }

    //ForeignKey trỏ vào table [DM].[dmTonGiao] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdTonGiao { get; set; }

    [DisplayName("Ngày Vào Đoàn ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayVaoDoan { get; set; }

    [DisplayName("Ngày Vào Đảng ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayVaoDang { get; set; }

    [DisplayName("Ngày Vào Đảng Chính Thức ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayVaoDangChinhThuc { get; set; }

    [DisplayName("Ngày Nhập Ngũ ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayNhapNgu { get; set; }

    [DisplayName("Ngày Xuất Ngũ ")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateOnly? NgayXuatNgu { get; set; }

    //ForeignKey trỏ vào table [DM].[dmHangThuongBinh] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdThuongBinhHang { get; set; }
    [DisplayName("Gia Đình Chính Sách ")]

    //ForeignKey trỏ vào table [DM].[dmHoGiaDinhChinhSach] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdGiaDinhChinhSach { get; set; }

    //ForeignKey trỏ vào table [DM].[dmChucDanhKhoaHoc] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdChucDanhKhoaHoc { get; set; }

    //ForeignKey trỏ vào table [DM].[dmTrinhDoDaoTao] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdTrinhDoDaoTao { get; set; }

    //ForeignKey trỏ vào table [DM].[dmNganhDaoTao] - chỉ thao tác ở backend không hiển ra ngoài frontend    
    public int? IdChuyenMonDaoTao { get; set; }

    //ForeignKey trỏ vào table [DM].[dmNgoaiNgu] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdNgoaiNgu { get; set; }

    //ForeignKey trỏ vào table [DM].[dmKhungNangLucNgoaiNgu] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdKhungNangLucNgoaiNguc { get; set; }

    //ForeignKey trỏ vào table [DM].[dmTrinhDoLyLuanChinhTri] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdTrinhDoLyLuanChinhTri { get; set; }

    //ForeignKey trỏ vào table [DM].[dmTrinhDoQuanLyNhaNuoc] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdTrinhDoQuanLyNhaNuoc { get; set; }

    //ForeignKey trỏ vào table [DM].[dmTrinhDoTinHoc] - chỉ thao tác ở backend không hiển ra ngoài frontend
    public int? IdTrinhDoTinHoc { get; set; }

    [DisplayName("Chức Danh KH")]
    public virtual DmChucDanhKhoaHoc? IdChucDanhKhoaHocNavigation { get; set; }

    [DisplayName("Chuyên Môn ĐT")]
    public virtual DmNganhDaoTao? IdChuyenMonDaoTaoNavigation { get; set; }

    [DisplayName("Tôn Giáo")]
    public virtual DmTonGiao? IdTonGiaoNavigation { get; set; }

    [DisplayName("Dân Tộc")]
    public virtual DmDanToc? IdDanTocNavigation { get; set; }

    [DisplayName("Gia Đình Chính Sách")]
    public virtual DmHoGiaDinhChinhSach? IdGiaDinhChinhSachNavigation { get; set; }

    [DisplayName("Giới Tính")]
    public virtual DmGioiTinh? IdGioiTinhNavigation { get; set; }

    [DisplayName("Khung Năng Lực NN")]
    public virtual DmKhungNangLucNgoaiNgu? IdKhungNangLucNgoaiNgucNavigation { get; set; }

    [DisplayName("Ngoại Ngữ")]
    public virtual DmNgoaiNgu? IdNgoaiNguNavigation { get; set; }

    [DisplayName("Quốc Tịch")]
    public virtual DmQuocTich? IdQuocTichNavigation { get; set; }

    [DisplayName("Hạng Thương Binh")]
    public virtual DmHangThuongBinh? IdThuongBinhHangNavigation { get; set; }

    [DisplayName("Trình Độ ĐT")]
    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }

    [DisplayName("Trình Độ LLCT")]
    public virtual DmTrinhDoLyLuanChinhTri? IdTrinhDoLyLuanChinhTriNavigation { get; set; }

    [DisplayName("Trình Độ QLNC")]
    public virtual DmTrinhDoQuanLyNhaNuoc? IdTrinhDoQuanLyNhaNuocNavigation { get; set; }

    [DisplayName("Trình Độ Tin Học")]
    public virtual DmTrinhDoTinHoc? IdTrinhDoTinHocNavigation { get; set; }

    [DisplayName("Cán Bộ")]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    [DisplayName("Đối Tượng Tham Gia")]
    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();

    [DisplayName("Học Viên")]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();

    [NotMapped]
    [DisplayName("Họ Tên")]
    public string name { get => Ho + " " + Ten; }
}
