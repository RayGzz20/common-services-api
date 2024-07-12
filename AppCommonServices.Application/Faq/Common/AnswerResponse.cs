namespace AppCommonServices.Application.Faq.Common
{
    public record AnswerResponse(
        Guid Id,
        string Description,
        int Position
    );
}
