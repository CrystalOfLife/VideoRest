using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int PricePrDay { get; set; }

        public List<VideoGenre> Genres { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
