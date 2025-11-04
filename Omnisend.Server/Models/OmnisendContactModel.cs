namespace Omnisend.Server.Models
{
    public class OmnisendContactModel
    {
        public string? Email { get; set; }
        public string? ContactID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Birthdate { get; set; }
        public string? Status { get; set; }
        public List<string>? Tags { get; set; }
        public List<string>? Segments { get; set; }
        public List<OmnisendStatus>? Statuses { get; set; }
        public List<OmnisendOptIn>? OptIns { get; set; }
        public List<OmnisendConsent>? Consents { get; set; }
        public object? CustomProperties { get; set; }
        public List<OmnisendIdentifier>? Identifiers { get; set; }
    }

    public class OmnisendStatus
    {
        public string? Channel { get; set; }
        public string? Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }

    public class OmnisendOptIn
    {
        public string? Channel { get; set; }
        public DateTime? Date { get; set; }
    }

    public class OmnisendConsent
    {
        public string? Channel { get; set; }
        public string? Source { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OmnisendIdentifier
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public OmnisendChannels? Channels { get; set; }
    }

    public class OmnisendChannels
    {
        public OmnisendEmailChannel? Email { get; set; }
    }

    public class OmnisendEmailChannel
    {
        public string? Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
