using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2_MVC_Core.Models;
using _1_EFCore_1;

namespace _2_MVC_Core.Controllers {
  public class HomeController : Controller {
    private Person person;
    private User user;
    public HomeController(Person person, User user) {
      this.person = person;
      this.user = user;
    }
    public IActionResult Index() {
      return Content(person.Dance()+user.Dance());
      //return View();
    }

    public IActionResult About() {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact() {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
