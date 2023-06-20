﻿// <auto-generated />
using System;
using BookLibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibraryAPI.Migrations.YersinDb
{
    [DbContext(typeof(YersinDbContext))]
    [Migration("20230620113531_YersinContext")]
    partial class YersinContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookLibraryAPI.Models.Footer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Targer")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.MenuGroup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("MenuGroups");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CustomerMassage")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PaymenStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quanlity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("HotFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("BookLibraryAPI.Models.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Images")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentID");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Decription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("HotFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MoreImages")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Promotion")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.Property<int?>("Warranty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.ProductsCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Images")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentID");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("ProductsCategories");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Slide", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("URL");

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.SupportOnline", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Department")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Facebook")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Skype")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Yahoo")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("SupportOnlines");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.SystemConfig", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ValueInt")
                        .HasColumnType("int");

                    b.Property<string>("ValueString")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.VisitorStatistic", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("IP Address");

                    b.Property<DateTime>("VisitedDate")
                        .HasColumnType("datetime");

                    b.ToTable("VisitorStatistics");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    b.Property<string>("TagId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TagID");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags", (string)null);
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<string>("TagId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TagID");

                    b.HasKey("ProductId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags", (string)null);
                });

            modelBuilder.Entity("BookLibraryAPI.Models.MenuGroup", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.Menu", "IdNavigation")
                        .WithOne("MenuGroup")
                        .HasForeignKey("BookLibraryAPI.Models.MenuGroup", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_MenuGroups_Menus");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDetails_Orders");

                    b.HasOne("BookLibraryAPI.Models.ProductsCategory", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDetails_ProductsCategories");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Post", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.PostCategory", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Post_PostCategories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Product", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.ProductsCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_ProductsCategories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_PostTags_Post");

                    b.HasOne("BookLibraryAPI.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_PostTags_Tags");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("BookLibraryAPI.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductTags_Products");

                    b.HasOne("BookLibraryAPI.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductTags_Tags");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Menu", b =>
                {
                    b.Navigation("MenuGroup");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.PostCategory", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BookLibraryAPI.Models.ProductsCategory", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
