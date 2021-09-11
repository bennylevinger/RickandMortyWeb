using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickandMortyWeb.Models
{
    public class RandMFriends
    {
        public RandMFriends()
        {
        }

        public RandMFriends(int index, string name, string location, string image)
        {
            this.index = index;
            this.name = name;
            this.location = location;
            this.image = image;
        }

        public int index { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string image { get; set; }



    }
}
