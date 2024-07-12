using AppCommonServices.Application.Faq.Common;

namespace AppCommonServices.Application.Faq.Queries
{
    public record GetByIdFaqsQuery(Guid Id) : IRequest<ErrorOr<FaqDetailResponse>>;
}
