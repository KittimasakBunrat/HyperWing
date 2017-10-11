using HyperWingAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;

namespace HyperWingAdmin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            // vis innlogging
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
        public ActionResult Index(bruker innLogget)
        {
            // sjekk om innlogging OK
            if (bruker_i_db(innLogget))
            {
                // ja brukernavn og passord er OK!
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                // ja brukernavn og passord er OK!
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }
        public ActionResult Registrer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer(bruker innBruker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new BrukerContext())
            {
                try
                {
                    var nyBruker = new dbBruker();
                    string salt = lagSalt();
                    var passordOgSalt = innBruker.Passord + salt;
                    byte[] passordDB = lagHash(passordOgSalt);
                    nyBruker.Navn = innBruker.Navn;
                    nyBruker.Passord = passordDB;
                    nyBruker.Salt = salt;
                    db.Brukere.Add(nyBruker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        }
        private static byte[] lagHash(string innStreng)
        {
            byte[] innData, utData;
            var algoritme = SHA256.Create();
            innData = Encoding.UTF8.GetBytes(innStreng);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        private static string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        private static bool bruker_i_db(bruker innBruker)
        {
            using (var db = new BrukerContext())
            {
                dbBruker funnetBruker = db.Brukere.FirstOrDefault(b => b.Navn == innBruker.Navn);
                if (funnetBruker != null)
                {
                    byte[] passordForTest = lagHash(innBruker.Passord + funnetBruker.Salt);
                    bool riktigBruker = funnetBruker.Passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult InnloggetSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("index");
        }

        public ActionResult DecryptHash()
        {
            return View();
        }

        public string HashStreng(string innStreng)
        {
            byte[] hash = lagHash(innStreng);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2")); // konverterer byte'ene til en char (streng) av hex-tegn.
            }
            return sb.ToString();
        }
    }
}