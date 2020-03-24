using RestSharp;
using System.IO;

namespace Testing.Stepdefinition
{
    public static class RestAPIHelper
    {
        public static RestClient rc;
        public static RestRequest rq;
        public static string url = "https://api.tmsandbox.co.nz/";

        public static RestClient Url()
        {

            var url = "https://api.tmsandbox.co.nz/";
            return rc = new RestClient(url);
        }

        public static RestRequest parameters(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            
            rc = new RestClient(url);
            rq = new RestRequest("v1/Categories/6327/Details.json", Method.GET);
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
            StreamWriter writer = new StreamWriter("C:\\Users\\abhishek.k\\source\\repos\\Testing\\Testing\\Output\\output.txt");
            var response = rc.Execute(rq);
            writer.Write(response.Content.ToString());
            writer.Close();
            return response;
        }
        
    }
}
