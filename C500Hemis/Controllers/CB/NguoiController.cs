﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.Models.DM;

namespace C500Hemis.Controllers.CB
{
    public class NguoiController : Controller
    {
        private readonly HemisContext _context;

        public NguoiController(HemisContext context)
        {
            _context = context;
        }

        // GET: Nguoi
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbNguoi> content = await
                    _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .ToListAsync();
                return View(content);
            } catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: Nguoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoi = await _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .FirstOrDefaultAsync(m => m.IdNguoi == id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }

                return View(tbNguoi);
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: Nguoi/Create
        public IActionResult Create()
        {
            try
            {
                //value = DmChucDanhKhoaHoc.IdChucDanhKhoaHoc text = DmChucDanhKhoaHoc.ChucDanhKhoaHoc
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc");
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao");
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao");
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc");
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach");
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh");
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu");
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu");
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc");
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh");
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao");
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri");
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc");
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: Nguoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            try
            {
                if (TbNguoiExists(tbNguoi.IdNguoi)) ModelState.AddModelError("IdNguoi", "Đã tồn tại!");
                if (ModelState.IsValid)
                {
                    _context.Add(tbNguoi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao", tbNguoi.IdDanToc);
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc", tbNguoi.IdDanToc);
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh", tbNguoi.IdGioiTinh);
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNguoi.IdNgoaiNgu);
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbNguoi.IdQuocTich);
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh", tbNguoi.IdThuongBinhHang);
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
                return View(tbNguoi);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: Nguoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoi = await _context.TbNguois.FindAsync(id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao", tbNguoi.IdDanToc);
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc", tbNguoi.IdDanToc);
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh", tbNguoi.IdGioiTinh);
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNguoi.IdNgoaiNgu);
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbNguoi.IdQuocTich);
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh", tbNguoi.IdThuongBinhHang);
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
                return View(tbNguoi);
            } catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: Nguoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            try
            {
                if (id != tbNguoi.IdNguoi)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbNguoi);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbNguoiExists(tbNguoi.IdNguoi))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "ChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
                ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "NganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
                ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "TonGiao", tbNguoi.IdDanToc);
                ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "DanToc", tbNguoi.IdDanToc);
                ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "HoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
                ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "GioiTinh", tbNguoi.IdGioiTinh);
                ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "TenKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
                ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "NgoaiNgu", tbNguoi.IdNgoaiNgu);
                ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "TenNuoc", tbNguoi.IdQuocTich);
                ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "HangThuongBinh", tbNguoi.IdThuongBinhHang);
                ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "TrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
                ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "TenTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
                ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "TrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
                ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "TrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
                return View(tbNguoi);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: Nguoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoi = await _context.TbNguois
                    .Include(t => t.IdChucDanhKhoaHocNavigation)
                    .Include(t => t.IdChuyenMonDaoTaoNavigation)
                    .Include(t => t.IdTonGiaoNavigation)
                    .Include(t => t.IdDanTocNavigation)
                    .Include(t => t.IdGiaDinhChinhSachNavigation)
                    .Include(t => t.IdGioiTinhNavigation)
                    .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                    .Include(t => t.IdNgoaiNguNavigation)
                    .Include(t => t.IdQuocTichNavigation)
                    .Include(t => t.IdThuongBinhHangNavigation)
                    .Include(t => t.IdTrinhDoDaoTaoNavigation)
                    .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                    .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                    .Include(t => t.IdTrinhDoTinHocNavigation)
                    .FirstOrDefaultAsync(m => m.IdNguoi == id);
                if (tbNguoi == null)
                {
                    return NotFound();
                }

                return View(tbNguoi);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: Nguoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbNguoi = await _context.TbNguois.FindAsync(id);
                if (tbNguoi != null)
                {
                    _context.TbNguois.Remove(tbNguoi);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool TbNguoiExists(int id)
        {
            return _context.TbNguois.Any(e => e.IdNguoi == id);
        }
    }
}
