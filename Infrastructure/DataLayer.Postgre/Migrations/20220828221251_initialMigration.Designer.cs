﻿// <auto-generated />
using System;
using DataLayer.Postgre.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Postgre.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220828221251_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Asset.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("created_user");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_user");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mac_address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("status_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_user");

                    b.HasKey("Id")
                        .HasName("pk_assets");

                    b.ToTable("assets", (string)null);
                });

            modelBuilder.Entity("Domain.User.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("created_user");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_user");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_user");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
