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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Domain.Entities.Action> Actions { get; set; }
        public DbSet<User_Department> User_Departments { get; set; }
        public DbSet<Department_Position> Department_Positions { get; set; }
        public DbSet<Position_Role> Position_Roles { get; set; }
        public DbSet<Role_Action> Role_Actions { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }
        public DbSet<Domain.Entities.Class> Classes { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }


        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User_Department>()
                .HasOne(ud => ud.Users)
                .WithMany(u => u.User_Departments)
                .HasForeignKey(ud => ud.UserID);

            modelBuilder.Entity<User_Department>()
                .HasOne(ud => ud.Departments)
                .WithMany(d => d.User_Departments)
                .HasForeignKey(ud => ud.DepartmentID);

            modelBuilder.Entity<Department_Position>()
                .HasOne(dp => dp.Departments)
                .WithMany(d => d.Department_Positions)
                .HasForeignKey(dp => dp.DepartmentID);

            modelBuilder.Entity<Department_Position>()
                .HasOne(dp => dp.Positions)
                .WithMany(p => p.Department_Positions)
                .HasForeignKey(dp => dp.PositionID);

            modelBuilder.Entity<Position_Role>()
                .HasOne(pr => pr.Position)
                .WithMany(p => p.Position_Roles)
                .HasForeignKey(pr => pr.PositionID);

            modelBuilder.Entity<Position_Role>()
                .HasOne(pr => pr.Role)
                .WithMany(r => r.Position_Roles)
                .HasForeignKey(pr => pr.RoleID);


            modelBuilder.Entity<Department>().HasData
            (
                new Department
                {
                    DepartmentID = Guid.Parse("AE0F6039-FEFF-4BC8-885E-D66D13B49C18"),
                    DepartmentName = "IT",
                    DepartmentCode = "IT",
                    Active = true
                },
                new Department
                {
                    DepartmentID = Guid.Parse("109A7620-F8BD-4FD4-B846-654533E8181C"),
                    DepartmentName = "Maketing",
                    DepartmentCode = "MKT",
                    Active = true
                }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    PositionID = Guid.Parse("109A7620-F8BD-4FD4-B846-654533E8181C"),
                    PositionName = "Manager",
                    PositionCode = "MGR",
                    Active = true
                },
                new Position
                {
                    PositionID = Guid.Parse("0DC8D5B1-6A04-44C0-B6A2-70C4987D646E"),
                    PositionName = "Developer",
                    PositionCode = "DEV",
                    Active = true
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = Guid.Parse("B1F2A3C4-5D6E-7F8A-9B0C-D1E2F3A4B5C6"),
                    RoleName = "User",
                    RoleCode = "USER",
                    Active = true
                },
                new Role
                {
                    RoleID = Guid.Parse("C7D8E9F0-1A2B-3C4D-5E6F-7A8B9C0D1E2F"),
                    RoleName = "Student",
                    RoleCode = "STUDENT",
                    Active = true
                }
            );


            modelBuilder.Entity<Domain.Entities.Action>().HasData(
                new Domain.Entities.Action
                {
                    ActionID = Guid.Parse("72652A32-3A06-4CF6-9C98-43EA0AC1D92D"),
                    ActionName = "Create User",
                    ActionCode = "CREATE_USER",
                    Active = true
                },
                new Domain.Entities.Action
                {
                    ActionID = Guid.Parse("EDF088E9-A8E2-41FF-947B-AF8AFBA6E1C3"),
                    ActionName = "Update User",
                    ActionCode = "UPDATE_USER",
                    Active = true
                },
                new Domain.Entities.Action
                {
                    ActionID = Guid.Parse("4801C236-5983-49AE-8B83-71B17CB29AC1"),
                    ActionName = "Delete User",
                    ActionCode = "DELETE_USER",
                    Active = true
                }
            );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = Guid.Parse("9E666A5D-8BA2-42E2-8DC4-FA560737C6A4"),
                    UserName = "Admin",
                    EmailAddress = "admin@gmail.com",
                    Password = "$2a$12$fMOWcOJCvLJwyXiV7Bnd1uR8eWB3vaXyKFnj8p6QUOAl3agAcsHle",
                    RefreshToken = string.Empty,
                    CreateOn = DateTime.Now,
                    Active = true
                }
            );

            modelBuilder.Entity<User_Department>().HasData(
                new User_Department
                {
                    UserDepartmentID = Guid.Parse("ABFC04BD-A5AD-4B75-AFF2-5565049EA948"),
                    UserID = Guid.Parse("9E666A5D-8BA2-42E2-8DC4-FA560737C6A4"),
                    DepartmentID = Guid.Parse("AE0F6039-FEFF-4BC8-885E-D66D13B49C18"),
                }
            );

            modelBuilder.Entity<Department_Position>().HasData(
                new Department_Position
                {
                    DepartmentPositionID = Guid.Parse("B2F3A4C5-6D7E-8F9A-B0C1-D2E3F4A5B6C7"),
                    DepartmentID = Guid.Parse("AE0F6039-FEFF-4BC8-885E-D66D13B49C18"),
                    PositionID = Guid.Parse("0DC8D5B1-6A04-44C0-B6A2-70C4987D646E"),
                }
            );

            modelBuilder.Entity<Position_Role>().HasData(
                new Position_Role
                {
                    PositionRoleID = Guid.Parse("A1B2C3D4-E5F6-7A8B-9C0D-E1F2A3B4C5D6"),
                    PositionID = Guid.Parse("0DC8D5B1-6A04-44C0-B6A2-70C4987D646E"),
                    RoleID = Guid.Parse("B1F2A3C4-5D6E-7F8A-9B0C-D1E2F3A4B5C6"),
                }
            );

            modelBuilder.Entity<Role_Action>().HasData(
                new Role_Action
                {
                    RoleActionID = Guid.Parse("A1B2C3D4-E5F6-7A8B-9C0D-E1F2A3B4C5D6"),
                    RoleID = Guid.Parse("B1F2A3C4-5D6E-7F8A-9B0C-D1E2F3A4B5C6"),
                    ActionID = Guid.Parse("72652A32-3A06-4CF6-9C98-43EA0AC1D92D"),
                },
                new Role_Action
                {
                    RoleActionID = Guid.Parse("A2B3C4D5-E6F7-8A9B-B0C1-D2E3F4A5B6C7"),
                    RoleID = Guid.Parse("B1F2A3C4-5D6E-7F8A-9B0C-D1E2F3A4B5C6"),
                    ActionID = Guid.Parse("EDF088E9-A8E2-41FF-947B-AF8AFBA6E1C3"),
                },
                new Role_Action
                {
                    RoleActionID = Guid.Parse("A3B4C5D6-E7F8-9A0B-C1D2-E3F4A5B6C7D8"),
                    RoleID = Guid.Parse("B1F2A3C4-5D6E-7F8A-9B0C-D1E2F3A4B5C6"),
                    ActionID = Guid.Parse("4801C236-5983-49AE-8B83-71B17CB29AC1"),
                }
            );


        }
    }
}
