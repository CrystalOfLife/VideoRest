using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoMenuBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public String Name { get; set; }
    }
}
