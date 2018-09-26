﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RawQuery;

namespace RawQuery.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20180926134813_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RawQuery.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Posts");

                    b.HasData(
                        new { ID = 1, Category = "C#", IsPrivate = false, Title = "C# 8 ロードマップ" },
                        new { ID = 2, Category = "JavaScript", IsPrivate = false, Title = "Array.some と Array.includes の使い分け" },
                        new { ID = 3, Category = "C#", IsPrivate = true, Title = "秘密のポートフォリオ" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
