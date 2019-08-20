﻿// <auto-generated />
using System;
using Administrator.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Administrator.Database.Migrations
{
    [DbContext(typeof(DataModels))]
    partial class DataModelsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Administrator.Database.Cat_Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Edit_date")
                        .HasColumnName("edit_date");

                    b.Property<int?>("Edit_user")
                        .HasColumnName("edit_user");

                    b.Property<DateTime?>("Generate_date")
                        .HasColumnName("generate_date");

                    b.Property<int?>("Generate_user")
                        .HasColumnName("generate_user");

                    b.Property<int>("Id_main")
                        .HasColumnName("id_main");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("type_user")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("Remove_date")
                        .HasColumnName("remove_date");

                    b.Property<bool?>("Remove_status")
                        .HasColumnName("remove_status");

                    b.Property<int?>("Remove_user")
                        .HasColumnName("remove_user");

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("Cat_Users");
                });

            modelBuilder.Entity("Administrator.Database.Tbl_Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Create_group")
                        .HasColumnName("create_group");

                    b.Property<bool>("Create_permission")
                        .HasColumnName("create_permission");

                    b.Property<bool>("Create_user")
                        .HasColumnName("create_user");

                    b.Property<bool>("Delete_group")
                        .HasColumnName("delete_group");

                    b.Property<bool>("Delete_permission")
                        .HasColumnName("delete_permission");

                    b.Property<bool>("Delete_user")
                        .HasColumnName("delete_user");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Edit_date")
                        .HasColumnName("edit_date");

                    b.Property<int?>("Edit_user")
                        .HasColumnName("edit_user");

                    b.Property<DateTime?>("Generate_date")
                        .HasColumnName("generate_date");

                    b.Property<int?>("Generate_user")
                        .HasColumnName("generate_user");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnName("group")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Id_main")
                        .HasColumnName("id_main");

                    b.Property<bool>("Read_group")
                        .HasColumnName("read_group");

                    b.Property<bool>("Read_permission")
                        .HasColumnName("read_permission");

                    b.Property<bool>("Read_user")
                        .HasColumnName("read_user");

                    b.Property<DateTime?>("Remove_date")
                        .HasColumnName("remove_date");

                    b.Property<bool?>("Remove_status")
                        .HasColumnName("remove_status");

                    b.Property<int?>("Remove_user")
                        .HasColumnName("remove_user");

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.Property<bool>("Update_group")
                        .HasColumnName("update_group");

                    b.Property<bool>("Update_permission")
                        .HasColumnName("update_permission");

                    b.Property<bool>("Update_user")
                        .HasColumnName("update_user");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Administrator.Database.Tbl_Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("Attemp")
                        .HasColumnName("attemp");

                    b.Property<int?>("Cycle")
                        .HasColumnName("cycle");

                    b.Property<DateTime?>("Edit_date")
                        .HasColumnName("edit_date");

                    b.Property<int?>("Edit_user")
                        .HasColumnName("edit_user");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.Property<DateTime?>("Generate_date")
                        .HasColumnName("generate_date");

                    b.Property<int?>("Generate_user")
                        .HasColumnName("generate_user");

                    b.Property<int>("Id_group")
                        .HasColumnName("id_group");

                    b.Property<int>("Id_main")
                        .HasColumnName("id_main");

                    b.Property<string>("LnameM")
                        .HasColumnName("lastnamem")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LnameP")
                        .IsRequired()
                        .HasColumnName("lastnamep")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Photo")
                        .HasColumnName("photo")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("Remove_date")
                        .HasColumnName("remove_date");

                    b.Property<bool?>("Remove_status")
                        .HasColumnName("remove_status");

                    b.Property<int?>("Remove_user")
                        .HasColumnName("remove_user");

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Id_group");

                    b.HasIndex("Type");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Administrator.Database.Tbl_Users", b =>
                {
                    b.HasOne("Administrator.Database.Tbl_Groups", "Tbl_Groups")
                        .WithMany("Tbl_Users")
                        .HasForeignKey("Id_group")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Administrator.Database.Cat_Users", "Cat_Users")
                        .WithMany("Tbl_Users")
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
