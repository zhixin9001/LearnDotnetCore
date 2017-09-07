using System;
using System.Collections.Generic;
using System.Text;

namespace _1_EFCore_1 {
public class UserRole {
  public long ID { get; set; }
  public long UserID { get; set; }
  public long RoleID { get; set; }
  public User User { get; set; }
  public Role Role { get; set; }
}
}
