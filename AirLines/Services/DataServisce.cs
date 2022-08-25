using AirLines.ApiModel;
using AirLines.Data;
using AirLines.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirLines.Services
{
    public class DataServisce
    {
       readonly Uri  baseAddress = new Uri("https://localhost:7014/");
       readonly HttpClient httpClient = new HttpClient();
        private readonly IMapper _mapper;

        public DataServisce(IMapper mapper)
        {
            _mapper = mapper;
            httpClient.BaseAddress = baseAddress;
        }
        public List<AirlineViewModel> GetAirlines()
        {
            HttpResponseMessage Response = httpClient.GetAsync(baseAddress + "AirLines/GetAllAirLines").Result;
            if (Response.IsSuccessStatusCode)
            {
                string data = Response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<AirLineApiModel>>(data);
                var airlines = _mapper.Map<List<AirlineViewModel>>(list);
                return airlines;

            }

            return new List<AirlineViewModel>();


        }
        public bool AddAirLines(AirlineViewModel airline)
        {
            var airlineApiModel = _mapper.Map<AirLineApiModel>(airline);
            
            var data = JsonConvert.SerializeObject(airlineApiModel);
            var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(baseAddress + "AirLines/CreateAirLines", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }
        public  AirlineViewModel GetById(int? id)
        {
            HttpResponseMessage response =  httpClient.GetAsync(baseAddress + "AirLines/GetAirLineId/Id?id=" + id).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            AirLineApiModel data = JsonConvert.DeserializeObject<AirLineApiModel>(stringData)!;
            var airlines = _mapper.Map<AirlineViewModel>(data);
            return (airlines);
        }
        public bool Update(AirlineViewModel airlineViewModel)
        {
            var airlineApi = _mapper.Map<AirLineApiModel>(airlineViewModel);
            string stringData = JsonConvert.SerializeObject(airlineApi);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(baseAddress + "AirLines/updateAirLines", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
