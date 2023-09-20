using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooksId
{
    public class GetBooksIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBooksIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BooksIdViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Invalid BookId, Book not found!");

            BooksIdViewModel vm = new BooksIdViewModel();
            vm.Title = book.Title;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");

            return vm;
        }

        public class BooksIdViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}