using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommandTest(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            command.BookId=0;

            
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Invalid BookId, Book not found!");

        }

        [Fact]
        public void WhenGivenBookIdinDB_Book_ShouldBeUpdate()
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);

            UpdateBookModel model = new UpdateBookModel(){Title="WhenGivenBookIdinDB_Book_ShouldBeUpdate", GenreId=1};            
            command.Model = model;
            command.BookId=1;
            
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var book=_dbContext.Books.SingleOrDefault(book=>book.Id == command.BookId);
            book.Should().NotBeNull();
            
        }
    }
}