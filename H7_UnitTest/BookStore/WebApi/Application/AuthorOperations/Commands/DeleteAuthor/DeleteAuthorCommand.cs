using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
            var authorBooks = _dbContext.Books.SingleOrDefault(a => a.AuthorId == AuthorId);
            
            if (author is null)
                throw new InvalidOperationException("Invalid AuthorId...");
                
            if (authorBooks is not null)
                throw new InvalidOperationException($"{author.FirstName} {author.LastName} has a published book. Please delete book first.");
                
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}