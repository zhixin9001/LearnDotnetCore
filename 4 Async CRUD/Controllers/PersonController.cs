using _4_TestIService;
using _4_TestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _4_Async_CRUD.Controllers {
  public class PersonController : Controller {
    // GET: Person
    [HttpGet]
    public async Task<ActionResult> Index() {
      IPersonService ps = new PersonService();
      var persons = await ps.GetAllAsync();
      return Content(persons.Count().ToString());
    }

    [HttpPost]
    public async Task<ActionResult> AddNew() {
      IPersonService ps = new PersonService();
      var persons = await ps.GetAllAsync();
      return View(persons);
    }
  }
}