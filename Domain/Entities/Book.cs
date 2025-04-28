using System;
using System.Text.Json.Serialization;

namespace Books.Domain.Entities
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("price")]
        public decimal price { get; set; }

        [JsonPropertyName("specifications")]
        public Specification specifications { get; set; }

        [JsonConstructor]
        public Book(int id, string name, decimal price, Specification specifications)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.specifications = specifications;
        }
    }
}