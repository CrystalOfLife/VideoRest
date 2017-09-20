using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<Video> Videoes { get; set; }
    }
}
