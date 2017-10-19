using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyperWing.Models;
using HyperWing.Controllers;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace HyperWing.Controllers
{
    public class FlyController : Controller
    {
        public ActionResult Søkreise()
        {
            return View(); 
        }

        public string hentAlleFraFlyplasser()
        {
            using (var db = new FlyContext()) 
            {
                List<Reiser> alleFly = db.Reiser.ToList();

                var alleFraFly = new List<string>();

                foreach (Reiser f in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.ByFra));
                    if (funnetStrekning == null)
                    {
 
                        alleFraFly.Add(f.ByFra);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraFly);
            }
        }

        public string hentTilFlyplasser(string ByFra)
        {
            using (var db = new FlyContext())
            {
                List<Reiser> alleFly = db.Reiser.ToList();

                var alleTilFly = new List<string>();

                foreach (Reiser f in alleFly)
                {
                    if (f.ByFra != ByFra)
                    {
                        string funnetStrekning = alleTilFly.FirstOrDefault(fl => fl.Contains(f.ByFra));
                        if (funnetStrekning == null)
                        {

                            alleTilFly.Add(f.ByFra);
                        }
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleTilFly);
            }
        }

      

        public string hentStrekning(string ByFra, string ByTil)
        {
            using (var db = new FlyContext())
            {

                List<Reiser> tilgjengeligRute = db.Reiser.Where(f => f.ByTil == ByTil && f.ByFra == ByFra).ToList();

                if (tilgjengeligRute.Count == 0)
                {
                    var mellomlandinger = (from ra in db.Reiser
                                           from rb in db.Reiser
                                           where ra.ByTil == rb.ByFra && ra.ByFra == ByFra && rb.ByTil == ByTil
                                           let pris = ra.Pris + rb.Pris
                                           
                                           select new
                                           {
                                               Ankomstid = rb.Ankomstid,
                                               Avgangstid = ra.Avgangstid,
                                               ByFra = ra.ByFra,
                                               Mellomlanding = rb.ByFra,
                                               ByTil = rb.ByTil,
                                               Flyplass = ra.Flyplass,
                                               Pris = pris,
                                               RId1 = ra.RId,
                                               RId2 = rb.RId,
                                               Reisetid = ra.Reisetid + rb.Reisetid
                                           }).ToList();
                    var jsonSerial = new JavaScriptSerializer();
                    return jsonSerial.Serialize(mellomlandinger);
                }
          
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(tilgjengeligRute);
            }
        }

       


        public ActionResult BestillReiseMellom(int id, int Id2)
        {
            var db = new DB();

            List<Reiser> valgtReise = db.valgtReise(id, Id2);

            Session["valgtReise"] = valgtReise; 

            return View(); 
        }

        public ActionResult BestillReiseDirekte(int id)
        {
            var db = new DB();

            List<Reiser> valgtReise = db.valgtReise(id);

            Session["valgtReise"] = valgtReise;

            return View();
        }

        [HttpPost]
        public ActionResult BestillReiseMellom(Kunde kunde)
        {
            using (var db = new FlyContext()) {
                try {
                    db.Kunder.Add(kunde);
                    db.SaveChanges();
                }
                catch {
                }
            }
                Session["registrertKunde"] = kunde;
            return RedirectToAction("VisBestilling"); 
        }

        [HttpPost]
        public ActionResult BestillReiseDirekte(Kunde kunde)
        {
            using (var db = new FlyContext())
            {
                try
                {
                    db.Kunder.Add(kunde);
                    db.SaveChanges();
                }
                catch
                {
                }
            }
            Session["registrertKunde"] = kunde;
            return RedirectToAction("VisBestilling");
        }

        public ActionResult VisBestilling()
        {

            Kunde kunde = (Kunde)Session["registrertKunde"];
            List<Reiser> reiser = (List<Reiser>)Session["valgtReise"];

            Reiser reise1;
            Reiser reise2;

            var billett = new Billett(); 

            if (reiser.Count == 1)
            {
                reise1 = reiser[0];

                billett = new Billett()
                {
                    PersonNr = kunde.personNr,
                    Navn = kunde.navn,
                    ByFra = reise1.ByFra,
                    ByTil = reise1.ByTil,
                    Epost = kunde.epost,
                    Telefon = kunde.telefon,
                    Avgang = reise1.Avgangstid,
                    Ankomst = reise1.Ankomstid,
                    Flyplass = reise1.Flyplass,
                    Pris = reise1.Pris,
                };
            }
            else
            {
                reise1 = reiser[0];
                reise2 = reiser[1];

                billett = new Billett()
                {
                    PersonNr = kunde.personNr,
                    Navn = kunde.navn,
                    ByFra = reise1.ByFra,
                    Mellomlanding = "Mellomlanding i: " + reise2.ByFra,
                    ByTil = reise2.ByTil,
                    Epost = kunde.epost,
                    Telefon = kunde.telefon,
                    Avgang = reise2.Avgangstid,
                    Ankomst = reise1.Ankomstid,
                    Flyplass = reise1.Flyplass,
                    Pris = reise1.Pris + reise2.Pris,
                };
            }
            using (var db = new FlyContext())
            {
                try
                {
                    db.Billetter.Add(billett);
                    db.SaveChanges();
                }
                catch
                {
                }
            }
            return View(billett); 
        }

        public ActionResult Admin()
        {

            return Redirect("http://localhost:64693/Admin/Login");
        }
    }
}