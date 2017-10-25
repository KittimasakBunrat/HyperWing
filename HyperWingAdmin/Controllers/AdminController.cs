﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using HyperWing.BLL;
using HyperWing.Model;


namespace HyperWingAdmin.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Login()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin innLoggetAdmin)
        {
            if (InfoCollector.adminDB(innLoggetAdmin))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return RedirectToAction("AdminSide");
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }

        public ActionResult AdminSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                ViewBag.Innlogget = true;
                if (loggetInn)
                {
                    return View();
                }
            }

            return RedirectToAction("Login");
        }


        public ActionResult VisAdminBestilling()
        {
            return View();
        }


        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("Login");
        }

        //[ActionName("KundeListe")]
        //[HttpGet]
        public ActionResult KundeListe()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                ViewBag.Innlogget = true;
                if (loggetInn)
                {
                    return View(InfoCollector.hentKunder());
                }
            }

            return RedirectToAction("Login");
        }
    }
}