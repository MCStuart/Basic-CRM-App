using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;


namespace HairSalon.Controllers
{

    public class ClientsController : Controller
    {

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            System.Console.WriteLine("Showing Client: " + clientId);
            Client client = Client.Find(clientId);
            System.Console.WriteLine("Showing Client: " + client.client_name);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View("../Clients/Show", model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        public ActionResult Delete(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            client.DeleteClient();
            return RedirectToAction("Show", model);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Update(string newName, int clientId)
        {
            Client foundClient = Client.Find(clientId);
            foundClient.Edit(newName);
            return RedirectToAction("Show");
        }

    }

}
