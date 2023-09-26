using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksId;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            
            GetBooksIdQuery bookDetailQuery = new GetBooksIdQuery(_context,_mapper);
            bookDetailQuery.BookId=0;
                        

            FluentActions.Invoking(() => bookDetailQuery.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Invalid BookId, Book not found!");

                
       }

        [Fact]
        public void WhenGivenBookIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetBooksIdQuery bookDetailQuery = new GetBooksIdQuery(_context,_mapper);
            bookDetailQuery.BookId=1;
            

            FluentActions.Invoking(()=> bookDetailQuery.Handle()).Invoke();

            var book=_context.Books.SingleOrDefault(book=>book.Id == bookDetailQuery.BookId);
            book.Should().NotBeNull();
        }
    }
}