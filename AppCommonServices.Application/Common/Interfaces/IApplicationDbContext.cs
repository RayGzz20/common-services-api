using Microsoft.EntityFrameworkCore;

namespace AppCommonServices.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Faq.Entities.Faq> Faqs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
