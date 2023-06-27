namespace MVC_TDPC_Net6.DB.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? Salary { get; set; }
    }
}
