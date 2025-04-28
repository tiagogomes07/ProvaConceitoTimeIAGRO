using AutoMapper;
using Books.Application.DTO;
using Books.Application.Services;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public class BookServiceTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _mapperMock = new Mock<IMapper>();
            _bookService = new BookService(_bookRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public void GetAllBooks_ShouldReturnMappedBooks()
        {
            var bookEntities = new List<Book>
            {
                new Book(1, "Book 1", 100, new Specification("2023", "Author 1", 300, "Illustrator 1", "Genre 1")),
                new Book(2, "Book 2", 200, new Specification("2023", "Author 2", 400, "Illustrator 2", "Genre 2"))
            };
            var bookDtos = new List<BookDTO>
            {
                new BookDTO { Id = 1, Name = "Book 1", Price = 100, Specifications = new SpecificationDTO() },
                new BookDTO { Id = 2, Name = "Book 2", Price = 200, Specifications = new SpecificationDTO() }
            };

            _bookRepositoryMock.Setup(r => r.GetAllBooks()).Returns(bookEntities);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(bookEntities)).Returns(bookDtos);

            var result = _bookService.GetAllBooks();

            Assert.AreEqual(bookDtos, result);
        }

        [Test]
        public void GetBookById_ShouldReturnMappedBook()
        {
            var bookEntity = new Book(1, "Test Book", 100, new Specification("2023", "Author", 300, "Illustrator", "Genre"));
            var bookDto = new BookDTO { Id = 1, Name = "Test Book", Price = 100, Specifications = new SpecificationDTO() };

            _bookRepositoryMock.Setup(r => r.GetBookById(1)).Returns(bookEntity);
            _mapperMock.Setup(m => m.Map<BookDTO>(bookEntity)).Returns(bookDto);

            var result = _bookService.GetBookById(1);

            Assert.AreEqual(bookDto, result);
        }

        [Test]
        public void CalculateShippingCost_ShouldReturnCorrectValue()
        {
            var bookEntity = new Book(1, "Test Book", 100, new Specification("2023", "Author", 300, "Illustrator", "Genre"));

            _bookRepositoryMock.Setup(r => r.GetBookById(1)).Returns(bookEntity);

            var result = _bookService.CalculateShippingCost(1);

            Assert.AreEqual(20, result); // 20% of 100
        }

        [Test]
        public void SearchBooksByAuthor_ShouldReturnFilteredBooks()
        {
            var bookEntities = new List<Book>
            {
                new Book(1, "Book 1", 100, new Specification("2023", "Author 1", 300, "Illustrator 1", "Genre 1")),
                new Book(2, "Book 2", 200, new Specification("2023", "Author 2", 400, "Illustrator 2", "Genre 2"))
            };
            var filteredBookDtos = new List<BookDTO>
            {
                new BookDTO { Id = 1, Name = "Book 1", Price = 100, Specifications = new SpecificationDTO { Author = "Author 1" } }
            };

            _bookRepositoryMock.Setup(r => r.GetAllBooks()).Returns(bookEntities);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(It.IsAny<IEnumerable<Book>>()))
                .Returns(filteredBookDtos);

            var result = _bookService.SearchBooks("Author 1", true);

            Assert.AreEqual(filteredBookDtos, result);
        }

        [Test]
        public void SearchBooksByName_ShouldReturnFilteredBooks()
        {
            var bookEntities = new List<Book>
            {
                new Book(1, "Book 1", 100, new Specification("2023", "Author 1", 300, "Illustrator 1", "Genre 1")),
                new Book(2, "Book 2", 200, new Specification("2023", "Author 2", 400, "Illustrator 2", "Genre 2"))
            };
            var filteredBookDtos = new List<BookDTO>
            {
                new BookDTO { Id = 1, Name = "Book 1", Price = 100, Specifications = new SpecificationDTO() }
            };

            _bookRepositoryMock.Setup(r => r.GetAllBooks()).Returns(bookEntities);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(It.IsAny<IEnumerable<Book>>()))
                .Returns(filteredBookDtos);

            var result = _bookService.SearchBooks("Book 1", true);

            Assert.AreEqual(filteredBookDtos, result);
        }

        [Test]
        public void SearchBooksByAtributes_ShouldReturnFilteredBooks()
        {
            var bookEntities = new List<Book>
            {
                new Book(1, "Book 1", 100, new Specification("2023", "Author 1", 300, "Illustrator 1", "Genre 1")),
                new Book(2, "Book 2", 200, new Specification("2023", "Author 2", 400, "Illustrator 2", "Genre 2"))
            };
            var filteredBookDtos = new List<BookDTO>
            {
                new BookDTO { Id = 1, Name = "Book 1", Price = 100, Specifications = new SpecificationDTO { Genres = "Genre 1" } }
            };

            _bookRepositoryMock.Setup(r => r.GetAllBooks()).Returns(bookEntities);
            _mapperMock.Setup(m => m.Map<IEnumerable<BookDTO>>(It.IsAny<IEnumerable<Book>>()))
                .Returns(filteredBookDtos);

            var result = _bookService.SearchBooks("Genre 1", true);

            Assert.AreEqual(filteredBookDtos, result);
        }






    }
}
