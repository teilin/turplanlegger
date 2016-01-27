using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using turplanlegger.Models;

namespace turplanlegger.Services
{
    public class TurbasenService : ITurbasenService
    {
        public async Task GetTurer()
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync("");
            }
            throw new NotImplementedException();
        }
    }
}