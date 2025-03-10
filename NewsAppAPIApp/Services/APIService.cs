using NewsAppAPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAppAPIApp.Services
{
    public class APIService
    {
        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey=a34e9cf26e3bd8f9f20567be97d47b7a&lang=en&expand=content");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
