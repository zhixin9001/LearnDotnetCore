using System;
using System.Collections.Generic;
using System.Text;

namespace _2_1MVCCoreLib {
  public class AdminUserService : IAdminUserService {
    public string GetPwd(string userName) {
      return userName+"-pwd";
    }
  }
}
