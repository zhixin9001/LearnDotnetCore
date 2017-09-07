using System;
using System.Collections.Generic;
using System.Text;

namespace _1_EFCore_1 {
  public class Person {
    private User user;
    public Person(User user) {
      this.user = user;
    }
    public long Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool? Gender { get; set; }
    public string Dance() {
      return "People.Dance"+user.Dance();
    }
    


  }
}
