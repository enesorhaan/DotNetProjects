
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
            query.GenreId=0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Book Genre not found..");
        }

        [Fact]
        public void WhenGivenGenreIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
            query.GenreId = 1;

            var genre = _dbContext.Books.SingleOrDefault(genre=>genre.Id == query.GenreId);
            genre.Should().NotBeNull();
        }
    }
}