using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Xunit;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-114)]
        [Theory]
        public void WhenInvalidGenreidIsGiven_Validator_ShouldBeReturnErrors(int genreid)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId=genreid;
            
            GetGenreDetailQueryValidator validations = new GetGenreDetailQueryValidator();
            var result = validations.Validate(query);
            
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(2)]
        [Theory]
        public void WhenInvalidGenreidIsGiven_Validator_ShouldNotBeReturnErrors(int genreid)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId=genreid;
            
            GetGenreDetailQueryValidator validations = new GetGenreDetailQueryValidator();
            var result = validations.Validate(query);
            
            result.Errors.Count.Should().Be(0);
        }
    }
}