using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using turplanlegger.Models;
using Newtonsoft.Json;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.OptionsModel;

namespace turplanlegger.Services
{
    public class TurbasenService : ITurbasenService
    {   
        private readonly IHostingEnvironment _env;
        private readonly AppSettings _appSettings;
        
        public TurbasenService(
            IHostingEnvironment env,
            IOptions<AppSettings> appSettings
        )
        {
            _env = env;
            _appSettings = appSettings.Value;
        }
        
        public async Task<TurList> GetTurer()
        {
            if(string.IsNullOrEmpty(_appSettings.TurbasenApiKey))
            {
                return new TurList { Turer = DesignData.Turer };
            }
            
            using(var handler = new HttpClientHandler())
            {   
                using(var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_appSettings.TurbasenBaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    HttpResponseMessage response = await client.GetAsync("/turer?api_key=" + _appSettings.TurbasenApiKey);
                    
                    var turList = new TurList();
                    
                    if(response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var baseResponse = JsonConvert.DeserializeObject<Base>(stringResponse);
                        var turerResponse = (IList<Tur>)JsonConvert.DeserializeObject<IList<Tur>>(baseResponse.Documents.ToString());
                        turList.Turer = turerResponse;
                    }
                    
                    return turList;
                }
            }
        }
        
        internal static class DesignData
        {
            public static readonly IList<Tur> Turer = new List<Tur>
            {
                new Tur
                {
                    Id = 1,
                    Endret = "",
                    Navn = "",
                    Lisens = "",
                    GeoJson = new GeoJson
                    {
                        Type = "",
                        Coordinates = new List<Coordinate>
                        {
                            new Coordinate
                            {
                                Latitude = 0,
                                Longitude = 0
                            }
                        }
                    }
                },
                new Tur
                {
                    Id = 2,
                    Endret = "",
                    Navn = "",
                    Lisens = "",
                    GeoJson = new GeoJson
                    {
                        Type = "",
                        Coordinates = new List<Coordinate>
                        {
                            new Coordinate
                            {
                                Latitude = 0,
                                Longitude = 0
                            }
                        }
                    }
                }
            };
        }
    }
}