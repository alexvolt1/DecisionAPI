using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecisionAPI.Data;
using DecisionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public QuotesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            //return new string[] { "value1", "value2" };
            return _applicationDbContext.Quotes;
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public Quote Get(int id)
        {
            var quote = _applicationDbContext.Quotes.Find(id);

            return quote;
        }

        // POST: api/Quotes
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _applicationDbContext.Quotes.Add(quote);
            _applicationDbContext.SaveChanges();
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
           var entity = _applicationDbContext.Quotes.Find(id);
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;

            _applicationDbContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           var quote = _applicationDbContext.Quotes.Find(id);
            _applicationDbContext.Remove(quote);

            _applicationDbContext.SaveChanges();
        }
    }
}
