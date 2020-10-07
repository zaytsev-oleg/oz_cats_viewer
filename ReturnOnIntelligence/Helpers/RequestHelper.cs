using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ReturnOnIntelligence.Helpers
{
    using System.IO;
    using System.Text;
    using Models;

    public class RequestHelper
    {
        public RequestHelper()
        {
            HttpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        protected static readonly string ImagesUri     = "http://thecatapi.com/api/images/get";
        // ConfigurationManager.AppSettings["ImagesUri"]

        protected static readonly string CategoriesUri = "http://thecatapi.com/api/categories/list";
        // ConfigurationManager.AppSettings["CategoriesUri"]

        protected readonly HttpClient HttpClient;

        protected async Task<string> GetResponse(string requestUri)
        {
            string result;

            using (var stream = await HttpClient.GetStreamAsync(requestUri))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = await reader.ReadToEndAsync();
                }
            }

            return result;
        }

        public async Task<Category[]> GetCategories()
        {
            var xml = new XmlSerializer(typeof(Response<Categories>));
            var response = (Response<Categories>) xml.Deserialize(new StringReader(await GetResponse(CategoriesUri)));

            return response.Data?.Items ?? new Category[0];
        }

        public async Task<Image[]> GetImages(RequestParameters parameters)
        {
            if (!parameters.AreValid)
            {
                return new Image[0];
            }

            var xml = new XmlSerializer(typeof(Response<Images>));
            var response = (Response<Images>) xml.Deserialize(new StringReader(await GetResponse($"{ImagesUri}?{parameters}")));

            return response.Data?.Items ?? new Image[0];
        }
    }
}