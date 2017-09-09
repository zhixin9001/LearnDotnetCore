using System;
using System.Collections.Generic;
using System.Text;

namespace _2_1MVCCoreLib {
  public interface IAdminUserService:IServiceTag {
    string GetPwd(string userName);
  }
}
