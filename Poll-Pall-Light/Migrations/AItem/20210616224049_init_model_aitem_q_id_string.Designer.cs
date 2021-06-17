﻿// <auto-generated />
using AItemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Poll_Pall_Light.Migrations.AItem
{
    [DbContext(typeof(AItemContext))]
    [Migration("20210616224049_init_model_aitem_q_id_string")]
    partial class init_model_aitem_q_id_string
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AItemAPI.Models.AItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QItemID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("AItems");
                });
#pragma warning restore 612, 618
        }
    }
}
