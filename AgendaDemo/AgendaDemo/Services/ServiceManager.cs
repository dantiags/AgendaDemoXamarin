using AgendaDemo.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLAppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDemo.Services
{
    public static class ServiceManager
    {
        private static String baseUrl = ConfigurationManager.AppSettings["baseUrl"]; 

        public  static List<Contact> GetContacts(string authToken)
        {
            var list = new List<Contact>();
            var method = "get_contacts";
            var url = string.Format( method + @"?auth_token={0}", authToken);

            var jsonResponse = makeJSONCall(url);

            JToken token = JObject.Parse(jsonResponse);
            JToken usersToken = token.SelectToken("data").SelectToken("users");
            list = JsonConvert.DeserializeObject<List<Contact>>(usersToken.ToString());

            return list;

        }

        public static String makeJSONCall(string methodUrl)
        {
            var response = makeCall(methodUrl);
            var responseJson = response.Content.ReadAsStringAsync().Result;

            return responseJson;
        }

        public static HttpResponseMessage makeCall(string methodUrl)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var response = httpClient.GetAsync(methodUrl).Result;
            return response;
        }

    }
}
