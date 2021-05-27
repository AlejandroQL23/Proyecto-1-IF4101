using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace LabMVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsCommentController : ControllerBase
    {

        [Route("[action]")]
        [HttpPost]
        public JsonResult Post([FromBody] NewsComment newscomment)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/newscomments");
                    var postTask = client.PostAsJsonAsync("newscomments", newscomment);
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
        public IEnumerable<NewsComment> Get()
        {
            IEnumerable<NewsComment> newsComment = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/newscomments/");
                    var responseTask = client.GetAsync("GetNewsComments");
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<NewsComment>>();
                        readTask.Wait();
                        newsComment = readTask.Result;
                    }
                    else
                    {
                        newsComment = Enumerable.Empty<NewsComment>();
                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact an administrator");
            }
            return newsComment;
        }

        public NewsComment GetById(int id)
        {
            NewsComment newsComment = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44315/api/newscomment/" + id);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NewsComment>();
                    readTask.Wait();
                    newsComment = readTask.Result;
                }
            }
            return newsComment;
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] NewsComment newscomment)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/newscomment/" + id);
                    var putTask = client.PutAsJsonAsync("newscomment", newscomment);
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
                client.BaseAddress = new Uri("http://localhost:44315/api/");
                var deleteTask = client.DeleteAsync("newscomment/" + id.ToString());
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
