using FluentValidation;
using WebApi.Application.BookOperations.Commands.CreateBook;

namespace WebApi.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty()
                    .LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().NotEmpty().MinimumLength(4);
        }
    }
}