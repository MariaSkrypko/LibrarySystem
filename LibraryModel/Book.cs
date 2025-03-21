using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{


  
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public ICollection<Author> Authors { get; set; }
            public string PublisherCode { get; set; } 
            public string PublisherType { get; set; }
            public int Year { get; set; }
            public string PublisherCountry { get; set; }
            public string PublisherCity { get; set; }
        }
    }





