using System;
using System.Collections.Generic;
using System.Text;

namespace _2_1MVCCoreLib {
  public interface ILogService : IServiceTag {
    void Add(string log);
  }

  public interface IServiceTag { }
}
