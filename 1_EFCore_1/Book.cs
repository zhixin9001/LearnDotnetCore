using System;
using System.Collections.Generic;
using System.Text;

namespace _1_EFCore_1 {
public class Book {
  public long ID { get; set; }
  public string Name { get; set; }
  public long AuthorID { get; set; }

  public Author Author { get; set; }
}
}
