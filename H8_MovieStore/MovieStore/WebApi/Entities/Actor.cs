﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
