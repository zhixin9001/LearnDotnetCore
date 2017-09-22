using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3._5_Async_in_MVC.Models;
using System.IO;

namespace _3._5_Async_in_MVC.Controllers {
  public class HomeController : Controller {
    public async Task<IActionResult> Index() {
      using (FileStream stream = System.IO.File.OpenRead("d:/ckcore.txt"))
      using (StreamReader st = new StreamReader(stream)) {
        string txt = await st.ReadToEndAsync();
        return Content(txt);
      }
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
