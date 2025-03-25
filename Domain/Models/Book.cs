using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Models
{
    public class Book : Entity
    {
        internal Book(int Id, string Title, string AuthorName, string Genre, string Description, int PageCount, int PagesRead, string Publisher)
        {
            Id = Id;
            Title = Title;
            AuthorName = AuthorName;
            Genre = Genre;
            Description = Description;
            PageCount = PageCount;
            PagesRead = PagesRead;
            Publisher = Publisher;
        }

        public static Book Create(int Id, string Title, string AuthorName, string Genre, string Description, int PageCount, int PagesRead, string Publisher)
        {
            if (Id.Equals(null))
                throw new ArgumentException("Id cannot be null", nameof(Id));

            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentException("Title cannot be empty", nameof(Title));

            if (string.IsNullOrWhiteSpace(AuthorName))
                throw new ArgumentException("Author cannot be empty", nameof(AuthorName));

            if (string.IsNullOrWhiteSpace(Genre))
                throw new ArgumentException("Genre cannot be empty", nameof(Genre));

            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("Description cannot be empty", nameof(Description));

            if(PageCount <= 0)
                throw new ArgumentException("PageCount cannot be less than or equal to zero", nameof(PageCount));

            if (PagesRead.Equals(null))
                throw new ArgumentException("PagesRead cannot be null", nameof(PagesRead));

            if (PagesRead < 0)
                throw new ArgumentException("PagesRead cannot less than zero", nameof(PagesRead));

            if (string.IsNullOrEmpty(Publisher))
                throw new ArgumentException("Publisher cannot be empty", nameof(Publisher));
                
            if(PagesRead > PageCount)
                throw new ArgumentException("PagesRead cannot be greater than PageCount", nameof(PagesRead));

            return new Book(Id, Title, AuthorName, Genre, Description, PageCount, PagesRead, Publisher);
        }

        public int BookId { get; private set; }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string Genre { get; private set; }
        public string Description { get; private set; }
        public int PageCount { get; private set; }
        public int PagesRead { get; private set; }
        public string Publisher { get; private set; }

        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty", nameof(newTitle));

            Title = newTitle;
        }

        public void ChangeAuthor(string newAuthor)
        {
            if (string.IsNullOrWhiteSpace(newAuthor))
                throw new ArgumentException("Title cannot be empty", nameof(newAuthor));

            AuthorName = newAuthor;
        }

        public void ChangeGenre(string newGenre)
        {
            if (string.IsNullOrWhiteSpace(newGenre))
                throw new ArgumentException("Genre cannot be empty", nameof(newGenre));

            Genre = newGenre;
        }

        public void ChangeDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Description cannot be empty", nameof(newDescription));

            Description = newDescription;
        }

        public void ChangePageCount(int newPageCount)
        {
            if (newPageCount <= 0)
                throw new ArgumentException("PageCount cannot be less than or equal to zero", nameof(newPageCount));

            PageCount = newPageCount;
        }

        public void ChangePagesRead(int newPagesRead)
        {
            if (newPagesRead < 0)
                throw new ArgumentException("PagesRead cannot less than zero", nameof(newPagesRead));

            if (newPagesRead > PageCount)
                throw new ArgumentException("PagesRead cannot be greater than PageCount", nameof(newPagesRead));

            PagesRead = newPagesRead;
        }

        public void ChangePublisher(string newPublisher)
        {
            if (string.IsNullOrEmpty(newPublisher))
                throw new ArgumentException("Publisher cannot be empty", nameof(newPublisher));

            Publisher = newPublisher;
        }
    }
}
