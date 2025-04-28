using AutoMapper;
using Books.Application.DTO;
using Books.Application.Interfaces;
using Books.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Books.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public BookDTO GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return _mapper.Map<BookDTO>(book);
        }

        public decimal CalculateShippingCost(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book == null)
                throw new ArgumentException("Book not found.", nameof(bookId));

            return book.price * 0.2m;
        }

        public IEnumerable<BookDTO> SearchBooks(string keyWord, bool ascendingPriceOrder)
        {
            var books = _bookRepository.GetAllBooks();

            if (String.IsNullOrEmpty(keyWord))
            {
                books = books.ToList();
            }
            else
            {
                books = books.Where(b =>
                b.name?.Contains(keyWord, StringComparison.OrdinalIgnoreCase) == true ||
                b.specifications.Author?.Contains(keyWord, StringComparison.OrdinalIgnoreCase) == true ||
                b.specifications.OriginallyPublished?.Contains(keyWord, StringComparison.OrdinalIgnoreCase) == true ||
                b.specifications.Illustrator?.ToString().Contains(keyWord, StringComparison.OrdinalIgnoreCase) == true ||
                b.specifications.Genres?.ToString().Contains(keyWord, StringComparison.OrdinalIgnoreCase) == true);
            }

            if (ascendingPriceOrder)
            {
                books = books.OrderBy(b => b.price).ToList();
            }

            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }
    }

}
