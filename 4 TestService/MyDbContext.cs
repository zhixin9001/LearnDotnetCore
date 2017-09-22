using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TestService {
  public class MyDbContext : DbContext {
    public MyDbContext() : base("connStr") { }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Person>().ToTable("T_Persons");
    }
  }
}
