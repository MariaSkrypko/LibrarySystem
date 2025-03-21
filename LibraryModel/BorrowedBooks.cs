using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class BorrowedBook
    {
        public int BorrowedBookId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
