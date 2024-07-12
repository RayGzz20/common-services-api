namespace AppCommonServices.Application.Faq.Common
{
    public record QuestionResponse(
        Guid Id,
        string Description,
        int Position,
        List<AnswerResponse> Answers
    );
}
