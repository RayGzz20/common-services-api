
using AppCommonServices.Domain.Feedback;
using E = AppCommonServices.Domain.Feedback.Entities;
using AppCommonServices.Infrastructure.Common.Persistence;

namespace AppCommonServices.Infrastructure.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void AddAsync(E.Feedback feedback) 
        {
            await _context.AddAsync(feedback);
            
        }
    }
}
