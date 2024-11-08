﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("TbNguoi")]
    public class human
    {
        [Key]
        [DisplayName("Id Người")]
        [Required(ErrorMessage = "Không được bỏ trống ô này!")]
        public int IdNguoi { get; set; }

        [DisplayName("Họ ")]
        public string? Ho { get; set; }

        [DisplayName("Tên ")]
        public string? Ten { get; set; }

        //ForeignKey trỏ vào table [DM].[dmQuocTich]
        [DisplayName("Quốc tịch")]
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

        //ForeignKey trỏ vào table [DM].[dmGioiTinh]
        [DisplayName("Giới tính")]
        public int? IdGioiTinh { get; set; }

        //ForeignKey trỏ vào table [DM].[dmDanToc]
        [DisplayName("Dân tộc")]
        public int? IdDanToc { get; set; }

        //ForeignKey trỏ vào table [DM].[dmTonGiao]
        [DisplayName("Tôn giáo")]
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

        //ForeignKey trỏ vào table [DM].[dmHangThuongBinh]
        [DisplayName("Hạng thương binh")]
        public int? IdThuongBinhHang { get; set; }

        //ForeignKey trỏ vào table [DM].[dmHoGiaDinhChinhSach]
        [DisplayName("Gia Đình Chính Sách ")]
        public int? IdGiaDinhChinhSach { get; set; }

        //ForeignKey trỏ vào table [DM].[dmChucDanhKhoaHoc]
        [DisplayName("Chức danh khoa học ")]
        public int? IdChucDanhKhoaHoc { get; set; }

        //ForeignKey trỏ vào table [DM].[dmTrinhDoDaoTao] 
        [DisplayName("Trình độ đào tạo ")]
        public int? IdTrinhDoDaoTao { get; set; }

        //ForeignKey trỏ vào table [DM].[dmNganhDaoTao]
        [DisplayName("Chuyên môn đào tạo ")]
        public int? IdChuyenMonDaoTao { get; set; }

        //ForeignKey trỏ vào table [DM].[dmNgoaiNgu] 
        [DisplayName("Ngoại ngữ ")]
        public int? IdNgoaiNgu { get; set; }

        //ForeignKey trỏ vào table [DM].[dmKhungNangLucNgoaiNgu] 
        [DisplayName("Khung năng lực ngoại ngữ ")]
        public int? IdKhungNangLucNgoaiNguc { get; set; }

        //ForeignKey trỏ vào table [DM].[dmTrinhDoLyLuanChinhTri] 
        [DisplayName("Trình độ lý luận chính trị ")]
        public int? IdTrinhDoLyLuanChinhTri { get; set; }

        //ForeignKey trỏ vào table [DM].[dmTrinhDoQuanLyNhaNuoc] 
        [DisplayName("Trình độ quản lý nhà nước ")]
        public int? IdTrinhDoQuanLyNhaNuoc { get; set; }

        //ForeignKey trỏ vào table [DM].[dmTrinhDoTinHoc] 
        [DisplayName("Trình độ tin học ")]
        public int? IdTrinhDoTinHoc { get; set; }
    }
}
