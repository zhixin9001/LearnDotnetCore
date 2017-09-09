using System;
using System.Collections.Generic;
using System.Text;

namespace _2_1MVCCoreLib {
  public class LogService : ILogService {
    public void Add(string log) {
      Console.WriteLine(log);
    }
  }
}
