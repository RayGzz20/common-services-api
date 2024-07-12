namespace AppCommonServices.Application.Feedback.Commands
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(r => r.UserId)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Comments)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(850);
        }
    }
}
