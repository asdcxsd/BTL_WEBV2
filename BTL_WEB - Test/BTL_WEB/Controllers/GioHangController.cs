using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Models.Functions;
using BTL_WEB.Models.Entities;
using BTL_WEB.Code;
namespace BTL_WEB.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            if (Session["userLogin"] == null)
            {
                return Redirect("~/admin/Login/Index");
            }
            Func_TaiKhoan  getid = new Func_TaiKhoan();
            //UserLogin user = (UserLogin)Session["userLogin"];
            tbl_taikhoan tk = getid.getTaiKhoan((string)Session["userLogin"]);
            ViewBag.iduser = tk.id;
            return View();
        }
    }
}