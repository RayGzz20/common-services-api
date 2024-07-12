namespace AppCommonServices.Domain.Feedback
{
    public interface IFeedbackRepository
    {
        void AddAsync(Entities.Feedback feedback);
    }
}
