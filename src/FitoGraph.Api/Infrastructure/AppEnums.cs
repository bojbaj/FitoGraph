namespace FitoGraph.Api.Infrastructure
{
    public class AppEnums
    {
        public enum RoleEnum
        {
            Customer,
            Supplier,
            Admin
        }
        public enum ClaimEnum
        {
            user_id,
            Token
        }

        public enum FireBaseRequestEnum
        {
            VERIFY_EMAIL
        }
    }
}