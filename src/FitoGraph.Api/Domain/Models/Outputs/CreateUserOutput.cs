namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class CreateUserOutput
    {
        public int Id { get; set; }
        public string FireBaseId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}