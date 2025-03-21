using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{


        public class Author
        {
            public int AuthorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public DateTime BirthDate { get; set; }

            // Добавляем коллекцию книг, написанных этим автором
            public ICollection<Book> Books { get; set; }
        }
    


}
