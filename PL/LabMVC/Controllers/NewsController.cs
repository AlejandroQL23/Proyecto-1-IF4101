using LabMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabMVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        [HttpPost]
        public JsonResult Post([FromBody] News news)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/news");
                    var postTask = client.PostAsJsonAsync("news", news);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return new JsonResult(result);
                    }
                }
            }
            catch (DbUpdateException exception)
            {
                return new JsonResult(exception);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<News> GetNewsForTable()
        {
            IEnumerable<News> news = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/news/");
                    var responseTask = client.GetAsync("GetNews");
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<News>>();
                        readTask.Wait();
                        news = readTask.Result;
                    }
                    else
                    {
                        news = Enumerable.Empty<News>();
                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact an administrator");
            }
            return news;
        }

        [Route("[action]")]
        [HttpGet("{id}", Name = "GetById")]
        public News GetById(int id)
        {
            News news = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/news/" + id);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<News>();
                    readTask.Wait();
                    news = readTask.Result;
                }
            }
            return news;
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] News news)
        {
            try
            {
                news.Id = id;
                var oldNew = GetById(id);
                news.CreationDate = oldNew.CreationDate;
                news.ExtraFile = oldNew.ExtraFile;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/news/" + id);
                    var putTask = client.PutAsJsonAsync("", news);
                    putTask.Wait();
                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return new JsonResult(result);
                    }
                }
            }
            catch (DbUpdateConcurrencyException exception)
            {
                return new JsonResult(exception);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/" + id);
                var deleteTask = client.DeleteAsync("news/" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);
                }
            }

        }
    }
}
