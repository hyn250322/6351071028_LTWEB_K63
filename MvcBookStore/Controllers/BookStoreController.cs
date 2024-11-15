using MvcBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;
using System.Web.UI;

namespace MvcBookStore.Controllers
{

    public class BookStoreController : Controller
    {
        private QLBanSachEntities db = new QLBanSachEntities();
        // GET: BookStore
        public static string RemoveHtmlTags(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", String.Empty);
        }
        private List<SACH> LaySachMoi(int count)
        {
            return db.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            var sachmoi = LaySachMoi(8);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
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

        public ActionResult SPTheoChuDe(int id, int? page)
        {
            int pageSize = 2;
            int pageNum = (page ?? 1);
            var sach = db.SACHes.Where(c => c.MaCD == id).ToList();

            return View(sach.ToPagedList(pageNum, pageSize));
        }

        public ActionResult SPTheoNXB(int id, int? page)
        {
            int pageSize = 2; // Số sách hiển thị mỗi trang
            int pageNum = (page ?? 1); // Lấy trang hiện tại, mặc định là trang 1
            var sach = db.SACHes.Where(c => c.MaNXB == id).ToList();

            // Trả về View với dữ liệu phân trang
            return View(sach.ToPagedList(pageNum, pageSize));
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