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
        [ResponseCache(Duration = 60, Location =ResponseCacheLocation.Any)]
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                  quotes =  _applicationDbContext.Quotes.OrderByDescending(q => q.CreatedAt);
                    break;
                case "asc":
                    quotes = _applicationDbContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                default:
                    quotes = _applicationDbContext.Quotes;
                    break;

            }

            //return new string[] { "value1", "value2" };
            //return _applicationDbContext.Quotes;
            return Ok(quotes);
        }

        [HttpGet("[action]")]
        //[Route("[action]")]
        public IActionResult PagingQuote(int? pageNumber, int? pageSize)
        {
            var quotes = _applicationDbContext.Quotes;
          var currentPageNumber =   pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;

            return Ok(quotes.Skip((currentPageNumber - 1)* currentPageSize).Take(currentPageSize));

        }

        [HttpGet("[action]")]
        public IActionResult SearchQuote(string type)
        {

            var quotes = _applicationDbContext.Quotes.Where(q=> q.Type.StartsWith(type));
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote = _applicationDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record found against this Id...");
            }
            else
            {
                return Ok(quote);
            }
        }
        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _applicationDbContext.Quotes.Add(quote);
            _applicationDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
           var entity = _applicationDbContext.Quotes.Find(id);
            if(entity==null)
            {
                return NotFound("No record found against this Id...");
            }
            else
            {
                entity.Title = quote.Title;
                entity.Author = quote.Author;
                entity.Description = quote.Description;
                entity.Type = quote.Type;
                entity.CreatedAt = quote.CreatedAt;

                _applicationDbContext.SaveChanges();
                return Ok("Record Updated Successfully.....");
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var quote = _applicationDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record found against this Id...");
            }
            else
            {
                _applicationDbContext.Remove(quote);

                _applicationDbContext.SaveChanges();

                return Ok("Quote deleted....");
            }
        }
    }
}
