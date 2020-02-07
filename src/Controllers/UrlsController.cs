using Microsoft.AspNetCore.Mvc;
using bitly.Domain.Services;
using bitly.Domain.Models;
using System.Text;
using System;


namespace bitly.Controllers
{
    [ApiController]
    [Route("urls")]
    public class UrlsController : Controller {

        //private readonly UrlService urlService;
        //delete
        protected readonly AppDbContext context ;
        public UrlsController ( AppDbContext context)
        {
            // this.urlService = urlService;  
            this.context = context;

        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] string longUrl){

            

            while(true){

                StringBuilder builder = new StringBuilder();  
                Random random = new Random();   
                
                char ch;  
                for (int i = 0; i < 8; i++)  
                {  
                    if(random.NextDouble()<0.5)
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))); 
                    else {
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                    }
                    builder.Append(ch);  
                }
                Console.WriteLine(builder.ToString());  

                if (context.urls.Find(builder.ToString()) == null){
                    Url newUrl = new Url(longUrl,builder.ToString());
                    context.urls.Add(newUrl);
                    context.SaveChanges();
                    return "short url: http://localhost:5000/"+newUrl.ShortUrl+"\n";

                } else {
                    builder = new StringBuilder();
                }
            }           

        }
    }

}