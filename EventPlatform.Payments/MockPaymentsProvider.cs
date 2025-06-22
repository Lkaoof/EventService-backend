using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Payment;
using EventPlatform.Application.Models.Application.Payment.Request;
using EventPlatform.Application.Models.Application.Payment.Response;

namespace EventPlatform.Payments
{
    /// <summary>
    ///  Класс-заглушка для платежей
    /// </summary>
    public class MockPaymentsProvider : IPaymentsProvider
    {

        public async Task<PaymentCreateResponse> ProducePayment(PaymentCreate payment)
        {
            // имитируем отправку и ожидание ответа от сервиса
            await Task.Delay(1000);

            // создаем ответ, который должен был прийти от сервиса
            var orderId = Guid.NewGuid().ToString();
            var response = GenerateTestPaymentResponse(payment);

            return response;
        }

        public async Task ValidateWebhook(PaymentCompleteResponse response)
        {

        }

        public PaymentCreateResponse GenerateTestPaymentResponse(PaymentCreate payment)
        {
            var orderId = Guid.NewGuid().ToString();
            return new PaymentCreateResponse
            {
                Id = orderId,
                Amount = payment.Amount,
                Confirmation = new PaymentConfirmation
                {
                    Type = "redirect",
                    ReturnUrl = $"http://localhost:5071/api/payment-confirm?orderId={orderId}"
                },
                CreatedAt = DateTime.UtcNow,
                Description = payment.Description,
                Paid = false,
                Recipient = new PaymentRecipient
                {
                    AccountId = Guid.NewGuid().ToString(),
                    GatewayId = Guid.NewGuid().ToString(),
                },
                Status = PaymentStatus.Pending,
                Refundable = false,
                Test = true,
                Metadata = { }
            };
        }
    }


}
