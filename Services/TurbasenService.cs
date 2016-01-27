using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using turplanlegger.Models;
using Newtonsoft.Json;

namespace turplanlegger.Services
{
    public class TurbasenService : ITurbasenService
    {
        public async Task<IList<Tur>> GetTurer()
        {
            var retList = new List<Tur>();
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync("");
                if(response.IsSuccessStatusCode)
                {
                    retList = Task.Factory.StartNew(() => 
                        JsonConvert.DeserializeObject<List<Tur>>(response.Content.ToString())
                    ).Result;
                }
                return retList;
            }
        }
    }
}