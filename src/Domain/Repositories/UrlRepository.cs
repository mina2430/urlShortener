using bitly.Domain.Models;
using System.Threading.Tasks;


namespace bitly.Domain.Repositories
{

    public class UrlRepository
    {
        protected readonly AppDbContext context;
        public UrlRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Url> find(string shortUrl)
        {
            return await context.urls.FindAsync(shortUrl);
        }

        public async Task add(Url url)
        {
            await context.urls.AddAsync(url);
        }


    }

}