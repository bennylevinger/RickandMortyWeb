using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickandMortyWeb.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace RickandMortyWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/RandMFriends")]
    public class RandMFriendsController : Controller
    {
        public List<RandMFriends> friends = new List<RandMFriends>();

        // GET: api/RandMFriends
        [HttpGet]
        public List<RandMFriends> Get()
        {

            return GetFriendFromWeb();
        }

        // GET: api/RandMFriends/5
        [HttpGet("{index}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RandMFriends
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RandMFriends/5
        [HttpPut("{index}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{index}")]
        public void Delete(int id)
        {
        }

        private List<RandMFriends> GetFriendFromWeb()
        {

            Uri uri = new Uri("https://rickandmortyapi.com/api/character/?status=alive&species=Human");

            //friends.Add(new RandMFriends("1", "benny", "israel", "http://my.png"));
            // friends.Add(new RandMFriends("2", "guy", "england", "http://my.png"));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            //request.Timeout = 360000;
            request.Timeout = 1800000;
            //like this:

            //   request.Headers["Authorization"] = "Basic " + authInfo;
            Stream resStream = null;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                resStream = response.GetResponseStream();
            }
            catch (Exception ex)
            {
                string ErrorDesc = ex.Message.ToString();


            }


            StreamReader reader = new StreamReader(resStream);
            string text = reader.ReadToEnd();
            var j = JsonConvert.DeserializeObject<dynamic>(text);
            int index = 1;
            foreach (var val in j.results)
            {
                if (val.origin.name == "Earth (C-137)")
                {

                    friends.Add(new RandMFriends(index, val.name.ToString(), val.origin.name.ToString(), val.image.ToString()));
                    index++;
                }
            }
            return friends;
        }





    }

}
