using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace WebApi.Application.AuthorOperations.Commands.DeleteBook
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}