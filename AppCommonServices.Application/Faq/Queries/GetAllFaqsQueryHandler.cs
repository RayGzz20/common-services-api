using AppCommonServices.Application.Faq.Common;
using AppCommonServices.Domain.Faq;
using AppCommonServices.Domain.Faq.Errors;

namespace AppCommonServices.Application.Faq.Queries
{
    public sealed class GetAllFaqsQueryHandler : IRequestHandler<GetAllFaqsQuery, ErrorOr<IReadOnlyList<FaqResponse>>>
    {
        private readonly IFaqRepository _faqRepository;

        public GetAllFaqsQueryHandler(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<FaqResponse>>> Handle(GetAllFaqsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                IReadOnlyList<Domain.Faq.Entities.Faq> faqs = await _faqRepository.GetAllActive();

                return faqs.Select(fitem => new FaqResponse(
                        fitem.Id.Value,
                        fitem.Name!.Value,
                        fitem.UrlImage!.Value,
                        fitem.Position!.Value
                    )).OrderBy(f => f.Position).ToList();
            }
            catch (Exception)
            {
                return FaqErrors.UnexpectedError;
            }            
        }
    }
}
