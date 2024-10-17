using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDuLieuTrungTuyen
{
       public int IdDuLieuTrungTuyen { get; set; }

    [Display(Name = "Số CCCD")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD phải có đúng 12 ký tự.")]
    public string? Cccd { get; set; }

    [Display(Name = "Họ và tên")]
    public string? HoVaTen { get; set; }

    [Display(Name = "Mã tuyển sinh")]
    public string? MaTuyenSinh { get; set; }

    [Display(Name = "Khoa đào tạo trúng tuyển")]
    public string? KhoaDaoTaoTrungTuyen { get; set; }

    public int? IdDoiTuongDauVao { get; set; }
    public int? IdDoiTuongUuTien { get; set; }
    public int? IdHinhThucTuyenSinh { get; set; }
    public int? IdKhuVuc { get; set; }

    [Display(Name = "Trường THPT")]
    public string? TruongThpt { get; set; }

    [Display(Name = "Tổ hợp môn trúng tuyển")]
    public string? ToHopMonTrungTuyen { get; set; }

    [Display(Name = "Điểm môn 1")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon1 { get; set; }

    [Display(Name = "Điểm môn 2")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon2 { get; set; }

    [Display(Name = "Điểm môn 3")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon3 { get; set; }

    [Display(Name = "Điểm ưu tiên")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemUuTien { get; set; }

    [Display(Name = "Tổng điểm xét tuyển")]
    [Column(TypeName = "float")]
    public double? TongDiemXetTuyen { get; set; }

    [Display(Name = "Số quyết định trúng tuyển")]
    public string? SoQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "Ngày ban hành quyết định trúng tuyển")]
    public DateTime? NgayBanHanhQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "CT đào tạo đã tốt nghiệp trình độ ĐH")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc { get; set; }

    [Display(Name = "Ngành đã tốt nghiệp trình độ đại học")]
    public string? NganhDaTotNghiepTrinhDoDaiHoc { get; set; }

    [Display(Name = "CT đào tạo đã tốt nghiệp trình độ TS")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi { get; set; }

    [Display(Name = "Ngành đã tốt nghiệp trình độ TS")]
    public string? NganhDaTotNghiepTrinhDoThacSi { get; set; }

    [Display(Name = "Đối tượng đầu vào")]
    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    [Display(Name = "Đối tượng ưu tiên")]
    public virtual DmDoiTuongUuTien? IdDoiTuongUuTienNavigation { get; set; }

    [Display(Name = "Hình thức tuyển sinh")]
    public virtual DmHinhThucTuyenSinh? IdHinhThucTuyenSinhNavigation { get; set; }

    [Display(Name = "Khu vực")]
    public virtual DmKhuVuc? IdKhuVucNavigation { get; set; }
}
