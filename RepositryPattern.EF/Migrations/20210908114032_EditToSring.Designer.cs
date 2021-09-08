﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositryPattern.EF;

namespace RepositryPattern.EF.Migrations
{
    [DbContext(typeof(RepoDbContext))]
    [Migration("20210908114032_EditToSring")]
    partial class EditToSring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employeeclient", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Employeeclient");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Calls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CallTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsComing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastEdit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("calls");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CallsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CallsId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CallsId")
                        .HasColumnType("int");

                    b.Property<string>("ClientSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerRate")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnterBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastEdit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastEditIn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Residence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TelOne")
                        .HasColumnType("int");

                    b.Property<int?>("TelTwo")
                        .HasColumnType("int");

                    b.Property<int?>("whatsapp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CallsId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Employeeclient", b =>
                {
                    b.HasOne("RepositryPattern.Core.Models.client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositryPattern.Core.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Book", b =>
                {
                    b.HasOne("RepositryPattern.Core.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Employee", b =>
                {
                    b.HasOne("RepositryPattern.Core.Models.Calls", null)
                        .WithMany("employees")
                        .HasForeignKey("CallsId");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.client", b =>
                {
                    b.HasOne("RepositryPattern.Core.Models.Calls", null)
                        .WithMany("clients")
                        .HasForeignKey("CallsId");
                });

            modelBuilder.Entity("RepositryPattern.Core.Models.Calls", b =>
                {
                    b.Navigation("clients");

                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
