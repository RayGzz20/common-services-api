using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq;
using AppCommonServices.Infrastructure.Common.Persistence;
using EntitiesFaq = AppCommonServices.Domain.Faq.Entities.Faq;

namespace AppCommonServices.Infrastructure.Faq
{
    public class FaqRepository : IFaqRepository
    {
        private readonly ApplicationDbContext _context;

        public FaqRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<EntitiesFaq>> GetAll() => await _context.Faqs
            .OrderBy(f => f.Position)
            .ToListAsync();

        public async Task<List<EntitiesFaq>> GetAllActive() => await _context.Faqs
            .Where(f => f.IsActive)
            .OrderBy(f => f.Position)
            .ToListAsync();

        public async Task<EntitiesFaq?> GetByIdAsync(Id id) =>
            await _context.Faqs
                .Where(ss => ss.Id == id && ss.IsActive)
                .Include(q => q.Questions.Where(q => q.IsActive).OrderBy(q => q.Position))
                .ThenInclude(q => q.Answers.Where(q => q.IsActive).OrderBy(q => q.Position))
                .SingleOrDefaultAsync();
    }
}
