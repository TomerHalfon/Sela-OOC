using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeClass
{
    class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }

        public Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
        }
    }
}
