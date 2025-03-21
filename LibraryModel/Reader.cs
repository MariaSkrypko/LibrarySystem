using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{

  
        public class Reader
        {
            public int ReaderId { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DocumentType { get; set; } // Паспорт, вод. права
            public string DocumentNumber { get; set; }
        }
    



}
