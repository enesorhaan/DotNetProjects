using FluentValidation;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0");
            RuleFor(command => command.PageCount).GreaterThan(0).WithMessage("PageCount must be greater than 0");
            RuleFor(command => command.PublishDate.Date).NotEmpty().WithMessage("PublishDate required")
                    .LessThan(DateTime.Now.Date).WithMessage("PublishDate cannot be earlier than the current date. ");
            RuleFor(command => command.Title).NotEmpty().NotEmpty().WithMessage("Title required").MinimumLength(4).WithMessage("Title must contain more than 4 characters.");
        }
    }
}