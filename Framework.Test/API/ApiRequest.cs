using System;
using System.Net.Http;
using System.Text;
using Framework.Test.Models;
using Newtonsoft.Json;

namespace Framework.Test.API
{
    /// <summary>
    /// Api request class.
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// The URI builder instance.
        /// </summary>
        private UriBuilder builder;

        /// <summary>
        /// The query parameter for request.
        /// </summary>
        private StringBuilder query;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public ApiRequest(Config config)
        {
            this.builder = new UriBuilder();
            this.builder.Host = config.ApiBaseUri;
            this.builder.Path = "/data/2.5/weather";
            this.query = new StringBuilder($"appid={config.AppId}&");
        }

        /// <summary>
        /// Create query parameter with the city.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns></returns>
        public ApiRequest WithCity(string cityName)
        {
            this.query.Append($"q={cityName}&");
            return this;
        }

        /// <summary>
        /// Create query parameter with for XML format.
        /// </summary>
        /// <returns></returns>
        public ApiRequest WithXmlFormat()
        {
            this.query.Append($"mode=xml&");
            return this;
        }

        /// <summary>
        /// Create query parameter with for unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public ApiRequest Build()
        {
            this.builder.Query = this.query.ToString();
            return this;
        }

        /// <summary>
        /// Executes this built instance.
        /// </summary>
        /// <returns></returns>
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

    /// <summary>
    /// Unit enum.
    /// </summary>
    public enum Units
    {
        metric,
        imperial

    }
}
