using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Queries.GetBooksId
{
    public class GetBooksIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        private readonly IMapper _mapper;
        public GetBooksIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BooksIdViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).SingleOrDefault(b => b.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Invalid BookId, Book not found!");

            BooksIdViewModel vm = _mapper.Map<BooksIdViewModel>(book); //new BooksIdViewModel();
            // vm.Title = book.Title;
            // vm.Genre = ((GenreEnum)book.GenreId).ToString();
            // vm.PageCount = book.PageCount;
            // vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");

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