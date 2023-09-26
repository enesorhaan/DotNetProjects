using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if(genre is null)
                throw new InvalidOperationException("Invalid GenreId, Book Genre not found..");
            
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}