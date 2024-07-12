using AppCommonServices.Application.Common.Interfaces;

namespace AppCommonServices.Infrastructure.Services
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
