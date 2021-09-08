using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositryPattern.EF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsComing = table.Column<byte>(type: "tinyint", nullable: true),
                    EnterBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEdit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<int>(type: "int", nullable: true),
                    TelOne = table.Column<int>(type: "int", nullable: true),
                    TelTwo = table.Column<int>(type: "int", nullable: true),
                    whatsapp = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEdit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastEditIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_calls_CallsId",
                        column: x => x.CallsId,
                        principalTable: "calls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CallsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_calls_CallsId",
                        column: x => x.CallsId,
                        principalTable: "calls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employeeclient",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeeclient", x => new { x.ClientsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_Employeeclient_clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employeeclient_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_CallsId",
                table: "clients",
                column: "CallsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeeclient_EmployeesId",
                table: "Employeeclient",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CallsId",
                table: "Employees",
                column: "CallsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeeclient");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "calls");
        }
    }
}
