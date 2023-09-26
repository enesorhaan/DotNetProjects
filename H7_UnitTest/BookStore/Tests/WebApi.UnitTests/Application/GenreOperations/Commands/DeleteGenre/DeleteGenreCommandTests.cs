using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }


        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            command.GenreId=0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Invalid GenreId, Book Genre not found..");
        }

        [Fact]
        public void WhenGivenGenreIdinDB_Genre_ShouldBeRemove()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            command.GenreId=1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _dbContext.Genres.SingleOrDefault(genre=>genre.Id == command.GenreId);
            genre.Should().Be(null);
        }
    }

}