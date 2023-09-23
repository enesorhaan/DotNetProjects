using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Invalid AuthorId, Author not found..");
            
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
            return vm;
        }
    }

    public class AuthorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}