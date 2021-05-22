using LabMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabMVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsCommentController : ControllerBase
    {
        // GET: api/<NewsCommentController>
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<NewsComment> Get()
        {
            IEnumerable<NewsComment> newscomment = null;

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
                        //lee los estudiantes provenientes de la API
                        newscomment = readTask.Result;
                    }
                    else
                    {
                        newscomment = Enumerable.Empty<NewsComment>();
                    }
                }
            }
            catch
            {

                ModelState.AddModelError(string.Empty, "Server error. Please contact an administrator");

            }

            return newscomment;
        }


        //-------------------------------------------------------------------------
        // GET api/<NewsCommentController>/5
        public NewsComment GetById(int id)
        {
            NewsComment newscomment = null;

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
                    //lee el estudiante provenientes de la API
                    newscomment = readTask.Result;


                }
            }

            return newscomment;

        }


        //-------------------------------------------------------------------------



        // POST: api/StudentAPI
        [HttpPost]
        public JsonResult Post([FromBody] NewsComment newscomment)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44315/api/newscomments");
                    var postTask = client.PostAsJsonAsync("PostNewsComment", newscomment);
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



        //-------------------------------------------------------------------------



        // PUT: api/StudentAPI/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] NewsComment newscomment)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:44315/api/newscomment/" + id);

                    //HTTP POST
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


        //-------------------------------------------------------------------------




        // DELETE api/<NewsCommentController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44315/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("newscomment/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return new JsonResult(result);
                }
                else
                {
                    //camino del error
                    return new JsonResult(result);

                }
            }

        }



        //-------------------------------------------------------------------------



    }
}
