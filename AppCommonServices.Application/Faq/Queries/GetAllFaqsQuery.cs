using AppCommonServices.Application.Faq.Common;

namespace AppCommonServices.Application.Faq.Queries
{
    public record GetAllFaqsQuery() : IRequest<ErrorOr<IReadOnlyList<FaqResponse>>>;
}