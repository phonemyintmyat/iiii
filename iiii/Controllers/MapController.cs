using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iiii.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult map(int rid)
        {
            ViewBag.id = rid;
            return View();
        }
    }
}