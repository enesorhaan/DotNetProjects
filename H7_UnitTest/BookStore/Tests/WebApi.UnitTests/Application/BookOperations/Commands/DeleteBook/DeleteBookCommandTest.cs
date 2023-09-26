using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteBookCommandTest(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            command.BookId=0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Invalid BookId, Book not found!");
        }

        [Fact]
        public void WhenGivenBookIdinDB_Book_ShouldBeRemove()
        {
            DeleteBookCommand command = new DeleteBookCommand(_dbContext);
            command.BookId=1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var book = _dbContext.Books.SingleOrDefault(book=>book.Id == command.BookId);
            book.Should().Be(null);
        }
    }
}