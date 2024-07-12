using AppCommonServices.Domain.Common.ValueObjects;

namespace AppCommonServices.Domain.Faq
{    public interface IFaqRepository
    {
        Task<List<Entities.Faq>> GetAll();
        Task<List<Entities.Faq>> GetAllActive();

        Task<Entities.Faq?> GetByIdAsync(Id id);
    }
}
