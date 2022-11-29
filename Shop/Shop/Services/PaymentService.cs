using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class PaymentService : BaseDataService<ApplicationDBContext>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            IPaymentRepository paymentRepository,
            ILogger<PaymentService> logger)
            : base(contextWrapper, baseLogger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public async Task<int> AddPaymentAsync(string paymentType, bool allowed)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _paymentRepository.AddPaymentAsync(paymentType, allowed);
                _logger.Log(LogLevel.Information, "Payment method was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.DeletePaymentAsync(id);
                return result;
            });
        }

        public async Task<PaymentModel?> GetPaymentAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.GetPaymentAsync(id);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Payment method was not found");
                    return null!;
                }

                return new PaymentModel()
                {
                    Id = result.Id,
                    PaymentType = result.PaymentType,
                    Allowed = result.Allowed
                };
            });
        }

        public async Task<bool> UpdatePaymentAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.UpdatePaymentAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
