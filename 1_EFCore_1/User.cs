﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _1_EFCore_1 {
  public class User {
    public long ID { get; set; }
    public string Name { get; set; }
    public string Dance() {
      return "User.Dance";
    }
  }
}
