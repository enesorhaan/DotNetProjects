using FluentValidation;
using WebApi.BookOperations.GetBooksId;

namespace WebApi.BookOperations.UpdateBooks
{
    public class GetBooksIdQueryValidator : AbstractValidator<GetBooksIdQuery>
    {
        public GetBooksIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}