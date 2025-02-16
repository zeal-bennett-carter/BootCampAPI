using BootCampAPI.Data.Entities;
using BootCampAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Repository
{
    internal class AuthorRepository(BootCampDBContext db): IAuthorRepository
    {
        public async Task<Author?> Get(int authorId)
        {
            var entity = db.Set<AuthorEntity>()
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
            var entity = db.Set<AuthorEntity>()
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

                db.Add(entity);
            }

            await db.SaveChangesAsync();
        }
    }
}
