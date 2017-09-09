using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2_2_MVCCore.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace _2_2_MVCCore.Controllers {
  public class HomeController : Controller {
    IMemoryCache _cache;
    ILogger logger;
    public HomeController(IMemoryCache cache, ILogger<HomeController> logger) {
      this._cache = cache;
      this.logger = logger;
    }

    public IActionResult Index() {
      _cache.Set("name", DateTime.Now.ToString(), TimeSpan.FromSeconds(5));
      HttpContext.Session.SetString("session1", "session1-v");
      Debug.WriteLine("w s");
      logger.LogInformation(new EventId(), "############%%%%%%%%%%%%%%%%");

      return View();
    }

    public IActionResult About() {
      ViewData["Message"] = "Your application description page.";
      string session = HttpContext.Session.GetString("session1");
      Debug.WriteLine(session);
      string value;
      if (_cache.TryGetValue("name", out value)) {
        return Content(value + "," + session);
      }
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
