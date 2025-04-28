using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Books.Domain.Entities;
using Books.Domain.Interfaces;

namespace Books.Persistence.Repository
{
        public class BookJsonRepository : IBookRepository
        {
            private readonly string _filePath;

        private static List<Book> _cachedBooks;

        //foi implementado um singleton que guarda em memoria a
        //lista de livros evitando ter que ficar sempre relendo o arquivo json.
        //Com isso econmiza-se processamento, leitura em disco, e melhora-se a perfomance geral do sistema.
        private IEnumerable<Book> LoadBooks()
        {
            if (_cachedBooks != null) return _cachedBooks;
            if (!File.Exists(_filePath))
            {
                _cachedBooks = new List<Book>();
               
            }
            var json = File.ReadAllText(_filePath);
            _cachedBooks = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            return _cachedBooks;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return LoadBooks();
        }

        public BookJsonRepository(string filePath)
            {
                _filePath = filePath;
            }

            public Book GetBookById(int id)
            {
                var books = LoadBooks();
                return books.FirstOrDefault(b => b.id == id);
            }

        }
    }


