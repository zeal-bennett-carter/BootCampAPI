using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Models
{
    public class Author
    {
        internal Author(Guid authorId, string name, int age, AuthorStatus status)
        {
            AuthorId = authorId;
            Name = name;
            Age = age;
            Status = status;
        }

        public static Author Create(string name, int age, string status) // replace author id int with guid
        {
            //if (authorId.Equals(null))
            //    throw new ArgumentException("AuthorId cannot be null", nameof(authorId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (age <= 0)
                throw new ArgumentException("Age cannot be less than or equal to zero", nameof(age));

            if (!Enum.TryParse<AuthorStatus>(status, true, out var authorStatus))
                throw new ArgumentException("Author's status must be Alive, Retired, or Deceased");

            return new Author(Guid.NewGuid(), name, age, authorStatus);
        }

        public Guid AuthorId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public AuthorStatus Status { get; private set; }

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
    }
}
