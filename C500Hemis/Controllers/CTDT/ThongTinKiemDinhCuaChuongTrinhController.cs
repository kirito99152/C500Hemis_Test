using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.API;
using C500Hemis.Models.DM;
using Newtonsoft.Json;

namespace C500Hemis.Controllers.CTDT
{
    public class ThongTinKiemDinhCuaChuongTrinhController : Controller
    {
        private readonly ApiServices ApiServices_;

        public ThongTinKiemDinhCuaChuongTrinhController(ApiServices services)
        {
            ApiServices_ = services;
        }

        private async Task<List<TbThongTinKiemDinhCuaChuongTrinh>> TbThongTinKiemDinhCuaChuongTrinhs() {
            List<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs = await ApiServices_.GetAll<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh");
            List<TbChuongTrinhDaoTao> tbChuongTrinhDaoTaos = await ApiServices_.GetAll<TbChuongTrinhDaoTao>("/api/ctdt/ChuongTrinhDaoTao");
            List<DmKetQuaKiemDinh> dmKetQuaKiemDinhs = await ApiServices_.GetAll<DmKetQuaKiemDinh>("/api/dm/KetQuaKiemDinh");
            List<DmToChucKiemDinh> dmToChucKiemDinhs = await ApiServices_.GetAll<DmToChucKiemDinh>("/api/dm/ToChucKiemDinh");
            TbThongTinKiemDinhCuaChuongTrinhs.ForEach(item => {
                item.IdChuongTrinhDaoTaoNavigation = tbChuongTrinhDaoTaos.FirstOrDefault(t => t.IdChuongTrinhDaoTao == item.IdChuongTrinhDaoTao);
                item.IdKetQuaKiemDinhNavigation = dmKetQuaKiemDinhs.FirstOrDefault(t => t.IdKetQuaKiemDinh == item.IdKetQuaKiemDinh);
                item.IdToChucKiemDinhNavigation = dmToChucKiemDinhs.FirstOrDefault(t => t.IdToChucKiemDinh == item.IdToChucKiemDinh);
            });
            return TbThongTinKiemDinhCuaChuongTrinhs;
        }
        private async Task Selectlist(TbThongTinKiemDinhCuaChuongTrinh? tbThongTinKiemDinhCuaChuongTrinh = null) {
            if (tbThongTinKiemDinhCuaChuongTrinh == null) {
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<TbChuongTrinhDaoTao>("/api/ctdt/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao");
                ViewData["IdKetQuaKiemDinh"] = new SelectList(await ApiServices_.GetAll<DmKetQuaKiemDinh>("/api/dm/KetQuaKiemDinh"), "IdKetQuaKiemDinh", "IdKetQuaKiemDinh");
                ViewData["IdToChucKiemDinh"] = new SelectList(await ApiServices_.GetAll<DmToChucKiemDinh>("/api/dm/ToChucKiemDinh"), "IdToChucKiemDinh", "IdToChucKiemDinh");
            } else {
                ViewData["IdChuongTrinhDaoTao"] = new SelectList(await ApiServices_.GetAll<TbChuongTrinhDaoTao>("/api/ctdt/ChuongTrinhDaoTao"), "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
                ViewData["IdKetQuaKiemDinh"] = new SelectList(await ApiServices_.GetAll<DmKetQuaKiemDinh>("/api/dm/KetQuaKiemDinh"), "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
                ViewData["IdToChucKiemDinh"] = new SelectList(await ApiServices_.GetAll<DmToChucKiemDinh>("/api/dm/ToChucKiemDinh"), "IdToChucKiemDinh", "IdToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
            }
        }
        // GET: ThongTinKiemDinhCuaChuongTrinh
        public async Task<IActionResult> Index()
        {
            List<TbThongTinKiemDinhCuaChuongTrinh> tbThongTinKiemDinhCuaChuongTrinhs = await TbThongTinKiemDinhCuaChuongTrinhs();
            return View(tbThongTinKiemDinhCuaChuongTrinhs);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinhs = await TbThongTinKiemDinhCuaChuongTrinhs();
            var tbThongTinKiemDinhCuaChuongTrinh = tbThongTinKiemDinhCuaChuongTrinhs.FirstOrDefault(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Create
        public async Task<IActionResult> Create()
        {
            await Selectlist();
            return View();
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            foreach (var state in ModelState) {
                foreach (var error in state.Value.Errors) {
                    return Content(error.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                await ApiServices_.Create<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh", tbThongTinKiemDinhCuaChuongTrinh);
                return RedirectToAction(nameof(Index));
            }
            await Selectlist(tbThongTinKiemDinhCuaChuongTrinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinh = await ApiServices_.GetId<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh", id ?? 0);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }
            await Selectlist(tbThongTinKiemDinhCuaChuongTrinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            if (id != tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ApiServices_.Update<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh", id, tbThongTinKiemDinhCuaChuongTrinh);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TbThongTinKiemDinhCuaChuongTrinhExists(tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh)))
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
            await Selectlist(tbThongTinKiemDinhCuaChuongTrinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinhs = await TbThongTinKiemDinhCuaChuongTrinhs();
            var tbThongTinKiemDinhCuaChuongTrinh = tbThongTinKiemDinhCuaChuongTrinhs.FirstOrDefault(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ApiServices_.Delete<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh", id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TbThongTinKiemDinhCuaChuongTrinhExists(int id)
        {
            var tbThongTinKiemDinhCuaChuongTrinh = await ApiServices_.GetId<TbThongTinKiemDinhCuaChuongTrinh>("/api/ctdt/ThongTinKiemDinhCuaChuongTrinh", id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return false;
            }
            return true;
        }
    }
}
