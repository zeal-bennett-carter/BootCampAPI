﻿using BootCampAPI.Domain.Models.AuthorContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Models
{
    public class BookSeries : Entity
    {
        internal BookSeries(int bookSeriesId, Author author, List<Book> booksInSeries)
        {
            BookSeriesId = bookSeriesId;
            Author = author;
            BooksInSeries = booksInSeries;
        }

        public static BookSeries Create(int bookSeriesId, Author author, List<Book> booksInSeries)
        {
            if (bookSeriesId.Equals(null))
                throw new ArgumentException("BookSeriesId cannot be null", nameof(bookSeriesId));

            if (author == null)
                throw new ArgumentException("Author cannot be empty", nameof(author));

            if (booksInSeries.Equals(null))
                throw new ArgumentException("BooksInSeries cannot be null", nameof(booksInSeries));

            var bookIds = new List<int>();

            foreach (var seriesBook in booksInSeries)
            {
                var seriesBookId = seriesBook.BookId;

                if (bookIds.Contains(seriesBookId))
                    throw new ArgumentException("A series cannot contain duplicate books", nameof(seriesBook));

                bookIds.Add(seriesBookId);
            }

            return new BookSeries(bookSeriesId, author, booksInSeries);
        }

        public int BookSeriesId { get; private set; }
        public Author Author { get; private set; }
        private List <Book> BooksInSeries {get; set; } 

        public void ChangeAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentException("Author cannot be empty", nameof(author));

            Author = author;
        }

        public List<Book> GetBooksInSeries()
        {
            return new List<Book>(BooksInSeries);
        }

        public void AddBookToSeries(Book book)
        {
            var bookIds = new List<int>();

            foreach (var seriesBook in BooksInSeries)
            {
                var seriesBookId = seriesBook.BookId;
                bookIds.Add(seriesBookId);
            }

            if(bookIds.Contains(book.BookId))
                throw new ArgumentException("Book is already in series", nameof(book));

            BooksInSeries.Add(book);
        }

        public void RemoveBookFromSeries(Book book)
        {
            var bookIds = new List<int>();

            foreach (var seriesBook in BooksInSeries)
            {
                var seriesBookId = seriesBook.BookId;
                bookIds.Add(seriesBookId);
            }

            if (!bookIds.Contains(book.BookId))
                throw new ArgumentException("Book already is not in series", nameof(book));

            BooksInSeries.Remove(book);
        }
    }
}
