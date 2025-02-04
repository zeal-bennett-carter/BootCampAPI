using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Models
{
    public class Author
    {

        internal Author(int authorId, string name, int age, AuthorStatus status, List<Book> books)
        {
            AuthorId = authorId;
            Name = name;
            Age = age;
            Status = status;
            Books = books;
        }

        public static Author Create(int authorId, string name, int age, AuthorStatus status, List<Book> books)
        {
            if (authorId.Equals(null))
                throw new ArgumentException("AuthorId cannot be null", nameof(authorId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (age <= 0)
                throw new ArgumentException("Age cannot be less than or equal to zero", nameof(age));

            if (!Enum.IsDefined(typeof(AuthorStatus), status))
                throw new ArgumentException("Author's status must be Alive, Retired, or Deceased");

            return new Author(authorId, name, age, status, books);
        }

        public int AuthorId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public AuthorStatus Status { get; private set; }
        public List<Book> Books { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            Name = name;
        }

        public void ChangeAge(int age)
        {
            if (age <= 0)
                throw new ArgumentException("Age cannot be less than or equal to zero", nameof(age));

            Age = age;
        }

        public void ChangeStatus(AuthorStatus status)
        {
            if (!Enum.IsDefined(typeof(AuthorStatus), status))
                throw new ArgumentException("Author's status must be Alive, Retired, or Deceased");

            Status = status;
        }

        public void AddBookToSeries(Book book)
        {
            var bookIds = new List<int>();

            foreach (var seriesBook in Books)
            {
                var seriesBookId = seriesBook.BookId;
                bookIds.Add(seriesBookId);
            }

            if (bookIds.Contains(book.BookId))
                throw new ArgumentException("Book is already in series", nameof(book));

            Books.Add(book);
        }

        public void RemoveBookFromSeries(Book book)
        {
            var bookIds = new List<int>();

            foreach (var seriesBook in Books)
            {
                var seriesBookId = seriesBook.BookId;
                bookIds.Add(seriesBookId);
            }

            if (!bookIds.Contains(book.BookId))
                throw new ArgumentException("Book already is not in series", nameof(book));

            Books.Remove(book);
        }
    }
}
