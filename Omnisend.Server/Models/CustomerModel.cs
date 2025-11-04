namespace Omnisend.Server.Models
{
    public class CustomerModel
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public bool SendWelcomeEmail { get; set; } = false;
        public DateTime? StatusDate { get; set; }
        public string? Status { get; set; }
        public List<OmnisendStatus>? Statuses { get; set; }
        public Dictionary<string, object>? CustomProperties { get; set; }
    }
}
