using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksId;
using WebApi.Application.BookOperations.UpdateBooks;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-114)]
        [Theory]
        public void WhenInvalidBookidIsGiven_Validator_ShouldBeReturnErrors(int bookid)
        {
            GetBooksIdQuery query = new GetBooksIdQuery(null,null);
            query.BookId=bookid;

            GetBooksIdQueryValidator validator = new GetBooksIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(25)]
        [Theory]
        public void WhenInvalidBookidIsGiven_Validator_ShouldNotBeReturnErrors(int bookid)
        {
            GetBooksIdQuery query = new GetBooksIdQuery(null,null);
            query.BookId=bookid;

            GetBooksIdQueryValidator validator = new GetBooksIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}