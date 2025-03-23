using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Services
{
    internal interface ICreateBookService
    {
        Task<bool> ValidateAuthor(int authorId);
    }
}
