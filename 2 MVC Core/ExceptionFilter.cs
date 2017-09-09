using _2_1MVCCoreLib;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_MVC_Core {
  public class ExceptionFilter : IExceptionFilter {
    ILogService logService;
    public ExceptionFilter(ILogService logService) {
      this.logService = logService;
    }

    public void OnException(ExceptionContext context) {
      logService.Add("Exception");
    }
  }
}
