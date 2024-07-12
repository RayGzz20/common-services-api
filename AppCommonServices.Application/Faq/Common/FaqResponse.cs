

namespace AppCommonServices.Application.Faq.Common
{
    public record FaqResponse(
        Guid Id,
        string Name,
        string UrlImage,
        int Position);
}
