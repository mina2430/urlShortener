using Microsoft.AspNetCore.Mvc;
using bitly.Domain.Services;
using bitly.Domain.Models;
using System.Text;
using System;


namespace bitly.Controllers
{


    class ResponseExample{
        public string response { get; set; }
        public string shortUrl { get; set; }
        
        // public AppDbContext context { get; set; }


        public ResponseExample(string shortUrl,AppDbContext context){
            this.response = "short url: http://localhost:5000/"+shortUrl;
            this.shortUrl = shortUrl;
            Console.WriteLine(shortUrl.Length);
            // this.context = context;

        }


        public override string ToString(){
            return response;
        }



       

        
    }



    [ApiController]
    [Route("/urls")]
    public class UrlsController : Controller
    {

        //private readonly UrlService urlService;
        //delete
        protected readonly AppDbContext context;
        public UrlsController(AppDbContext context)
        {
            // this.urlService = urlService;  
            this.context = context;

        }


        



        [HttpPost]
        public ActionResult<string> Post([FromBody] string longUrl)
        {
            Uri uriResult;
            // if (Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
            if(!(Uri.TryCreate(longUrl, UriKind.Absolute, out uriResult) 
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
             {
                 return BadRequest();
             }


            while (true)
            {

                StringBuilder builder = new StringBuilder();
                Random random = new Random();

                char ch;
                for (int i = 0; i < 8; i++)
                {
                    if (random.NextDouble() < 0.5)
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    else
                    {
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                    }
                    builder.Append(ch);
                }
                Console.WriteLine(builder.ToString());

                if (context.urls.Find(builder.ToString()) == null)
                {
                    Url newUrl = new Url(longUrl, builder.ToString());
                    context.urls.Add(newUrl);
                    context.SaveChanges();
                    ResponseExample response = new ResponseExample(newUrl.ShortUrl,context);
                    //return "short url: http://localhost:5000/" + newUrl.ShortUrl + "\n";
                    return Ok(response);
                    

                }
                else
                {
                    builder = new StringBuilder();
                }
            }

        }
    }

}