using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using turplanlegger.Models;

namespace turplanlegger.Services
{
    public interface ITurbasenService
    {
        Task<IList<Tur>> GetTurer();
    }
}