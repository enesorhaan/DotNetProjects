using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Model.FirstName).MinimumLength(2).NotEmpty();
		    RuleFor(a => a.Model.LastName).MinimumLength(2).NotEmpty();
		    RuleFor(a => a.Model.BirthDay.Date).LessThan(DateTime.Now.Date);
        }
    }
}