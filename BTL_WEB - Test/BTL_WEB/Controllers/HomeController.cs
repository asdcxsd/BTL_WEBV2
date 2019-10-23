using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Models.Entities;
using BTL_WEB.Models.Functions;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        private Func_SanPham sp = new Func_SanPham();
        public Dictionary<int, string> getList_imange()
        {
            var list = new Func_SanPham().DS_SanPham.ToList();
            int n = new Func_SanPham().DS_SanPham.Count();

            Dictionary<int, string> listImg = new Dictionary<int, string>();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    listImg.Add(i, sp.getImg(list[i].id)[0]);//add ảnh lấy được vào dict
                }
                catch (Exception)
                {

                }
            }
            return listImg;
        }
        public ActionResult Index()
        {
            var list = new Func_SanPham().DS_SanPham.ToList();
            ViewBag.SP = list;
     
            ViewBag.Anh = (Dictionary<int, string>) getList_imange();

            return View(list);
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
        public ActionResult Search(string txtString)
        {
            var model = new Func_SanPham().DS_SanPham.Where(x => x.ten.Contains(txtString)).ToList();

           
            ViewBag.Search = model;

            return View("Index",model);
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult _MyPartial()
        {
            return PartialView();
        }
    }
}