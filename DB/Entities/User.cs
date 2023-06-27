namespace MVC_TDPC_Net6.DB.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public decimal? Stipendio { get; set; }
    }
}
