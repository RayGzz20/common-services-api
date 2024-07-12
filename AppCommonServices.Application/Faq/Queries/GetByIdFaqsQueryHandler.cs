using AppCommonServices.Application.Faq.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq;
using AppCommonServices.Domain.Faq.Errors;

namespace AppCommonServices.Application.Faq.Queries
{
    public sealed class GetByIdFaqsQueryHandler : IRequestHandler<GetByIdFaqsQuery, ErrorOr<FaqDetailResponse>>
    {
        private readonly IFaqRepository _repository;

        public GetByIdFaqsQueryHandler(IFaqRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ErrorOr<FaqDetailResponse>> Handle(GetByIdFaqsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (await _repository.GetByIdAsync(new Id(query.Id)) is not Domain.Faq.Entities.Faq response)
                {
                    return FaqErrors.NotFound;
                }

                return new FaqDetailResponse(
                        response.Id.Value,
                        response.Name?.Value ?? string.Empty,
                        response.UrlImage?.Value ?? string.Empty,
                        response.Position!.Value,
                        response.Questions.Select(question => new QuestionResponse(
                            question.Id.Value,
                            question.Description?.Value ?? string.Empty,
                            question.Position!.Value,
                            question.Answers.Select(answer => new AnswerResponse(
                                answer.Id.Value,
                                answer.Description?.Value ?? string.Empty,
                                answer.Position!.Value
                            )).OrderBy(o => o.Position).ToList()

                        )).OrderBy(o => o.Position).ToList()
                    );
            }
            catch (Exception)
            {
                return FaqErrors.UnexpectedError;
            }
        }
    }
}
