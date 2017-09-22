using _4_TestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TestIService {
  public interface IPersonService {
    Task<int> AddAsync(string name, int age);
    Task DeleteByIdAsync(int id);
    Task<PersonDTO> GetByIdAsync(int id);
    Task<IEnumerable<PersonDTO>> GetAllAsync();
  }
}
