using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    class sendingReq
    {
        static void Main(string[] args)
        {
            string url = @"https://marlow-dev-assessment-exam.vercel.app/upload";
            string path = "C:\\Users\\rohit.jeerh\\Downloads\\Resume.pdf";
            string accesskey = "testing123";
            GetFileContentByName(path, url, accesskey);

        }
        private static void GetFileContentByName(string path, string URL, string key)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(bytes);
            Console.WriteLine(file);

            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/pdf");
            request.AddHeader("Authorization", "Bearer " + key);

            var body = @"{
                        " + "\n" +
                        @"""name"": ""Rohit Jeerh"",
                        " + "\n" +
                        @"""mime"": ""application/pdf"",
                        " + "\n" +
                        @"""file"":"+'"'+""+file+""+'"'+""
                         + "\n" +
                        @"}";
            Console.WriteLine(body);
            Console.WriteLine(body.Length);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Request failed with the following error/status code: " + response.StatusCode);
                Console.ReadLine();
                return;
            }
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Console.ReadLine();
        }
    }
}
