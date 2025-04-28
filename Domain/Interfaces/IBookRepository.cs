using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();

    }
}
