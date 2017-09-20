using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;

namespace VideoMenuBLL.BusiessObjects
{
    public class RentalBO
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int VideoId { get; set; }
        public VideoBO Video { get; set; }
    }
}
