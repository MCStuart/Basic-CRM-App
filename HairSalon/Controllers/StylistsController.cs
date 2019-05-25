using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{

    public class StylistsController : Controller
    {

        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string stylistName)
        {
            Stylist newStylist = new Stylist(0, stylistName);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{stylistId}")]
        public ActionResult Show(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("client", stylistClients);
            model.Add("specialty", allSpecialties);
            model.Add("stylistSpecialties", stylistSpecialties);
            return View("Show", model);
        }

        [HttpPost("/stylists/{stylistId}/addSpecialty")]
        public ActionResult AddSpecialty(int stylistId, int id)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            foundStylist.AddSpecialty(id);
            return RedirectToAction("Show");
        }


        [HttpPost("/stylists/{stylistId}/clients/new")]
        public ActionResult CreateClient(int stylistId, string clientName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(stylistId);
            List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAll();
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("client", stylistClients);
            return RedirectToAction("Show", model);
        }

        [HttpPost("/stylists/delete")]
        public ActionResult DeleteStylists()
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/deleteClients")]
        public ActionResult DeleteClients(int stylistId)
        {
            Stylist foundStylist = Stylist.Find(stylistId);
            List<Client> stylistClients = foundStylist.GetClients();
            foreach(Client client in stylistClients)
            {
                client.DeleteClient();
            }
            return RedirectToAction("Show");
        }


        [HttpGet("/stylists/{stylistId}/edit")]
        public ActionResult Edit(int stylistId)
        {
            Stylist selectedStylist = Stylist.Find(stylistId);
            return View(selectedStylist);
        }
    }

}
