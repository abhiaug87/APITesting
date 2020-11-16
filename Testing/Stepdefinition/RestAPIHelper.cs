using RestSharp;
using System.IO;
using Testing.Data;

namespace Testing.Stepdefinition
{
    
    public static class RestAPIHelper
    {
        public static RestClient rc;
        public static RestRequest rq;
        public static string url = "https://api.tmsandbox.co.nz/";
        static JSON read = new JSON();

        public static RestClient Url()
        {

            var url = "https://api.tmsandbox.co.nz/";
            return rc = new RestClient(url);
        }

        public static RestRequest parameters(string content, string corr, string reqid, string token, string encoding, string conn)
        {  
            rc = new RestClient(url);
           // rq = new RestRequest("v1/Categories/6327/Details.json", Method.GET);
            rq = new RestRequest(read.jr("../Testing/Data/TestData.json", "endpoint"), Method.GET); 
            rq.AddHeader("Content-Type", content);
            rq.AddParameter(new Parameter("X-Correlation-ID", corr, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("X-Request-ID", reqid, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("Postman-Token", token, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("Content-Encoding", encoding, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("Connection", conn, ParameterType.GetOrPost));
            return rq;
        }

        public static IRestResponse GetResponse(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var filepath = Path.GetFileName("output.txt");
            StreamWriter writer = new StreamWriter(filepath);
            var response = rc.Execute(rq);
            writer.Write(response.Content.ToString());
            writer.Close();
            return response;
        }
        
    }
}
