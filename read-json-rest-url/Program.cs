using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace read_json_rest_url
{
    class Program
    {
        public static void OutputJSONData(System.Collections.Generic.IEnumerable<JProperty> properties) 
        {
            foreach (JProperty prop in properties)
            {
                    Console.WriteLine(prop.Name  + " = " + prop.Value.ToString());
            }
        }

        static void Main(string[] args)
        {

            //Call the REST end point for JSON data
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            if (args.Length == 1)
                url = args[0];

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Get(request);

            //Use JSON.NET to process data
            //simple scenario w/o deserialization class
            var token = JToken.Parse(response.Content);
            if (token is JArray)
            {
                JArray array = JArray.Parse(response.Content);
                foreach (JObject content in array.Children<JObject>())
                {
                    OutputJSONData(content.Properties());
                    Console.WriteLine("------------------------");
                }
            }
            else if (token is JObject)
            {
                JObject content = JObject.Parse(response.Content);
                OutputJSONData(content.Properties());
            }
        }
    }
}
