using System;
using Xunit;
using RA;

namespace bitly
{
    public class GetTest
    {


        [Fact]
        public void containNumber_shortUrl()
        {

            new RestAssured()
              .Given()
                .Name("short url with number test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
              .When()
                .Get("http://localhost:5000/Redirect/lskd34jj")
              .Then()
                .TestStatus("test status", r => r == 400)
                .Assert("test status");

        }


        [Fact]
        public void long_shortUrl()
        {

            new RestAssured()
              .Given()
                .Name("short url more than 8 characters test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
              .When()
                .Get("http://localhost:5000/Redirect/lskdaaaajj")
              .Then()
                .TestStatus("test status", r => r == 400)
                .Assert("test status");

        }


        [Fact]
        public void short_shortUrl()
        {

            new RestAssured()
              .Given()
                .Name("short url less than 8 characters test")
                .Header("Content-Type", "application/json")
                .Header("Accept-Ending", "utf-8")
              .When()
                .Get("http://localhost:5000/Redirect/lskd")
              .Then()
                .TestStatus("test status", r => r == 400)
                .Assert("test status");

        }







    }
}



