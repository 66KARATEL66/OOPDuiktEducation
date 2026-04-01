using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task3
{
    public class Task3
    {
        public void Example()
        {
            Author author = new Author
            {
                Name = "Devid",
                Books = new List<Book>()
            };

            Book book = new Book
            {
                Title = "Smth",
                Author = author
            };

            Book book2 = new Book
            {
                Title = "Book",
                Author = author
            };

            author.Books.Add(book);
            author.Books.Add(book2);

            Console.WriteLine($"{author.Name} writes {author.Books[0].Title} and his author {author.Books[0].Author.Name}");

            JsonHandler.SerializeJson(author);

            Author authorTest = JsonHandler.DeserializeJson();

            Console.WriteLine($"{authorTest.Name} writes {authorTest.Books[1].Title} and his author {authorTest.Books[1].Author.Name}");
        }
    }
}
