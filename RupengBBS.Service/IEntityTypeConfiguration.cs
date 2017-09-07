using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace RuPengBBS.Service.Configs {
  public interface IEntityTypeConfiguration {
    void Map(ModelBuilder builder);
  }
  public interface IEntityTypeConfiguration<T> : IEntityTypeConfiguration where T : class {

    void Map(EntityTypeBuilder<T> builder);
  }
}