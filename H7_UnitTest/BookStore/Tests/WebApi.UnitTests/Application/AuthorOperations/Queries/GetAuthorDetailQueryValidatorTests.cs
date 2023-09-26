using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(0)]
        [InlineData(-114)]
        [Theory]
        public void WhenInvalidAuthoridIsGiven_Validator_ShouldBeReturnErrors(int authorid)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
            query.AuthorId=authorid;

            GetAuthorDetailQueryValidator validations = new GetAuthorDetailQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [InlineData(1)]
        [Theory]
        public void WhenInvalidAuthoridIsGiven_Validator_ShouldNotBeReturnErrors(int authorid)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
            query.AuthorId=authorid;

            GetAuthorDetailQueryValidator validations = new GetAuthorDetailQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}