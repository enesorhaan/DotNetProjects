using FluentValidation;
using H1_RestfulApi.Models;

namespace H1_RestfulApi.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("ID field cannot be left empty")
                .GreaterThan(0).WithMessage("ID field must be greater than '0'");

            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name field cannot be left empty");

            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Price field cannot be left empty")
                .GreaterThan(0).WithMessage("Price field must be greater than '0'");
        }
    }
}
