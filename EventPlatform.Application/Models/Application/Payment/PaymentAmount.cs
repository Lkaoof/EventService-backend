using System.Text.Json.Serialization;

namespace EventPlatform.Application.Models.Application.Payment
{
    public class PaymentAmount
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
