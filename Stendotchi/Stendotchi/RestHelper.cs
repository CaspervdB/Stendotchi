using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;

namespace ShopProject
{
    public static class RestHelper
    {

        public static IRestResponse Post(string baseUrl, string resourceUrl, string json)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.POST);
            request.Timeout = 20 * 1000; //added extra timeout		
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static async Task<IRestResponse> PostAsync(string baseUrl, string resourceUrl, string json)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.POST);
            request.Timeout = 20 * 1000; //added extra timeout
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static async Task<IRestResponse> GetAsync(string baseUrl, string resourceUrl)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.GET);
            request.Timeout = 20 * 1000; //added extra timeout
            //request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static IRestResponse Get(string baseUrl, string resourceUrl)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.GET);
            request.Timeout = 20 * 1000; //added extra timeout		
            //request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static string ConvertObjectToJson(object arg)
        {
            return JsonConvert.SerializeObject(arg);
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}