using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data
{
    public interface IDatastore
    {
        Task SaveChanges();
    }
}
