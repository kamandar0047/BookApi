using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
