﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210714192542_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categori");
                });

            modelBuilder.Entity("backend.Model.Drejtimet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drejtimi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drejtime");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Drejtimi = "CSE"
                        });
                });

            modelBuilder.Entity("backend.Model.Emails", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.Property<int?>("recivedById")
                        .HasColumnType("int");

                    b.Property<int?>("sentById")
                        .HasColumnType("int");

                    b.HasKey("EmailId");

                    b.HasIndex("recivedById");

                    b.HasIndex("sentById");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("backend.Model.Like_Thread", b =>
                {
                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ThreadId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Like_Threads");
                });

            modelBuilder.Entity("backend.Model.Niveli", b =>
                {
                    b.Property<int>("Niveli_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Niveli_Id");

                    b.ToTable("Nivelis");

                    b.HasData(
                        new
                        {
                            Niveli_Id = 1,
                            Name = "Barchelor"
                        });
                });

            modelBuilder.Entity("backend.Model.Posts", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("backend.Model.Qytetet", b =>
                {
                    b.Property<int>("QytetiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QytetiName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QytetiId");

                    b.ToTable("Qytetet");

                    b.HasData(
                        new
                        {
                            QytetiId = 1,
                            QytetiName = "Ferizaj"
                        });
                });

            modelBuilder.Entity("backend.Model.Replays", b =>
                {
                    b.Property<int>("ReplayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReplayId");

                    b.HasIndex("EmailId");

                    b.HasIndex("UserId");

                    b.ToTable("Replays");
                });

            modelBuilder.Entity("backend.Model.ReportedPosts", b =>
                {
                    b.Property<int>("ReportedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("ReportedId");

                    b.HasIndex("PostId");

                    b.HasIndex("userId");

                    b.ToTable("ReportedPost");
                });

            modelBuilder.Entity("backend.Model.ReportedThread", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("ReportedThreads");
                });

            modelBuilder.Entity("backend.Model.Reputations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reputation")
                        .HasColumnType("int");

                    b.Property<int?>("ToUserId")
                        .HasColumnType("int");

                    b.Property<int?>("fromUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToUserId");

                    b.HasIndex("fromUserId");

                    b.ToTable("Reputations");
                });

            modelBuilder.Entity("backend.Model.Sead.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChatBox");
                });

            modelBuilder.Entity("backend.Model.Sead.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Default")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "#ff0000",
                            Default = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Color = "#36dd08",
                            Default = true,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 3,
                            Color = "#2283d8",
                            Default = false,
                            Name = "Profesor"
                        });
                });

            modelBuilder.Entity("backend.Model.Sead.RoleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("backend.Model.Sead.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfJoining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrejtimiId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gjenerata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("NiveliId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QytetetQytetiId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrejtimiId");

                    b.HasIndex("NiveliId");

                    b.HasIndex("QytetetQytetiId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.Model.SubCategory", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategori");
                });

            modelBuilder.Entity("backend.Model.Thread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrejtimiId")
                        .HasColumnType("int");

                    b.Property<int?>("NiveliId")
                        .HasColumnType("int");

                    b.Property<int>("Text")
                        .HasColumnType("int");

                    b.Property<string>("Titulli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Viti")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThreadId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("DrejtimiId");

                    b.HasIndex("NiveliId");

                    b.HasIndex("UserId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("backend.Model.ThreadCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ThreadCategori");
                });

            modelBuilder.Entity("backend.Model.Warnings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ByAdminId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ByAdminId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("backend.Model.Emails", b =>
                {
                    b.HasOne("backend.Model.Sead.User", "recivedBy")
                        .WithMany("recivedEmail")
                        .HasForeignKey("recivedById");

                    b.HasOne("backend.Model.Sead.User", "sentBy")
                        .WithMany("sentEmail")
                        .HasForeignKey("sentById");

                    b.Navigation("recivedBy");

                    b.Navigation("sentBy");
                });

            modelBuilder.Entity("backend.Model.Like_Thread", b =>
                {
                    b.HasOne("backend.Model.Thread", "Thread")
                        .WithMany("Likes")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("LikeThread")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.Posts", b =>
                {
                    b.HasOne("backend.Model.Thread", "Thread")
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("Thread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.Replays", b =>
                {
                    b.HasOne("backend.Model.Emails", "Email")
                        .WithMany("Replays")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("Replays")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.ReportedPosts", b =>
                {
                    b.HasOne("backend.Model.Posts", "Post")
                        .WithMany("Reports")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "user")
                        .WithMany("ReportedPosts")
                        .HasForeignKey("userId");

                    b.Navigation("Post");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend.Model.ReportedThread", b =>
                {
                    b.HasOne("backend.Model.Thread", "Thread")
                        .WithMany("Reports")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("ReportedThreadS")
                        .HasForeignKey("UserId");

                    b.Navigation("Thread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.Reputations", b =>
                {
                    b.HasOne("backend.Model.Sead.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");

                    b.HasOne("backend.Model.Sead.User", "fromUser")
                        .WithMany()
                        .HasForeignKey("fromUserId");

                    b.Navigation("fromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("backend.Model.Sead.Message", b =>
                {
                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("Mesages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.Sead.RoleUser", b =>
                {
                    b.HasOne("backend.Model.Sead.Role", "Role")
                        .WithMany("roleUser")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("Role")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.Sead.User", b =>
                {
                    b.HasOne("backend.Model.Drejtimet", "Drejtimi")
                        .WithMany("user")
                        .HasForeignKey("DrejtimiId");

                    b.HasOne("backend.Model.Niveli", "Niveli")
                        .WithMany("users")
                        .HasForeignKey("NiveliId");

                    b.HasOne("backend.Model.Qytetet", null)
                        .WithMany("Users")
                        .HasForeignKey("QytetetQytetiId");

                    b.Navigation("Drejtimi");

                    b.Navigation("Niveli");
                });

            modelBuilder.Entity("backend.Model.SubCategory", b =>
                {
                    b.HasOne("backend.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("backend.Model.Thread", b =>
                {
                    b.HasOne("backend.Model.ThreadCategory", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("backend.Model.Drejtimet", "Drejtimi")
                        .WithMany("threads")
                        .HasForeignKey("DrejtimiId");

                    b.HasOne("backend.Model.Niveli", "Niveli")
                        .WithMany("threads")
                        .HasForeignKey("NiveliId");

                    b.HasOne("backend.Model.Sead.User", "User")
                        .WithMany("Threads")
                        .HasForeignKey("UserId");

                    b.Navigation("Categoria");

                    b.Navigation("Drejtimi");

                    b.Navigation("Niveli");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Model.ThreadCategory", b =>
                {
                    b.HasOne("backend.Model.Category", "Category")
                        .WithMany("subCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("backend.Model.Warnings", b =>
                {
                    b.HasOne("backend.Model.Sead.User", "ByAdmin")
                        .WithMany("ByAdminWarning")
                        .HasForeignKey("ByAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Model.Sead.User", "ToUser")
                        .WithMany("ToUserWarning")
                        .HasForeignKey("ToUserId");

                    b.Navigation("ByAdmin");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("backend.Model.Category", b =>
                {
                    b.Navigation("subCategory");
                });

            modelBuilder.Entity("backend.Model.Drejtimet", b =>
                {
                    b.Navigation("threads");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend.Model.Emails", b =>
                {
                    b.Navigation("Replays");
                });

            modelBuilder.Entity("backend.Model.Niveli", b =>
                {
                    b.Navigation("threads");

                    b.Navigation("users");
                });

            modelBuilder.Entity("backend.Model.Posts", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("backend.Model.Qytetet", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Model.Sead.Role", b =>
                {
                    b.Navigation("roleUser");
                });

            modelBuilder.Entity("backend.Model.Sead.User", b =>
                {
                    b.Navigation("ByAdminWarning");

                    b.Navigation("LikeThread");

                    b.Navigation("Mesages");

                    b.Navigation("Posts");

                    b.Navigation("recivedEmail");

                    b.Navigation("Replays");

                    b.Navigation("ReportedPosts");

                    b.Navigation("ReportedThreadS");

                    b.Navigation("Role");

                    b.Navigation("sentEmail");

                    b.Navigation("Threads");

                    b.Navigation("ToUserWarning");
                });

            modelBuilder.Entity("backend.Model.Thread", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
