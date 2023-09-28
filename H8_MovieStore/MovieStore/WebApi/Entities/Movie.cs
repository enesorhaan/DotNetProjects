using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Enums;

namespace WebApi.Entities
{
    public class Movie : BaseEntity
    {
        public string MovieName { get; set; }
        public DateTime MovieDate { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }

        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
