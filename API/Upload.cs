using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace API
{
    class Upload
    {
        static void res(string[] args)
        {
            string url = @"https://marlow-dev-assessment-exam.vercel.app/upload";
            string path = "C:\\Users\\rohit.jeerh\\Downloads\\CV_2022100715325245.pdf";
            string accesskey = "testing123";
            GetFileContentByName(path, url, accesskey);
        }
        private static void GetFileContentByName(string path,string URL, string key)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(bytes);
            Console.WriteLine(file);
            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization","Bearer " +key);
            var body = @"{
                        " + "\n" +
                        @"""Name"": ""Rohit Jeerh"",
                        " + "\n" +
                        @"""mime"": ""application/pdf"",
                        " + "\n" +
                        @"""file"": "" "",
                        " + "\n" +
                        @"}"; ;
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //request.AddParameter("application/json", "{ \"file\": \"" + file + "\" }", ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Request failed with the following error/status code: " + response.StatusCode);
                Console.ReadLine();
                return;
            }
            Console.WriteLine(response.StatusCode);
        }
    }
}
