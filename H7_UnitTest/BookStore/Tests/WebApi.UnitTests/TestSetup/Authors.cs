using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author{ FirstName = "Eric", LastName = "Ries", BirthDay = new DateTime(1978,09,22) },
                new Author{ FirstName = "Linda", LastName = "Charpman", BirthDay = new DateTime(1969,01,15) },
                new Author{ FirstName = "Frank", LastName = "Herbert", BirthDay = new DateTime(1920,10,08) }
            );
        }
    }
}