using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolID);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegistrations",
                columns: table => new
                {
                    StudentRegistrationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasStarted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegistrations", x => x.StudentRegistrationID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Department_Positions",
                columns: table => new
                {
                    DepartmentPositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Positions", x => x.DepartmentPositionID);
                    table.ForeignKey(
                        name: "FK_Department_Positions_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_Positions_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position_Roles",
                columns: table => new
                {
                    PositionRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position_Roles", x => x.PositionRoleID);
                    table.ForeignKey(
                        name: "FK_Position_Roles_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Position_Roles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Position_Roles_Roles_RoleID1",
                        column: x => x.RoleID1,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Role_Actions",
                columns: table => new
                {
                    RoleActionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Actions", x => x.RoleActionID);
                    table.ForeignKey(
                        name: "FK_Role_Actions_Actions_ActionID",
                        column: x => x.ActionID,
                        principalTable: "Actions",
                        principalColumn: "ActionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Actions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeLevels",
                columns: table => new
                {
                    GradeLevelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeLevelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeLevels", x => x.GradeLevelID);
                    table.ForeignKey(
                        name: "FK_GradeLevels_Schools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "Schools",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Departments",
                columns: table => new
                {
                    UserDepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Departments", x => x.UserDepartmentID);
                    table.ForeignKey(
                        name: "FK_User_Departments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Departments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GradeLevelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_GradeLevels_GradeLevelID",
                        column: x => x.GradeLevelID,
                        principalTable: "GradeLevels",
                        principalColumn: "GradeLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "ActionID", "ActionCode", "ActionName", "Active" },
                values: new object[,]
                {
                    { new Guid("4801c236-5983-49ae-8b83-71b17cb29ac1"), "DELETE_USER", "Delete User", true },
                    { new Guid("72652a32-3a06-4cf6-9c98-43ea0ac1d92d"), "CREATE_USER", "Create User", true },
                    { new Guid("edf088e9-a8e2-41ff-947b-af8afba6e1c3"), "UPDATE_USER", "Update User", true }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Active", "DepartmentCode", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("109a7620-f8bd-4fd4-b846-654533e8181c"), true, "MKT", "Maketing" },
                    { new Guid("ae0f6039-feff-4bc8-885e-d66d13b49c18"), true, "IT", "IT" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionID", "Active", "PositionCode", "PositionName" },
                values: new object[,]
                {
                    { new Guid("0dc8d5b1-6a04-44c0-b6a2-70c4987d646e"), true, "DEV", "Developer" },
                    { new Guid("109a7620-f8bd-4fd4-b846-654533e8181c"), true, "MGR", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Active", "RoleCode", "RoleName" },
                values: new object[,]
                {
                    { new Guid("b1f2a3c4-5d6e-7f8a-9b0c-d1e2f3a4b5c6"), true, "USER", "User" },
                    { new Guid("c7d8e9f0-1a2b-3c4d-5e6f-7a8b9c0d1e2f"), true, "STUDENT", "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Active", "CreateOn", "EmailAddress", "Password", "RefreshToken", "UserName" },
                values: new object[] { new Guid("9e666a5d-8ba2-42e2-8dc4-fa560737c6a4"), true, new DateTime(2025, 7, 29, 15, 21, 48, 648, DateTimeKind.Local).AddTicks(4412), "admin@gmail.com", "$2a$12$fMOWcOJCvLJwyXiV7Bnd1uR8eWB3vaXyKFnj8p6QUOAl3agAcsHle", "", "Admin" });

            migrationBuilder.InsertData(
                table: "Department_Positions",
                columns: new[] { "DepartmentPositionID", "DepartmentID", "PositionID" },
                values: new object[] { new Guid("b2f3a4c5-6d7e-8f9a-b0c1-d2e3f4a5b6c7"), new Guid("ae0f6039-feff-4bc8-885e-d66d13b49c18"), new Guid("0dc8d5b1-6a04-44c0-b6a2-70c4987d646e") });

            migrationBuilder.InsertData(
                table: "Position_Roles",
                columns: new[] { "PositionRoleID", "PositionID", "RoleID", "RoleID1" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("0dc8d5b1-6a04-44c0-b6a2-70c4987d646e"), new Guid("b1f2a3c4-5d6e-7f8a-9b0c-d1e2f3a4b5c6"), null });

            migrationBuilder.InsertData(
                table: "Role_Actions",
                columns: new[] { "RoleActionID", "ActionID", "RoleID" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6"), new Guid("72652a32-3a06-4cf6-9c98-43ea0ac1d92d"), new Guid("b1f2a3c4-5d6e-7f8a-9b0c-d1e2f3a4b5c6") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-b0c1-d2e3f4a5b6c7"), new Guid("edf088e9-a8e2-41ff-947b-af8afba6e1c3"), new Guid("b1f2a3c4-5d6e-7f8a-9b0c-d1e2f3a4b5c6") },
                    { new Guid("a3b4c5d6-e7f8-9a0b-c1d2-e3f4a5b6c7d8"), new Guid("4801c236-5983-49ae-8b83-71b17cb29ac1"), new Guid("b1f2a3c4-5d6e-7f8a-9b0c-d1e2f3a4b5c6") }
                });

            migrationBuilder.InsertData(
                table: "User_Departments",
                columns: new[] { "UserDepartmentID", "DepartmentID", "UserID" },
                values: new object[] { new Guid("abfc04bd-a5ad-4b75-aff2-5565049ea948"), new Guid("ae0f6039-feff-4bc8-885e-d66d13b49c18"), new Guid("9e666a5d-8ba2-42e2-8dc4-fa560737c6a4") });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GradeLevelID",
                table: "Classes",
                column: "GradeLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Positions_DepartmentID",
                table: "Department_Positions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Positions_PositionID",
                table: "Department_Positions",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeLevels_SchoolID",
                table: "GradeLevels",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_Roles_PositionID",
                table: "Position_Roles",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_Roles_RoleID",
                table: "Position_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_Roles_RoleID1",
                table: "Position_Roles",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Actions_ActionID",
                table: "Role_Actions",
                column: "ActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Actions_RoleID",
                table: "Role_Actions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Departments_DepartmentID",
                table: "User_Departments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Departments_UserID",
                table: "User_Departments",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Department_Positions");

            migrationBuilder.DropTable(
                name: "Position_Roles");

            migrationBuilder.DropTable(
                name: "Role_Actions");

            migrationBuilder.DropTable(
                name: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "User_Departments");

            migrationBuilder.DropTable(
                name: "GradeLevels");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
