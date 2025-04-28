using Books.Application.DTO;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("search")]
        public IActionResult SearchBooks(string keyWord, bool ascendingPriceOrder)
        {
            var books = _bookService.SearchBooks(keyWord, ascendingPriceOrder);
            return Ok(books);
        }

        [HttpGet("{id}/shipping-cost")]
        public IActionResult CalculateShippingCost(int id)
        {
            try
            {
                var shippingCost = _bookService.CalculateShippingCost(id);
                return Ok(new { BookId = id, ShippingCost = shippingCost });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

    }
}
