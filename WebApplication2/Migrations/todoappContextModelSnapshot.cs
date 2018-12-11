﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(TodoappContext))]
    partial class todoappContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Models.Lists", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("lists");
                });

            modelBuilder.Entity("WebApplication2.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<string>("Desc")
                        .HasColumnName("desc")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Listid")
                        .HasColumnName("listid");

                    b.HasKey("Id");

                    b.HasIndex("Listid");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("WebApplication2.Models.Tasks", b =>
                {
                    b.HasOne("WebApplication2.Models.Lists", "List")
                        .WithMany("Tasks")
                        .HasForeignKey("Listid")
                        .HasConstraintName("FK_tasks_lists");
                });
#pragma warning restore 612, 618
        }
    }
}