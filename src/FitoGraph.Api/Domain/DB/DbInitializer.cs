namespace FitoGraph.Api.Domain.DB
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //Add Some Entities
            context.SaveChanges();
        }
    }
}