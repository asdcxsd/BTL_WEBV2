using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Models.Entities;
using BTL_WEB.Models.Functions;
namespace BTL_WEB.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: admin/Product
        public ActionResult Index()
        {
            ViewBag.select = "product";
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            int? add = null;
            if (Request.QueryString["add"]!= null) 
              add = Int32.Parse(Request.QueryString["add"]);
            if (add != null) ViewBag.add = add;
            
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            int? res = null;
            tbl_sanpham data = new tbl_sanpham();
            try
            {
                data.ten = Request.QueryString["tensp"];
                data.thenho = Request.QueryString["thenhosp"];
                data.gia = Int32.Parse(Request.QueryString["giasp"]);
                data.trongluong = Request.QueryString["trongluongsp"];
                data.soluong = Int32.Parse(Request.QueryString["soluongsp"]);

                data.ROM = Request.QueryString["romsp"];
                data.RAM = Request.QueryString["ramsp"];
                data.baohanh = Request.QueryString["thoigianbaohanhsp"];
                data.camera_sau = Request.QueryString["camerasausp"];
                data.camera_truoc = Request.QueryString["cameratruocsp"];
                data.CPU = Request.QueryString["cpusp"];
                data.manhinh = Request.QueryString["manhinhsp"];
                data.pin = Int32.Parse(Request.QueryString["pinsp"]);
                data.tinhtrang = 1;
                data.id_nsx = Int32.Parse(Request.QueryString["nhasanxuatsp"]);
                data.bluetooth = Int32.Parse(Request.QueryString["bluetoothsp"]);
                Func_SanPham tp = new Func_SanPham();
                res = tp.Insert(data);
            }
            catch
            {
                res = -1;
            }

            
            if (res != null) ViewBag.add = res;
            else ViewBag.add = -1;
            return RedirectToAction("Add", new {
                add = res
            });
        }

    }
}