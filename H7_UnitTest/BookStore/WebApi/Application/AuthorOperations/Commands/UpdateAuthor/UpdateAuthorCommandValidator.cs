using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a => a.Model.FirstName).MinimumLength(2).NotEmpty();
		    RuleFor(a => a.Model.LastName).MinimumLength(2).NotEmpty();
		    RuleFor(a => a.Model.BirthDay.Date).LessThan(DateTime.Now.Date);
        }
    }
}