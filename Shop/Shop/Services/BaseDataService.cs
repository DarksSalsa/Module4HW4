using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class BaseDataService<T> : IBaseDataService
        where T : DbContext
    {
        private readonly IDbContextWrapper<T> _dbContextWrapper;
        private readonly ILogger<IBaseDataService> _logger;

        protected BaseDataService(
            IDbContextWrapper<T> dbContextWrapper,
            ILogger<IBaseDataService> logger)
        {
            _dbContextWrapper = dbContextWrapper;
            _logger = logger;
        }

        protected Task ExecuteSafeAsync(Func<Task> function, CancellationToken token = default) => ExecuteSafeAsync(token => function(), token);
        protected Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> function, CancellationToken token = default) => ExecuteSafeAsync(token => function(), token);

        private async Task ExecuteSafeAsync(Func<CancellationToken, Task> function, CancellationToken token = default)
        {
            await using var transaction = await _dbContextWrapper.BeginTransactonAsync(token);

            try
            {
                await function(token);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Transaction failed because of {ex.Message}");
                await transaction.RollbackAsync(token);
                throw;
            }
        }

        private async Task<TResult> ExecuteSafeAsync<TResult>(Func<CancellationToken, Task<TResult>> function, CancellationToken token)
        {
            await using var transaction = await _dbContextWrapper.BeginTransactonAsync(token);

            try
            {
                var result = await function(token);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Transaction failed because of {ex.Message}");
                await transaction.RollbackAsync(token);
                throw;
            }
        }
    }
}
