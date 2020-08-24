﻿// <auto-generated />
using System;
using FitoGraph.Api.Domain.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitoGraph.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TActivityLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Carb")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PALForFeMale")
                        .HasColumnType("float");

                    b.Property<double>("PALForMale")
                        .HasColumnType("float");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TActivityLevel");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TAllergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TAllergy");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TBodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBodyType");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TDeficiency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TDeficiency");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TDiet");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TFoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TFoodType");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TGoal");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TNutritionCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TNutritionCondition");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TSport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TSport");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FireBaseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TActivityLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("TBodyTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("TGoalId")
                        .HasColumnType("int");

                    b.Property<int?>("TWeeklyGoalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TActivityLevelId");

                    b.HasIndex("TBodyTypeId");

                    b.HasIndex("TGoalId");

                    b.HasIndex("TWeeklyGoalId");

                    b.ToTable("TUser");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserAllergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TAllergyId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TAllergyId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserAllergy");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserDeficiency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TDeficiencyId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TDeficiencyId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserDeficiency");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TDietId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TDietId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserDiet");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserFoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TFoodTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TFoodTypeId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserFoodType");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserNutritionCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TNutritionConditionId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TNutritionConditionId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserNutritionCondition");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserSport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("TSportId")
                        .HasColumnType("int");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TSportId");

                    b.HasIndex("TUserId");

                    b.ToTable("TUserSport");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TWeeklyGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TGoalId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TGoalId");

                    b.ToTable("TWeeklyGoal");
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUser", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TActivityLevel", null)
                        .WithMany("TUsers")
                        .HasForeignKey("TActivityLevelId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FitoGraph.Api.Domain.Entities.TBodyType", "TBodyType")
                        .WithMany("TUsers")
                        .HasForeignKey("TBodyTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FitoGraph.Api.Domain.Entities.TGoal", null)
                        .WithMany("TUsers")
                        .HasForeignKey("TGoalId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FitoGraph.Api.Domain.Entities.TWeeklyGoal", null)
                        .WithMany("TUsers")
                        .HasForeignKey("TWeeklyGoalId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserAllergy", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TAllergy", "TAllergy")
                        .WithMany("TUserAllergies")
                        .HasForeignKey("TAllergyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserAllergies")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserDeficiency", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TDeficiency", "TDeficiency")
                        .WithMany("TUserDeficiencies")
                        .HasForeignKey("TDeficiencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserDeficiencies")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserDiet", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TDiet", "TDiet")
                        .WithMany("TUserDiets")
                        .HasForeignKey("TDietId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserDiets")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserFoodType", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TFoodType", "TFoodType")
                        .WithMany("TUserFoodTypes")
                        .HasForeignKey("TFoodTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserFoodTypes")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserNutritionCondition", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TNutritionCondition", "TNutritionCondition")
                        .WithMany("TUserNutritionConditions")
                        .HasForeignKey("TNutritionConditionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserNutritionConditions")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TUserSport", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TSport", "TSport")
                        .WithMany("TUserSports")
                        .HasForeignKey("TSportId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitoGraph.Api.Domain.Entities.TUser", "TUser")
                        .WithMany("TUserSports")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoGraph.Api.Domain.Entities.TWeeklyGoal", b =>
                {
                    b.HasOne("FitoGraph.Api.Domain.Entities.TGoal", "TGoal")
                        .WithMany("TWeeklyGoals")
                        .HasForeignKey("TGoalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
