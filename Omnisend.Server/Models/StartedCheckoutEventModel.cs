using System.Text.Json.Serialization;

namespace Omnisend.Server.Models
{
    public class StartedCheckoutEventModel
    {
        [JsonPropertyName("origin")]
        public string Origin { get; set; } = "api";

        [JsonPropertyName("eventID")]
        public string EventId { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("eventVersion")]
        public string EventVersion { get; set; } = string.Empty;

        [JsonPropertyName("eventName")]
        public string EventName { get; set; } = string.Empty;

        [JsonPropertyName("eventTime")]
        public DateTime EventTime { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("properties")]
        public CheckoutProperties Properties { get; set; } = new();

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; } = new();
    }

    public class CheckoutProperties
    {
        [JsonPropertyName("abandonedCheckoutURL")]
        public string AbandonedCheckoutURL { get; set; } = string.Empty;

        [JsonPropertyName("cartID")]
        public string CartId { get; set; } = string.Empty;

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "USD";

        [JsonPropertyName("lineItems")]
        public List<LineItem> LineItems { get; set; } = new();

        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }

    public class LineItem
    {
        [JsonPropertyName("productCategories")]
        public List<ProductCategory> ProductCategories { get; set; } = new();

        [JsonPropertyName("productDescription")]
        public string ProductDescription { get; set; } = string.Empty;

        [JsonPropertyName("productDiscount")]
        public decimal? ProductDiscount { get; set; }

        [JsonPropertyName("productID")]
        public string ProductID { get; set; } = string.Empty;

        [JsonPropertyName("productImageURL")]
        public string ProductImageURL { get; set; } = string.Empty;

        [JsonPropertyName("productPrice")]
        public decimal ProductPrice { get; set; }

        [JsonPropertyName("productQuantity")]
        public int ProductQuantity { get; set; }

        [JsonPropertyName("productSKU")]
        public int ProductSKU { get; set; }

        [JsonPropertyName("productStrikeThroughPrice")]
        public decimal? ProductStrikeThroughPrice { get; set; }

        [JsonPropertyName("productTitle")]
        public string ProductTitle { get; set; } = string.Empty;

        [JsonPropertyName("productURL")]
        public string ProductURL { get; set; } = string.Empty;

        [JsonPropertyName("productVariantID")]
        public string ProductVariantID { get; set; } = string.Empty;

        [JsonPropertyName("productVariantImageURL")]
        public string ProductVariantImageURL { get; set; } = string.Empty;
    }

    public class ProductCategory
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }

    public class Contact
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("birthdate")]
        public string? Birthdate { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("customProperties")]
        public CustomProperties CustomProperties { get; set; } = new();

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new();

        [JsonPropertyName("optIns")]
        public List<OptIn> OptIns { get; set; } = new();

        [JsonPropertyName("optOuts")]
        public List<OptOut> OptOuts { get; set; } = new();

        [JsonPropertyName("consents")]
        public List<Consent> Consents { get; set; } = new();
    }

    public class CustomProperties
    {
        [JsonPropertyName("favoriteColors")]
        public List<string> FavoriteColors { get; set; } = new();

        [JsonPropertyName("vipStatus")]
        public bool? VipStatus { get; set; }

        [JsonPropertyName("vipStatusDate")]
        public DateTime? VipStatusDate { get; set; }

        [JsonPropertyName("vipPoints")]
        public decimal? VipPoints { get; set; }

        [JsonPropertyName("friendlyTitle")]
        public string? FriendlyTitle { get; set; }
    }

    public class OptIn
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;
    }

    public class OptOut
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }
    }

    public class Consent
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        [JsonPropertyName("userAgent")]
        public string UserAgent { get; set; } = string.Empty;
    }
}
