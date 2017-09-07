using RupengBBS.Service;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RuPengBBS.Service.Configs;

namespace _1_EFCore_1 {
  class PersonConfig : EntityTypeConfiguration<Person> {
    public override void Map(EntityTypeBuilder<Person> builder) {
      builder.ToTable("T_Persons");
    }
  }
}
