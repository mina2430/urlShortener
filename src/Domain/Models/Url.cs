using System;

namespace bitly.Domain.Models
{
    public class Url
    {

        public Url(string LongUrl,string ShortUrl){
            this.ShortUrl = ShortUrl;
            this.LongUrl = LongUrl;
        }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }

    }
}
