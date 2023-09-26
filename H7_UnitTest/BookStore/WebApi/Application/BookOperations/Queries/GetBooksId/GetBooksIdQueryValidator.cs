using FluentValidation;
using WebApi.Application.BookOperations.Queries.GetBooksId;

namespace WebApi.Application.BookOperations.UpdateBooks
{
    public class GetBooksIdQueryValidator : AbstractValidator<GetBooksIdQuery>
    {
        public GetBooksIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}