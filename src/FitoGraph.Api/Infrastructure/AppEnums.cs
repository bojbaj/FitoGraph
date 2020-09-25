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
        public enum UserClaimEnum
        {
            user_id,
            email_verified            
        }

        public enum FireBaseRequestEnum
        {
            VERIFY_EMAIL
        }
        public enum CustomerStateEnum
        {
            PROFILE_NOT_COMPLETED = 0,
            READY = 100
        }
    }
}