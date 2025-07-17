using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;

namespace StudentManager.Infrastructure.Persistence.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nếu dùng Fluent API, viết cấu hình tại đây

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)                // Liên kết với bảng User
                .WithMany(u => u.UserRoles)            // Một User có thể có nhiều UserRoles
                .HasForeignKey(ur => ur.UserID);    // Khóa ngoại UserID
                                                    //.OnDelete(DeleteBehavior.Cascade);    // Hành vi khi User bị xóa

            // Cấu hình mối quan hệ giữa UserRole và Role
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)                // Liên kết với bảng Role
                .WithMany(r => r.UserRoles)            // Một Role có thể có nhiều UserRoles
                .HasForeignKey(ur => ur.RoleID);     // Khóa ngoại RoleID
                //.OnDelete(DeleteBehavior.SetNull);    // Hành vi khi Role bị xóa



            //modelBuilder.Entity<User>().HasData(
            //        new User { UserID = new Guid("33E81419-997D-4936-A2C4-060019EAF832"), UserName = "Admin", EmailAddress = "admin@gmail.com", Password = "sa@123", CreateOn = DateTime.Now }
            //    );

            //modelBuilder.Entity<Role>().HasData(
            //    new Role { RoleID = new Guid("DEB92048-6B43-45EA-A777-D4678666F874"), RoleName = "Admin" },
            //    new Role { RoleID = new Guid("98D77182-BB49-4F7C-A038-FFB7021EE426"), RoleName = "Guest" }
            //);

            //modelBuilder.Entity<UserRole>().HasData(
            //    new UserRole { UserID = new Guid("33E81419-997D-4936-A2C4-060019EAF832"), RoleID = new Guid("DEB92048-6B43-45EA-A777-D4678666F874") }
            //);


        }
    }
}
