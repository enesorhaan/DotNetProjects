using FluentValidation;
using WebApi.BookOperations.UpdateBooks;

namespace WebApi.BookOperations.DeleteBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0");
            RuleFor(command => command.Model.PageCount).GreaterThan(0).WithMessage("PageCount must be greater than 0");
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().WithMessage("PublishDate required")
                    .LessThan(DateTime.Now.Date).WithMessage("PublishDate cannot be earlier than the current date. ");
            RuleFor(command => command.Model.Title).NotEmpty().NotEmpty().WithMessage("Title required").MinimumLength(4).WithMessage("Title must contain more than 4 characters.");
        }
    }
}