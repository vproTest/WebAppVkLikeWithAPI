using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppVkLike.EFClasses;
using WebAppVkLike.Models;

namespace WebAppVkLike.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        public JsonResult SetLike(string id)
        {           
            try
            {
                using (LikeContext content = new LikeContext())
                {
                    Page page = content.Pages.FirstOrDefault(p => p.Name == id);
                    Like like = new Like
                    {
                        LkDateTime = DateTime.Now,
                        PageId = page != null ? page.Id : 0
                    };
                    content.Likes.Add(like);
                    content.SaveChanges();
                    return Json(new
                    {
                        Message = "Ok",
                        Status = true
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    Message = ex.Message,
                    Status = false
                }, JsonRequestBehavior.AllowGet);
            }
           
        }

        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }
    }
}
