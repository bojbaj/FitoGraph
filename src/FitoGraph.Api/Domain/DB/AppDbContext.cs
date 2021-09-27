using System.Collections.Generic;
using System.Data;
using System.Linq;
using FitoGraph.Api.Domain.Entities;
using Microsoft.Data.SqlClient;
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
        public DbSet<TFoodNutritionCondition> TFoodNutritionCondition { get; set; }
        public DbSet<TFoodAllergy> TFoodAllergy { get; set; }
        public DbSet<TFoodDiet> TFoodDiet { get; set; }
        public DbSet<TFoodDeficiency> TFoodDeficiency { get; set; }
        public DbSet<TOrder> TOrder { get; set; }
        public DbSet<TOrderDetail> TOrderDetail { get; set; }
        public DbSet<TArticle> TArticle { get; set; }
        public DbSet<TArticleSport> TArticleSport { get; set; }

        public List<SP.SPFindBestFoodsForCustomer> SPFindBestFoodsForCustomer(int UserId, int requiredCalorie)
        {
            List<SP.SPFindBestFoodsForCustomer> result = new List<SP.SPFindBestFoodsForCustomer>();
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                string sqlQuery = $"EXEC {nameof(SPFindBestFoodsForCustomer)} @UserID, @RequiredCalorie";
                command.CommandText = sqlQuery;
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter("@UserID", UserId));
                command.Parameters.Add(new SqlParameter("@RequiredCalorie", requiredCalorie));
                Database.OpenConnection();
                using (var readerResult = command.ExecuteReader())
                {
                    while (readerResult.Read())
                    {
                        result.Add(new SP.SPFindBestFoodsForCustomer()
                        {
                            Id = System.Convert.ToInt32(readerResult["Id"]),
                            Title = readerResult["Title"].ToString(),
                            Image = readerResult["Image"].ToString(),
                            Tags = readerResult["Tags"].ToString(),
                            Restaurant = readerResult["Restaurant"].ToString(),
                            MatchRate = System.Convert.ToInt32(readerResult["MatchRate"]),
                            Price = System.Convert.ToDecimal(readerResult["Price"]),
                            Carb = System.Convert.ToDecimal(readerResult["Carb"]),
                            Protein = System.Convert.ToDecimal(readerResult["Protein"]),
                            CalorieDiff = System.Convert.ToDecimal(readerResult["CalorieDiff"]),
                            Calorie = System.Convert.ToDecimal(readerResult["Calorie"]),
                            AllergyMatched = System.Convert.ToInt32(readerResult["AllergyMatched"]) == 1,
                            DietMatched = System.Convert.ToInt32(readerResult["DietMatched"]) == 1,
                            DeficiencyMatched = System.Convert.ToInt32(readerResult["DeficiencyMatched"]) == 1,
                            NutritionConditionMatched = System.Convert.ToInt32(readerResult["NutritionConditionMatched"]) == 1,
                            TotalGFactor = System.Convert.ToDecimal(readerResult["TotalGFactor"])
                        });
                    }
                }
            }
            return result;
        }
    }
}