using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TesteGazinFrontEnd.Models;

namespace TesteGazinFrontEnd.HttpSolicitacao
{

    public class HttpSolicitacao
    {
        private const string URL_BASE_API = "https://localhost:44366";
        private const string URL_API = "api/DesenvolvedoresModels/$";

        private HttpClient _cliente;
        public HttpSolicitacao()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(URL_BASE_API);
            _cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Desenvolvedor>> GetDevsAsync()
        {
            List<Desenvolvedor> devs = null; 
            HttpResponseMessage response = await _cliente.GetAsync(URL_API.Replace("$", ""));
            if (response.IsSuccessStatusCode)
            {
                devs = await response.Content.ReadAsAsync<List<Desenvolvedor>>();
            }
            return devs;
        }
        public async Task<Desenvolvedor> GetDevAsync(string id)
        {
            Desenvolvedor dev = null;
            HttpResponseMessage response = await _cliente.GetAsync(URL_API.Replace("$", id.ToString()));
            if (response.IsSuccessStatusCode)
            {
                dev = await response.Content.ReadAsAsync<Desenvolvedor>();
            }
            return dev;
        }

        public Desenvolvedor GetDev(string id)
        {
            Desenvolvedor dev = null;
            HttpResponseMessage response = _cliente.GetAsync(URL_API.Replace("$", id.ToString())).Result;
            if (response.IsSuccessStatusCode)
            {
                dev = response.Content.ReadAsAsync<Desenvolvedor>().Result;
            }
            return dev;
        }

        public async Task<Uri> CreateDevAsync(Desenvolvedor dev)
        {
            HttpResponseMessage response = await _cliente.PostAsJsonAsync(URL_API.Replace("$", ""), dev);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        public async Task<Desenvolvedor> UpdateDevAsync(Desenvolvedor dev)
        {
            HttpResponseMessage response = await _cliente.PutAsJsonAsync(URL_API.Replace("$", dev.Id.ToString()), dev);
            response.EnsureSuccessStatusCode();

            dev = await response.Content.ReadAsAsync<Desenvolvedor>();
            return dev;
        }
        public HttpResponseMessage DeleteDev(string id)
        {
            HttpResponseMessage response = _cliente.DeleteAsync(URL_API.Replace("$", id)).Result;
            return response;
        }
    }
}