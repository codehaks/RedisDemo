using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

using StackExchange.Redis;

namespace MyApp
{
    public class IndexModel : PageModel
    {
        IDistributedCache _cache;
        public IndexModel(IDistributedCache cache)
        {
            _cache = cache;
        }
        public void OnGet()
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();           
     
            db.StringSet(new RedisKey("time"), new RedisValue(DateTime.Now.ToShortTimeString()));
            
        }
    }
}