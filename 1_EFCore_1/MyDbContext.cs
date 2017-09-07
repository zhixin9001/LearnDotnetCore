using Microsoft.EntityFrameworkCore;
using RuPengBBS.Service.Configs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _1_EFCore_1 {
  public class MyDbContext : DbContext {
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseMySql("Server=192.168.0.104;database=test1;uid=root;pwd=040207");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      //var etPerson = modelBuilder.Entity<Person>();
      //etPerson.ToTable("T_Persons");

      modelBuilder.AddEntityConfigurationsFromAssembly(Assembly.GetEntryAssembly());
      var author = modelBuilder.Entity<Author>().ToTable("T_Authors");
      var book = modelBuilder.Entity<Book>();
      book.ToTable("T_Books");
      book.HasOne(a => a.Author).WithMany().HasForeignKey(a => a.AuthorID).IsRequired();

      modelBuilder.Entity<User>().ToTable("T_Users");
      modelBuilder.Entity<Role>().ToTable("T_Roles");
      var userRole = modelBuilder.Entity<UserRole>().ToTable("T_UserRole");
      userRole.HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserID).IsRequired();
      userRole.HasOne(a => a.Role).WithMany().HasForeignKey(a => a.RoleID).IsRequired();
    }
  }
}
