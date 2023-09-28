using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                    return;
                
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Eric",
                        LastName = "Ries",
                        BirthDay = new DateTime(1978,09,22)
                    },
                    new Author
                    {
                        FirstName = "Linda",
                        LastName = "Charpman",
                        BirthDay = new DateTime(1969,01,15)
                    },
                    new Author
                    {
                        FirstName = "Frank",
                        LastName = "Herbert",
                        BirthDay = new DateTime(1920,10,08)
                    }
                );

                context.Genres.AddRange(
                    new Genre{
                        Name = "Personal Growth"
                    },
                    new Genre{
                        Name = "Science Fiction"
                    },
                    new Genre{
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book{ 
                    //   Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        AuthorId = 1, 
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book{ 
                    //    Id = 2,
                        Title = "Healand",
                        GenreId = 2,
                        AuthorId = 2, 
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23)
                    },
                    new Book{ 
                    //    Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        AuthorId = 3, 
                        PageCount = 540,
                        PublishDate = new DateTime(2002,12,21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}