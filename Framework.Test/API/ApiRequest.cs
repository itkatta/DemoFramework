using System;
using System.Net.Http;
using System.Text;
using Framework.Test.Models;
using Newtonsoft.Json;

namespace Framework.Test.API
{
    public class ApiRequest
    {



        private UriBuilder builder;
        private StringBuilder query;

        public ApiRequest(Config config)
        {
            this.builder = new UriBuilder();
            this.builder.Host = config.ApiBaseUri;
            this.builder.Path = "/data/2.5/weather";
            this.query = new StringBuilder($"appid={config.AppId}&");
        }

        public ApiRequest WithCity(string cityName)
        {
            this.query.Append($"q={cityName}&");
            return this;
        }

        public ApiRequest WithXmlFormat()
        {
            this.query.Append($"mode=xml&");
            return this;
        }

        public ApiRequest WithUnit(Units unit)
        {
            switch (unit)
            {
                case Units.metric:
                    this.query.Append($"units=metric&");
                    break;
                case Units.imperial:
                    this.query.Append($"units=imperial&");
                    break;
            }
            return this;
        }

        public ApiRequest Build()
        {
            this.builder.Query = this.query.ToString();
            return this;
        }

        public ApiResponse Execute()
        {
            HttpResponseMessage result;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.builder.Uri;

                result = client.GetAsync(client.BaseAddress).Result;
            }

            if (result.IsSuccessStatusCode)
            {
                string body = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ApiResponse>(body);

            }

            return null;
        }
    }

    public enum Units
    {
        metric,
        imperial

    }
}
