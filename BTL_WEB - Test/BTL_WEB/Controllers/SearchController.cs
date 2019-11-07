using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Models.Entities;
using BTL_WEB.Models.Functions;
using PagedList;
using PagedList.Mvc;

namespace BTL_WEB.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private MyDBContext context = new MyDBContext();
        private Func_SanPham sp = new Func_SanPham();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DanhMuc(int? id, int? page)
        {
            id = Convert.ToInt32(Request.QueryString["danhmuc"]);
            ViewBag.id_dm = id;

            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var model = new Func_SanPham().DS_SanPham.Where(x => x.id_dm == id).ToList();
            ViewBag.DanhMuc = model;

            return View("DanhMuc", model.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThuongHieu(int? id, int? page)
        {
            id = Convert.ToInt32(Request.QueryString["thuonghieu"]);
            ViewBag.id_nsx = id;

            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var model = new Func_SanPham().DS_SanPham.Where(x => x.id_nsx == id).ToList();
            ViewBag.ThuongHieu = model;

            return View("ThuongHieu", model.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult PriceSearch(int? price_max, int? price_min, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var model = new Func_SanPham().DS_SanPham.Where(x => x.gia >= price_min * 1000000 && x.gia <= price_max * 1000000).ToList();
            ViewBag.PriceSearch = model;

            return View("PriceSearch", model.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult NameSearch(string txtString, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var model = new Func_SanPham().DS_SanPham.Where(x => x.ten.Contains(txtString)).ToList();
            ViewBag.Search = model;

            return View("NameSearch", model.ToPagedList(pageNumber, pageSize));
        }
    }
}