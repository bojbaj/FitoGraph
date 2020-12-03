using System.Linq;
using FitoGraph.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Domain.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<TNutritionGroup>()
                .HasIndex(p => p.Code).IsUnique().HasName("UQ_TNutritionGroup_Code");

            modelbuilder.Entity<TNutrition>()
                .HasIndex(p => p.Code).IsUnique().HasName("UQ_TNutrition_Code");
        }

        public DbSet<TBodyType> TBodyType { get; set; }
        public DbSet<TUser> TUser { get; set; }
        public DbSet<TActivityLevel> TActivityLevel { get; set; }
        public DbSet<TSport> TSport { get; set; }
        public DbSet<TUserSport> TUserSport { get; set; }
        public DbSet<TFoodType> TFoodType { get; set; }
        public DbSet<TUserFoodType> TUserFoodType { get; set; }
        public DbSet<TAllergy> TAllergy { get; set; }
        public DbSet<TUserAllergy> TUserAllergy { get; set; }
        public DbSet<TDiet> TDiet { get; set; }
        public DbSet<TUserDiet> TUserDiet { get; set; }
        public DbSet<TDeficiency> TDeficiency { get; set; }
        public DbSet<TUserDeficiency> TUserDeficiency { get; set; }
        public DbSet<TNutritionCondition> TNutritionCondition { get; set; }
        public DbSet<TUserNutritionCondition> TUserNutritionCondition { get; set; }
        public DbSet<TGoal> TGoal { get; set; }
        public DbSet<TWeeklyGoal> TWeeklyGoal { get; set; }
        public DbSet<TRegionCountry> TRegionCountry { get; set; }
        public DbSet<TRegionState> TRegionState { get; set; }
        public DbSet<TRegionCity> TRegionCity { get; set; }
        public DbSet<TReference> TReference { get; set; }
        public DbSet<TNutritionGroup> TNutritionGroup { get; set; }
        public DbSet<TNutrition> TNutrition { get; set; }
        public DbSet<TFood> TFood { get; set; }
        public DbSet<TFoodNutrition> TFoodNutrition { get; set; }
        public DbSet<TNutritionUnit> TNutritionUnit { get; set; }
        public DbSet<TReferenceInRange> TReferenceInRange { get; set; }

    }
}