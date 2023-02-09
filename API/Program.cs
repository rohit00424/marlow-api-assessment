using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace API
{
    class Program
    {
        static void PI(string[] args)
        {
            string url = @"https://marlow-dev-assessment-exam.vercel.app/register";
            CallRestMethod(url);
        }
        private static void CallRestMethod(string URL)
        {
            var client = new RestClient(URL);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                        " + "\n" +
                        @"""Name"": ""Rohit Jeerh"",
                        " + "\n" +
                        @"""Email"": ""rohit.jeerh@umtc.com.ph"",
                        " + "\n" +
                        @"""Mobile"": ""09771229785"",
                        " + "\n" +
                        @"""Languages"": ""C#, VB.Net"",
                        " + "\n" +
                        @"""Source"": ""Linkedin""
                        " + "\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
