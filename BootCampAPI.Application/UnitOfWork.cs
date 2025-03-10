using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampAPI.Application.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BootCampAPI.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatastore _dbContext;

        public UnitOfWork(IDatastore dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChanges();
        }
    }
}
