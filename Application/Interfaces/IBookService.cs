using Books.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IBookService
    {
        BookDTO GetBookById(int id);
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<BookDTO> SearchBooks(string keyWord, bool ascedingPriceOrder);
        decimal CalculateShippingCost(int bookId);
    }
}
