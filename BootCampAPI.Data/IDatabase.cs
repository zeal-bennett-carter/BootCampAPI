using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data
{
    public interface IDatabase
    {
        public void Migrate();
    }
}
