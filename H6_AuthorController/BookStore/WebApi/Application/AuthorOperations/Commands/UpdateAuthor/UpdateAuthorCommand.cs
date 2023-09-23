using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorViewModel Model { get; set; }
        
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
            
            if (author is null)
                throw new InvalidOperationException("Invalid AuthorId..");
            
            _mapper.Map(Model, author);
            
            _dbContext.SaveChanges();
        }
    }

    public class UpdateAuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}