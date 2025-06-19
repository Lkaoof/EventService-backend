using EventPlatform.Payments.Models;

namespace EventPlatform.Payments
{
    /// <summary>
    ///  Класс-заглушка для платежей
    /// </summary>
    public class MockPaymentsProvider
    {
        public async Task CreatePayment(CreatePaymentDto payment)
        {
            // TODO: создание платежа
        }

        public async Task ValidateWebhook(WebhookDto webhook)
        {
            // TODO: обработка вебхука от платежного сервиса
        }
    }


}
