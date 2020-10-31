using System.Net;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json.Linq;
using Testing.Data;

namespace Testing.Stepdefinition
{
    [Binding]
    public class Stepdefinition
    {

        [Given(@"I have access to the URL for categories")]
        public void GivenIHaveAccessToTheURLForCategories()
        {
            RestAPIHelper.Url();
        }

        [When(@"I pass headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIPassHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            RestAPIHelper.parameters(content, corr, reqid, token, encoding, conn);
        }

        [Then(@"I am able to see the category name with headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenIAmAbleToSeeTheCategoryNameWithHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.kulkarni\\My Folder\\Practice\\APITesting\\Testing\\Output\\output.txt");
            JObject result = JObject.Parse(reader.ReadToEnd());
            string value = result["Name"].Value<string>();
            Assert.AreEqual("Carbon credits", value, "The value is not as expected");
            reader.Dispose();
        }

        [Then(@"I am able to see the canrelist status with headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenIAmAbleToSeeTheCanrelistStatusWithHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.kulkarni\\My Folder\\Practice\\APITesting\\Testing\\Output\\output.txt");
            JObject result = JObject.Parse(reader.ReadToEnd());
            string value = result["CanRelist"].Value<string>();
            Assert.AreEqual("True", value, "The value is not as expected");
            reader.Dispose();
        }

        [Then(@"I am able to see the promotions name with headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenIAmAbleToSeeThePromotionsNameWithHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.kulkarni\\My Folder\\Practice\\APITesting\\Testing\\Output\\output.txt");
            JObject result = JObject.Parse(reader.ReadToEnd());
            string value = result["Promotions"][1]["Name"].Value<string>();
            Assert.AreEqual("Gallery", value, "The value is not as expected");
            string desc = result["Promotions"][1]["Description"].Value<string>();
            Assert.IsTrue(desc.Contains("2x larger image"), "The values does not match as expected", desc);
            reader.Dispose();
        }

    }
}
