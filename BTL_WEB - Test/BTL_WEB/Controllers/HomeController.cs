using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Models.Entities;
using BTL_WEB.Models.Functions;

using PagedList;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        private Func_SanPham sp = new Func_SanPham();
        public Dictionary<int, string> getList_imange(int pageNumber, int pageSize)
        {
            var list = new Func_SanPham().DS_SanPham.ToList();
            int n = new Func_SanPham().DS_SanPham.Count();

            //Dictionary<int, string> listImg = new Dictionary<int, string>();
            //for (int i = 0; i < n; i++)
            //{
            //    try
            //    {
            //        listImg.Add(i, sp.getImg(list[i].id)[0]);//add ảnh lấy được vào dict
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
            Dictionary<int, string> listImg = new Dictionary<int, string>();
            for (int i = 0; i < pageSize; i++)
            {
                try
                {
                    listImg.Add(i, sp.getImg(list[(pageNumber - 1) * pageSize + i].id)[0]);//add ảnh lấy được vào dict
                }
                catch (Exception)
                {

                }
            }
            return listImg;
        }
        public ActionResult Index(int? page)
        {
            var list = new Func_SanPham().DS_SanPham.ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            Dictionary<int, string> listImg = (Dictionary<int, string>)getList_imange(pageNumber, pageSize);
            ViewBag.Anh = listImg;
            //return View(listImg);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View();
        }
        public ActionResult Show()
        {
            try
            {
                var list = new Func_SanPham().DS_SanPham.ToList();
                ViewBag.SP = list;
                if (Request.QueryString["sanpham"] == null)
                {
                    return RedirectToAction("Index");
                }
                int x = Int32.Parse(Request.QueryString["sanpham"]);
     
                
               
                foreach (var i in list)
                {
                    if (i.id == x)
                    {
                        ViewBag.sanpham = i;
                        ViewBag.linkanh =  sp.getImg(i.id)[0];
                        break;
                    }
                }
               

            }catch (Exception)
            {
                ViewBag.linkanh = null;
                ViewBag.linkanh = null;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Search(string txtString, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var model = new Func_SanPham().DS_SanPham.Where(x => x.ten.Contains(txtString)).ToList();

           
            ViewBag.Search = model;

            return View("Index",model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThuongHieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            string txtString = Request.QueryString["thuonghieu"];
            var model = new Func_SanPham().DS_SanPham.Where(x => x.id_nsx.ToString().Contains(txtString)).ToList();

            ViewBag.ThuongHieu = model;

            return View("Index", model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DanhMuc(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            string txtString = Request.QueryString["danhmuc"];
            var model = new Func_SanPham().DS_SanPham.Where(x => x.id_dm.ToString().Contains(txtString)).ToList();

            ViewBag.DanhMuc = model;

            return View("Index", model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult _MyPartial()
        {
            List<tbl_danhmuc> listDM = new Func_DanhMuc().DS_DanhMuc.ToList();
            List<tbl_nhasanxuat> listNSX = new Func_nhasanxuat().DS_NhaSanXuat.ToList();

            ViewBag.DM = listDM;
            ViewBag.NSX = listNSX;

            return PartialView();
        }
    }
}