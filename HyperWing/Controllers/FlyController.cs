using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyperWing.Model;
using HyperWing.BLL;
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

            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(InfoCollector.hentAlleFraFlyplasser());

        }

        public string hentTilFlyplasser(string ByFra)
        {
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(InfoCollector.hentTilFlyplasser(ByFra));

        }



        public string hentStrekning(string ByFra, string ByTil)
        {

            if (InfoCollector.hentTilgjengeligRute(ByFra, ByTil).Count == 0)
            {
                var jsonSerial = new JavaScriptSerializer();
                return jsonSerial.Serialize(InfoCollector.hentMellomlanding(ByFra, ByTil));
            }

            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(InfoCollector.hentTilgjengeligRute(ByFra, ByTil));

        }

        public ActionResult BestillReiseMellom(int id, int Id2)
        {

            Session["valgtReise"] = InfoCollector.hentValgtReise(id, Id2);

            return View();
        }

        public ActionResult BestillReiseDirekte(int id)
        {

            Session["valgtReise"] = InfoCollector.hentValgtReise(id);

            return View();
        }

        [HttpPost]
        public ActionResult BestillReiseMellom(Kunde kunde)
        {
            Session["registrertKunde"] = InfoCollector.leggTilKunde(kunde);
            return RedirectToAction("VisBestilling");
        }

        [HttpPost]
        public ActionResult BestillReiseDirekte(Kunde kunde)
        {
            Session["registrertKunde"] = InfoCollector.leggTilKunde(kunde);
            return RedirectToAction("VisBestilling");
        }

        public ActionResult VisBestilling()
        {

            Kunde kunde = (Kunde)Session["registrertKunde"];
            List<Reiser> reiser = (List<Reiser>)Session["valgtReise"];
            return View(InfoCollector.visBestilling(kunde, reiser));

        }

        public ActionResult Admin()
        {

            return Redirect("http://localhost:64693/Admin/Login");
        }
    }
}