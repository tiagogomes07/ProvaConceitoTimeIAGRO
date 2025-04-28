using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Specification
    {

        [JsonPropertyName("Originally published")]
        public string OriginallyPublished { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("Page count")]
        public int PageCount { get; set; }

        [JsonPropertyName("Illustrator")]
        public object Illustrator { get; set; }

        [JsonPropertyName("Genres")]
        public object Genres { get; set; }

        [JsonConstructor]
        public Specification(string OriginallyPublished, string Author, int PageCount, object Illustrator, object Genres)
        {
            this.OriginallyPublished = OriginallyPublished;
            this.Author = Author;
            this.PageCount = PageCount;
            this.Illustrator = Validate(Illustrator);
            this.Genres = Validate(Genres);
        }

        private object Validate(object item)
        {
            if(item is string)
            {
                return new object[] { item };
            }
            else
            {
                return item;
            }
        }
    }
}
