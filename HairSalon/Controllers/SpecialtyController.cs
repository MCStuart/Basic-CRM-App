using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {

    // [HttpGet("/specialties")]
    // public ActionResult Index()
    // {
    //   List<Specialty> allSpecialties = Specialty.GetAll();
    //   return View(allSpecialties);
    // }
    //
    // [HttpGet("/specialties/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    //
    // [HttpPost("/specialties")]
    // public ActionResult Create(string specialtyStyle)
    // {
    //   Specialty newSpecialty = new Specialty(specialtyStyle);
    //   newSpecialty.Save();
    //   List<Specialty> allSpecialties = Specialty.GetAll();
    //   return View("Index", allSpecialties);
    // }
    //
    // [HttpGet("/specialties/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Specialty selectedSpecialty = Specialty.Find(id);
    //   List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
    //   model.Add("specialty", selectedSpecialty);
    //   model.Add("stylists", specialtyStylists);
    //   return View(model);
    // }
    //
    // [HttpPost("/specialties/{specialtyId}/stylists")]
    // public ActionResult Create(int specialtyId, string stylistStyle)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Specialty foundSpecialty = Specialty.Find(specialtyId);
    //   Stylist newStylist = new Stylist(stylistStyle, foundSpecialty.GetId());
    //   newStylist.Save();
    //   List<Stylist> specialtyStylists = foundSpecialty.GetStylists();
    //   model.Add("stylist", specialtyStylists);
    //   model.Add("specialty", newStylist);
    //   return View("Show", model);
    // }

  }
}
