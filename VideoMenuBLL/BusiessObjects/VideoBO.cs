using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VideoMenuBLL.BusiessObjects;

namespace VideoMenuBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }
        public int PricePrDay { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public String Name { get; set; }
        
        public List<int> GenreIds { get; set; }
        public List<GenreBO> Genres { get; set; }
    }
}
