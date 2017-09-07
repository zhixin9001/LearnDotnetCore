using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _1_EFCore_1 {
  class Program {
    static void Main(string[] args) {
      using (MyDbContext ctx = new MyDbContext()) {
        //var p = new Person {
        //  Name = "asdf",
        //  Age = 12,
        //  Gender = false
        //};
        //con.Persons.Add(p);
        //con.SaveChanges();

        //var books = ctx.Books.Include(a => a.Author).First();
        var p = ctx.Persons;

        var user = ctx.Users.First();
        long userID = user.ID;
        var rel = ctx.UserRoles.Include(a=>a.Role).Where(r => r.UserID == userID);

      }
      Console.WriteLine("Hello World!");
    }
  }
}
