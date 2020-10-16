using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static TpBooks.Service.Contextdto;

namespace TpBooks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static HttpClient client = new HttpClient();
        private static readonly string API_URL = "https://www.googleapis.com/books/v1/volumes";

        [HttpGet]
        public ActionResult<Bookdto> Get()
        {
            return Ok("Hello World");
        }

        [HttpGet("query")]
        public async Task<ActionResult<List<Bookdto>>> Query(string title, string author)
        {
            List<Bookdto> book = new List<Bookdto>();
            var response = await client.GetAsync(BuildUri(title, author));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            JObject jsonobj = JObject.Parse(jsonString);
            List<JToken> results = jsonobj["items"].Children().ToList();

            foreach (var result in results)
            {
                var newbook = result["volumeInfo"].ToObject<Bookdto>();
                book.Add(newbook);
                using (var db = new BloggingContext())
                {
                    // Create
                    Console.WriteLine("Inserting a new book");
                    db.Add(newbook);
                    db.SaveChanges();
                }
            }
            return Ok(book);
        }

            private string BuildUri(string title, string author)
            {
                UriBuilder builder = new UriBuilder(API_URL);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["q"] = title;
                if (!string.IsNullOrEmpty(author))
                {
                    query["inauthor"] = author;
                }
                builder.Query = query.ToString().Replace("inauthor=", "inauthor:");
                return builder.ToString();
            }
        }
    }
