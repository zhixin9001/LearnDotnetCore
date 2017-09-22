using _4_TestDTO;
using _4_TestIService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TestService {
  public class PersonService : IPersonService {
    public Task<int> AddAsync(string name, int age) {
      using (MyDbContext ctx = new MyDbContext()) {
        var p = new Person();
        ctx.Persons.Add(p);
        return ctx.SaveChangesAsync();
      }
    }

    public async Task DeleteByIdAsync(int id) {
      using (MyDbContext ctx = new MyDbContext()) {
        Person p = await ctx.Persons.FirstAsync(a => a.ID == id);
        ctx.Entry(p).State = EntityState.Deleted;
        await ctx.SaveChangesAsync();
      }
    }

    public async Task<IEnumerable<PersonDTO>> GetAllAsync() {
      List<PersonDTO> persons = new List<PersonDTO>();
      using (MyDbContext ctx = new MyDbContext()) {

        await ctx.Persons.ForEachAsync<Person>(p => {
          var person = new PersonDTO {
            Age = p.Age,
            Name = p.Name,
            ID = p.ID
          };
          persons.Add(person);
        });
        return persons;
      }

    }

    public async Task<PersonDTO> GetByIdAsync(int id) {
      using (MyDbContext ctx = new MyDbContext()) {
        Person p = await ctx.Persons.FirstAsync(a => a.ID == id);
        if (p == null) {
          return null;
        }
        else {
          var dto = new PersonDTO();
          dto.ID = p.ID;
          dto.Name = p.Name;
          dto.Age = p.Age;
          return dto;
        }
      }
    }
  }
}
