using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class MotherShopsController : Controller
    {
        Service service;
        // GET: MotherShops
        public ActionResult Index()
        {

            return View();
        }
    }
}