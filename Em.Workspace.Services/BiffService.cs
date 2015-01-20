using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Biff.Model;
using Biff.Services.Contracts;
using System.Net.Http.Formatting;

namespace Em.Workspace.Services
{
    public class BiffService : IBiffService
    {
        private IEnumerable<BiffObject> _results = new List<BiffObject>();

        public BiffService()
        {

        }

        public async Task<IEnumerable<BiffObject>> GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50951/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/Biff");
                if (response.IsSuccessStatusCode)
                {
                    _results = await response.Content.ReadAsAsync<IEnumerable<BiffObject>>();
                }
            }
            return _results;
        }
    }
}
    

