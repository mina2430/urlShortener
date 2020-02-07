using Microsoft.AspNetCore.Mvc;
using bitly.Domain.Services;
using bitly.Domain.Models;
using System.Text;
using System;

namespace bitly.Controllers{
    [Route("/Redirect/{shortUrl}")]
    [ApiController]
    public class UrlsControllers :Controller {
        
        private readonly AppDbContext context;
        
        public UrlsControllers (AppDbContext context)
        {
            this.context = context;  
            
        }

        [HttpGet]
        public ActionResult<string> Get(string shortUrl){
            
            try{
            Url url = context.urls.Find(shortUrl);
            return Redirect("http://"+url.LongUrl);
            } catch (Exception){
                return NotFound();
            }
            
            
        }
    }
}