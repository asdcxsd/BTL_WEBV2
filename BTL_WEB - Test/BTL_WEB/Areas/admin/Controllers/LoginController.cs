using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WEB.Areas.admin.Models;
using BTL_WEB.Models.Functions;
using BTL_WEB.Code;
namespace BTL_WEB.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.tentaikhoan, model.matkhau);
                var quyen = dao.getIdQuyen(model.tentaikhoan, model.matkhau);
                if (result == true && quyen == 1)
                {
                    var user = dao.GetById(model.tentaikhoan);
                    var userSession = new UserLogin();
                    userSession.tentaikhoan = user.tentaikhoan;
                    userSession.id = user.id;
                    Session["username"] = userSession.tentaikhoan;
                    Session.Add(CodeConstants.tentaikhoan_session, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == true && quyen == 3)
                {
                    var user = dao.GetById(model.tentaikhoan);
                    var userSession = new UserLogin();
                    userSession.tentaikhoan = user.tentaikhoan;
                    userSession.id = user.id;
                    Session["username"] = userSession.tentaikhoan;
                    Session.Add(CodeConstants.tentaikhoan_session, userSession);
                    return Redirect("~/Home/Index");
                }   
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng.");
                    }
            }
            return View("Index");
        }   

        public ActionResult LogOut()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
     }
}