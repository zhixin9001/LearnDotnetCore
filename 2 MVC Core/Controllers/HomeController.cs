using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2_MVC_Core.Models;
using _1_EFCore_1;
using _2_1MVCCoreLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace _2_MVC_Core.Controllers {
  public class HomeController : Controller {
    public Person p1 { get; set; }
    private Person person;
    private User user;
    IAdminUserService au;
    ILogService log;
    IHostingEnvironment hostingEnvironment;
    
    ILogger logger;

    public HomeController(Person person, User user, IAdminUserService au, ILogService log /*, IMemoryCache _cache*/) {
      this.person = person;
      this.user = user;
      this.au = au;
      this.log = log;
      //this.hostingEnvironment = hostingEnvironment;
      //this._cache = _cache;
    }
    public IActionResult Index() {
      //throw new Exception();
      //var au1 = HttpContext.RequestServices.GetService(typeof(IAdminUserService)) as IAdminUserService;
      //_cache.Set("k1", "v1:" + DateTime.Now.ToString(), TimeSpan.FromSeconds(5));
      log.Add("add log");
      //return Content(person.Dance() + user.Dance()+au.GetPwd("username")+","+ au1.GetPwd("au1"));
      return View();

      //string contentPath = hostingEnvironment.ContentRootPath;
      //string wwwPath = hostingEnvironment.WebRootPath;
      //string appSettingPath = Path.Combine(contentPath, wwwPath);
      //var env = hostingEnvironment.IsDevelopment();
      //return Content(env + contentPath + "," + wwwPath + "," + appSettingPath);
    }

    public IActionResult About() {
      ViewData["Message"] = "Your application description page.";
      string value;
      //if (_cache.TryGetValue("k1", out value)) {
      //  return Content(value);
      //}
      //else {
        return View();
      //}


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
