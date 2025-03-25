using BootCampAPI.Application;
using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Data.Entities;
using BootCampAPI.Domain.Models.AuthorContent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Repository
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly BootCampDBContext _db;
        private readonly IDomainEventsStorage _domainEventsStorage;

        public AuthorRepository(BootCampDBContext db, IDomainEventsStorage domainEventsStorage)
        {
            this._db = db;
            this._domainEventsStorage = domainEventsStorage;
        }

        public async Task<Author?> Get(int authorId)
        {
            var entity = _db.Set<AuthorEntity>()
                .FirstOrDefault(e => e.AuthorId == authorId);

            if (entity == null)
            {
                return null;
            }

            return await Task.FromResult(Author.Create(
                entity.AuthorId,
                entity.Name,
                entity.Age,
                entity.Status
                ));
        }

        public async Task Save(Author author)
        {
            var entity = _db.Set<AuthorEntity>()
                .FirstOrDefault(e => e.AuthorId == author.AuthorId);

            if (entity == null)
            {
                entity = new AuthorEntity
                {
                    AuthorId = author.AuthorId,
                    Name = author.Name,
                    Age = author.Age,
                    Status = author.Status.ToString()
                };

                _db.Add(entity);
            }

            //await _db.SaveChangesAsync();

            _domainEventsStorage.Enqueue(author.PullEvents());
        }
    }
}
