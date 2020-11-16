using System.Net;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json.Linq;
using Testing.Data;
using System;

namespace Testing.Stepdefinition
{
    [Binding]
    public class Stepdefinition
    {
        JSON read = new JSON();

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
            var filepath = Path.GetFileName("output.txt");
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader(filepath);
            JObject result = JObject.Parse(reader.ReadToEnd());
            //string value = result["Name"].Value<string>();
            //Assert.AreEqual("Carbon credits", value, "The value is not as expected");
            string value = result[read.jr("../Testing/Data/TestData.json", "AC1")].Value<string>();
            Assert.AreEqual(read.jr("../Testing/Data/TestData.json", "V1"), value, "The value is not as expected");
            reader.Dispose();
        }

        [Then(@"I am able to see the canrelist status with headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenIAmAbleToSeeTheCanrelistStatusWithHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var filepath = Path.GetFileName("output.txt");
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader(filepath);
            JObject result = JObject.Parse(reader.ReadToEnd());
            //string value = result["CanRelist"].Value<string>();
            //Assert.AreEqual("True", value, "The value is not as expected");
            string value = result[read.jr("../Testing/Data/TestData.json", "AC2")].Value<string>();
            Assert.AreEqual(read.jr("../Testing/Data/TestData.json", "V2"), value, "The value is not as expected");
            reader.Dispose();
        }

        [Then(@"I am able to see the promotions name with headers (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenIAmAbleToSeeThePromotionsNameWithHeadersAnd(string content, string corr, string reqid, string token, string encoding, string conn)
        {
            var filepath = Path.GetFileName("output.txt");
            var response = RestAPIHelper.GetResponse(content, corr, reqid, token, encoding, conn);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
            Assert.That(response.ContentType, Is.EqualTo(content));
            StreamReader reader = new StreamReader(filepath);
            JObject result = JObject.Parse(reader.ReadToEnd());
            //string value = result["Promotions"][1]["Name"].Value<string>();
            //Assert.AreEqual("Gallery", value, "The value is not as expected");
            //string desc = result["Promotions"][1]["Description"].Value<string>();
            // Assert.IsTrue(desc.Contains("2x larger image"), "The values does not match as expected", desc);
            //Assert.IsTrue(desc.Contains("Good position in category"), "The values does not match as expected", desc);
            string value = result[read.jr("../Testing/Data/TestData.json", "AC3")][1][read.jr("../Testing/Data/TestData.json", "AC1")].Value<string>();
            Assert.AreEqual(read.jr("../Testing/Data/TestData.json", "gallery"), value, "The value is not as expected");
            string desc = result[read.jr("../Testing/Data/TestData.json", "AC3")][1][read.jr("../Testing/Data/TestData.json", "V3")].Value<string>();
            Assert.IsTrue(desc.Equals(read.jr("../Testing/Data/TestData.json", "V4")), "The values does not match as expected", desc);
            reader.Dispose();
        }

    }
}
