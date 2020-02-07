using System.Collections.Generic;
using System.Threading.Tasks;
using bitly.Domain.Models;
using bitly.Domain.Repositories;

namespace bitly.Domain.Services
{
    public class UrlService 
    {
        private readonly UrlRepository urlRepository;

        public UrlService(UrlRepository urlRepository)
        {
            this.urlRepository = urlRepository;
        }

        public Task<Url> find (string shortUrl)
        { 
            return  urlRepository.find(shortUrl);
        }

        public Task add(Url url){
            return urlRepository.add(url);
        }

    
    }
}
