using EventPlatform.Application.Models.Application.Payment.Request;
using EventPlatform.Application.Models.Application.Payment.Response;

namespace EventPlatform.Application.Interfaces.Infrastructure
{
    public interface IPaymentsProvider
    {
        PaymentCreateResponse GenerateTestPaymentResponse(PaymentCreate payment);
        Task<PaymentCreateResponse> ProducePayment(PaymentCreate payment);
        Task ValidateWebhook(PaymentCompleteResponse response);
    }
}