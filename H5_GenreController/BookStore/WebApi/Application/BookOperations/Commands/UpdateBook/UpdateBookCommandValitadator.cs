using FluentValidation;
using WebApi.Application.BookOperations.Commands.UpdateBook;

namespace WebApi.Application.BookOperations.DeleteBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty()
                    .LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().NotEmpty().MinimumLength(4);
        }
    }
}