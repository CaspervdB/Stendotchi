using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Stendotchi
{
    public static class RestHelper
    {
        /// <summary>
        /// Makes a request to the server and returns detected objects.
        /// </summary>
        /// <param name="imagefile">Stream to file</param>
        /// <returns></returns>
        public static async Task<string[]> DetectObjects(FileStream imagefile)
        {
            HttpContent fileStreamContent = new StreamContent(imagefile);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, "file", Path.GetFileName(imagefile.Name));
                var response = await client.PostAsync("https://stendotchi-test.herokuapp.com/img", formData);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var resp = await response.Content.ReadAsStringAsync();
                var parse = JArray.Parse(resp);
                return parse.Select(x => x[0].ToString()).ToArray();
            }
        }

        // We zorgen er voor dat heroku online is.
        public static async Task PingHerokuAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://stendotchi-test.herokuapp.com/");
                var resp = await response.Content.ReadAsStringAsync();
                var parse = JArray.Parse(resp);
            }
            Console.WriteLine("Heroku is nu waarschijnlijk online.");
        }

        public static IRestResponse Post(string baseUrl, string resourceUrl, string json)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.POST)
            {
                Timeout = 20 * 1000 //added extra timeout		
            };
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }
    }
}