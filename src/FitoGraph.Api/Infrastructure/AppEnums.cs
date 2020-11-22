namespace FitoGraph.Api.Infrastructure
{
    public class AppEnums
    {
        public enum RoleEnum
        {
            NULL = 0,
            Customer = 1,
            Supplier = 2,
            Admin = 3
        }
        public enum UserClaimEnum
        {
            user_id,
            email_verified
        }

        public enum FireBaseRequestEnum
        {
            VERIFY_EMAIL,
            refresh_token
        }
        public enum CustomerStateEnum
        {
            PROFILE_NOT_COMPLETED = 0,
            READY = 100
        }
        public enum BmiLabelEnum
        {
            NULL,
            UnderWeight,
            Normal,
            OverWeight,
            Obese
        }
        public enum WaistToHipsRatioEnum
        {
            NULL,
            EXCELENT,
            GOOD,
            AVERAGE,
            AT_RISK
        }
        public enum GenderEnum
        {
            NULL = 0,
            MALE = 1,
            FEMALE = 2
        }
        public enum GoalEnum
        {
            LOSE_WEIGHT = 1,
            GAIN_WEIGHT = 2,
            MAINTAIN_WEIGHT = 3
        }
        public enum ReferenceRecordTypeEnum
        {
            NUTRITION = 1,
            FOOD = 2,
            USER = 3,
            GFACTOR = 4
        }      
    }
}