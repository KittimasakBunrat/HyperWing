using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using HyperWing.Controllers;
using HyperWing.BLL;
using HyperWing.DAL;
using System.Collections.Generic;
using HyperWing.Model;

namespace Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void KundeListe_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var forventetResultat = new List<Kunde>();
            var kunde = new Kunde()
            {
                Id = 1,
                navn = "Shohaib Bunrat",
                epost = "knoll@tott.com",
                telefon = 12345678,
                personNr = "987654321",

            };
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);

            // Act
            var actionResult = (ViewResult)controller.ListeKunder();
            var resultat = (List<Kunde>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].Id, resultat[i].Id);
                Assert.AreEqual(forventetResultat[i].navn, resultat[i].navn);
                Assert.AreEqual(forventetResultat[i].epost, resultat[i].epost);
                Assert.AreEqual(forventetResultat[i].telefon, resultat[i].telefon);
                Assert.AreEqual(forventetResultat[i].personNr, resultat[i].personNr);
            }
        }
        [TestMethod]
        public void FlyplassListe_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var forventetResultat = new List<Flyplasser>();
            var flyplass = new Flyplasser()
            {
                FId = 1,
                Navn = "OSL - Oslo Lufthavn",
            };
            forventetResultat.Add(flyplass);
            forventetResultat.Add(flyplass);
            forventetResultat.Add(flyplass);

            // Act
            var actionResult = (ViewResult)controller.ListeFlyplasser();
            var resultat = (List<Flyplasser>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].FId, resultat[i].FId);
                Assert.AreEqual(forventetResultat[i].Navn, resultat[i].Navn);
            }
        }
        [TestMethod]
        public void BillettListe_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var forventetResultat = new List<Billett>();
            var billett = new Billett()
            {
                Id = 1,
                PersonNr = "987654321",
                Navn = "Shohaib Bunrat",
                ByFra = "Oslo",
                Mellomlanding = "Amsterdam",
                ByTil = "Hong Kong",
                Epost = "knoll@tott.com",
                Telefon = 12345678,
                Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                Flyplass = "OSL - Oslo Lufthavn",
                Pris = (int)789.99,

            };
            forventetResultat.Add(billett);
            forventetResultat.Add(billett);
            forventetResultat.Add(billett);

            // Act
            var actionResult = (ViewResult)controller.ListeBilletter();
            var resultat = (List<Billett>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].Id, resultat[i].Id);
                Assert.AreEqual(forventetResultat[i].PersonNr, resultat[i].PersonNr);
                Assert.AreEqual(forventetResultat[i].Navn, resultat[i].Navn);
                Assert.AreEqual(forventetResultat[i].ByFra, resultat[i].ByFra);
                Assert.AreEqual(forventetResultat[i].Mellomlanding, resultat[i].Mellomlanding);
                Assert.AreEqual(forventetResultat[i].ByTil, resultat[i].ByTil);
                Assert.AreEqual(forventetResultat[i].Epost, resultat[i].Epost);
                Assert.AreEqual(forventetResultat[i].Telefon, resultat[i].Telefon);
                Assert.AreEqual(forventetResultat[i].Avgang, resultat[i].Avgang);
                Assert.AreEqual(forventetResultat[i].Ankomst, resultat[i].Ankomst);
                Assert.AreEqual(forventetResultat[i].Flyplass, resultat[i].Flyplass);
                Assert.AreEqual(forventetResultat[i].Pris, resultat[i].Pris);
            }
        }
        [TestMethod]
        public void ReiseListe_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var forventetResultat = new List<Reiser>();
            var reise = new Reiser()
            {
                RId = 1,
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Flyplass = "OSL - Oslo Lufthavn",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                Reisetid = "0t 55m",
                Pris = (int)659.99,
                Informasjon = null,
                FId = 1,

            };
            forventetResultat.Add(reise);
            forventetResultat.Add(reise);
            forventetResultat.Add(reise);

            // Act
            var actionResult = (ViewResult)controller.ListeReiser();
            var resultat = (List<Reiser>)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].RId, resultat[i].RId);
                Assert.AreEqual(forventetResultat[i].ByFra, resultat[i].ByFra);
                Assert.AreEqual(forventetResultat[i].ByTil, resultat[i].ByTil);
                Assert.AreEqual(forventetResultat[i].ByFra, resultat[i].ByFra);
                Assert.AreEqual(forventetResultat[i].Flyplass, resultat[i].Flyplass);
                Assert.AreEqual(forventetResultat[i].ByTil, resultat[i].ByTil);
                Assert.AreEqual(forventetResultat[i].Avgangstid, resultat[i].Avgangstid);
                Assert.AreEqual(forventetResultat[i].Ankomstid, resultat[i].Ankomstid);
                Assert.AreEqual(forventetResultat[i].Reisetid, resultat[i].Reisetid);
                Assert.AreEqual(forventetResultat[i].Pris, resultat[i].Pris);
                Assert.AreEqual(forventetResultat[i].Informasjon, resultat[i].Informasjon);
                Assert.AreEqual(forventetResultat[i].FId, resultat[i].FId);
            }
        }

        [TestMethod]
        public void RegistrerKunde_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.RegistrerKunde();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerKunde_Post_OK()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            var innKunde = new Kunde()
            {
                navn = "Shohaib Bunrat",
                epost = "knoll@tott.com",
                telefon = 12345678,
                personNr = "987654321"
            };
            // Act
            var resultat = (RedirectToRouteResult)controller.RegistrerKunde(innKunde);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "ListeKunder");
        }
        [TestMethod]
        public void RegistrerKunde_Post_Model_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("navn", "Ikke oppgitt navn");

            // Act
            var actionResult = (ViewResult)controller.RegistrerKunde(innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerKunde_Post_DB_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innKunde = new Kunde();
            innKunde.navn = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerKunde(innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void RegistrerFlyplass_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.RegistrerFlyplass();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerFlyplass_Post_OK()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            var innFlyplass = new Flyplasser()
            {
                FId = 1,
                Navn = "OSL - Oslo Lufthavn"
            };
            // Act
            var resultat = (RedirectToRouteResult)controller.RegistrerFlyplass(innFlyplass);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "ListeFlyplasser");
        }
        [TestMethod]
        public void RegistrerFlyplass_Post_Model_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innFlyplass = new Flyplasser();
            controller.ViewData.ModelState.AddModelError("Navn", "Ikke oppgitt navn");

            // Act
            var actionResult = (ViewResult)controller.RegistrerFlyplass(innFlyplass);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerFlyplass_Post_DB_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innFlyplass = new Flyplasser();
            innFlyplass.Navn = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerFlyplass(innFlyplass);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void RegistrerBillett_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.RegistrerBillett();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerBillett_Post_OK()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            var innBillett = new Billett()
            {
                Id = 1,
                PersonNr = "987654321",
                Navn = "Shohaib Bunrat",
                ByFra = "Oslo",
                Mellomlanding = "Amsterdam",
                ByTil = "Hong Kong",
                Epost = "knoll@tott.com",
                Telefon = 12345678,
                Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                Flyplass = "OSL - Oslo Lufthavn",
                Pris = (int)789.99
            };
            // Act
            var resultat = (RedirectToRouteResult)controller.RegistrerBillett(innBillett);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "ListeBilletter");
        }
        [TestMethod]
        public void RegistrerBillett_Post_Model_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innBillett = new Billett();
            controller.ViewData.ModelState.AddModelError("Navn", "Ikke oppgitt navn");

            // Act
            var actionResult = (ViewResult)controller.RegistrerBillett(innBillett);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerBillett_Post_DB_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innBillett = new Billett();
            innBillett.ByFra = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerBillett(innBillett);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void RegistrerReise_vis_view()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.RegistrerReise();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerReise_Post_OK()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            var innReise = new Reiser()
            {
                RId = 1,
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Flyplass = "OSL - Oslo Lufthavn",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                Reisetid = "0t 55m",
                Pris = (int)659.99,
                Informasjon = null,
                FId = 1
            };
            // Act
            var resultat = (RedirectToRouteResult)controller.RegistrerReise(innReise);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "ListeReiser");
        }
        [TestMethod]
        public void RegistrerReise_Post_Model_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innReise = new Reiser();
            controller.ViewData.ModelState.AddModelError("ByFra", "Ikke oppgitt ByFra");

            // Act
            var actionResult = (ViewResult)controller.RegistrerReise(innReise);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerReise_Post_DB_feil()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innReise = new Reiser();
            innReise.ByFra = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerReise(innReise);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void EndreKunde()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreKunde(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreKunde_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreKunde(0);
            var kundeResultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(kundeResultat.Id, 0);
        }
        [TestMethod]
        public void EndreKunde_ikke_funnet_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innKunde = new Kunde()
            {
                Id = 0,
                navn = "Shohaib Bunrat",
                epost = "knoll@tott.com",
                telefon = 12345678,
                personNr = "987654321"
            };

            // Act
            var actionResult = (ViewResult)controller.EndreKunde(0, innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreKunde_feil_validering_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreKunde(0, innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreKunde_funnet()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innKunde = new Kunde()
            {
                navn = "Shohaib Bunrat",
                epost = "knoll@tott.com",
                telefon = 12345678,
                personNr = "987654321"
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.EndreKunde(1, innKunde);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListeKunder");
        }

        [TestMethod]
        public void EndreFlyplass()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreFlyplass(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreFlyplass_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreFlyplass(0);
            var flyplassResultat = (Flyplasser)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(flyplassResultat.FId, 0);
        }
        [TestMethod]
        public void EndreFlyplass_ikke_funnet_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innFlyplass = new Flyplasser()
            {
                FId = 1,
                Navn = "OSL - Oslo Lufthavn"
            };

            // Act
            var actionResult = (ViewResult)controller.EndreFlyplass(0, innFlyplass);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreFlyplass_feil_validering_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innFlyplass = new Flyplasser();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreFlyplass(0, innFlyplass);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreFlyplass_funnet()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innFlyplass = new Flyplasser()
            {
                Navn = "OSL - Oslo Lufthavn"
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.EndreFlyplass(1, innFlyplass);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListeFlyplasser");
        }

        [TestMethod]
        public void EndreBillett()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreBillett(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreBillett_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreBillett(0);
            var billettResultat = (Billett)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(billettResultat.Id, 0);
        }
        [TestMethod]
        public void EndreBillett_ikke_funnet_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innBillett = new Billett()
            {
                Id = 1,
                PersonNr = "987654321",
                Navn = "Shohaib Bunrat",
                ByFra = "Oslo",
                Mellomlanding = "Amsterdam",
                ByTil = "Hong Kong",
                Epost = "knoll@tott.com",
                Telefon = 12345678,
                Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                Flyplass = "OSL - Oslo Lufthavn",
                Pris = (int)789.99
            };

            // Act
            var actionResult = (ViewResult)controller.EndreBillett(0, innBillett);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreBillett_feil_validering_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innBillett = new Billett();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreBillett(0, innBillett);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreBillett_funnet()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innBillett = new Billett()
            {
                PersonNr = "987654321",
                Navn = "Shohaib Bunrat",
                ByFra = "Oslo",
                Mellomlanding = "Amsterdam",
                ByTil = "Hong Kong",
                Epost = "knoll@tott.com",
                Telefon = 12345678,
                Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                Flyplass = "OSL - Oslo Lufthavn",
                Pris = (int)789.99
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.EndreBillett(1, innBillett);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListeBilletter");
        }

        [TestMethod]
        public void EndreReise()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreReise(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreReise_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EndreReise(0);
            var reiseResultat = (Reiser)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(reiseResultat.RId, 0);
        }
        [TestMethod]
        public void EndreReise_ikke_funnet_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innReise = new Reiser()
            {
                RId = 1,
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Flyplass = "OSL - Oslo Lufthavn",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                Reisetid = "0t 55m",
                Pris = (int)659.99,
                Informasjon = null,
                FId = 1
            };

            // Act
            var actionResult = (ViewResult)controller.EndreReise(0, innReise);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreReise_feil_validering_Post()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innReise = new Reiser();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreReise(0, innReise);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreReise_funnet()
        {
            // Arrange
            var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
            var innReise = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Flyplass = "OSL - Oslo Lufthavn",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                Reisetid = "0t 55m",
                Pris = (int)659.99,
                Informasjon = null,
                FId = 1
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.EndreReise(1, innReise);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "ListeReiser");
        }
    }
}
