﻿using MvcBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        private QLBanSachEntities db = new QLBanSachEntities();
        // GET: BookStore

        private List<SACH> LaySacMoi(int count)
        {
            return db.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var sachmoi = LaySacMoi(5);
            return View(sachmoi);
        }

        public ActionResult ChuDe()
        {
            var chude = db.CHUDEs.ToList();
            return View(chude);
        }

        public ActionResult NhaXuatBan()
        {
            var chude = db.NHAXUATBANs.ToList();
            return View(chude);
        }

        public ActionResult SPTheoChuDe(int id)
        {
            var sach = db.SACHes.Where(c => c.MaCD == id).ToList();
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = db.SACHes.Where(c => c.MaNXB == id).ToList();
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = db.SACHes.SingleOrDefault(c => c.Masach == id); // Lấy sách theo id
            if (sach == null)
            {
                return HttpNotFound(); // Nếu không tìm thấy sách, trả về lỗi 404
            }
            return View(sach); // Trả về view cùng với dữ liệu sách
        }
    }
}