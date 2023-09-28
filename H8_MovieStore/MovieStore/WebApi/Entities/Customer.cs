using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Enums;

namespace WebApi.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> PurchasedMovies { get; set; }
        public List<Category> FavCategories { get; set; }

    }
}
