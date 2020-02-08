using System;
using Xunit;
using RA;

namespace Bitly
{
    public class PostTest
    {
        [Fact]
        public void normalTest()
        {

            new RestAssured()
              .Given()
                .Name("normal test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
                .Body("\"http://www.google.com\"")
              .When()
                .Post("http://localhost:5000/urls")
              .Then()
                .TestStatus("test status", r => r == 200)
                .TestBody("test body", b => ((string)b.shortUrl).Length == 8)
                .Assert("test body")
                .Assert("test status");
        }

        [Fact]
        public void persianUrlTest()
        {

            new RestAssured()
              .Given()
                .Name("persian url test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
                .Body("\"http://www.google.com/چوم\"")
              .When()
                .Post("http://localhost:5000/urls")
              .Then()
                .TestStatus("test status", r => r == 200)
                .Assert("test status");
        }


        [Fact]
        public void sharpSignTest()
        {

            new RestAssured()
              .Given()
                .Name("sharp sign test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
                .Body("\"http://www.goo#gle.com/\"")
              .When()
                .Post("http://localhost:5000/urls")
              .Then()
                .TestStatus("test status", r => r == 200)
                .Assert("test status");
        }


        [Fact]
        public void withoutHtppTest()
        {

            new RestAssured()
              .Given()
                .Name("without http test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
                .Body("\"www.com\"")
              .When()
                .Post("http://localhost:5000/urls")
              .Then()
                .TestStatus("test status", r => r == 400)
                .Assert("test status");
        }


        [Fact]
        public void numberUrlTest()
        {

            new RestAssured()
              .Given()
                .Name("number url test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
                .Body("\"985479\"")
              .When()
                .Post("http://localhost:5000/urls")
              .Then()
                .TestStatus("test status", r => r == 400)
                .Assert("test status");
        }










    }
}



