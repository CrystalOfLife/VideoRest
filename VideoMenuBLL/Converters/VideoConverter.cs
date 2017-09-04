using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO video)
        {
            return new Video()
            {
                Id = video.Id,
                Name = video.Name
            };
        }

        internal VideoBO Convert(Video video)
        {
            return new VideoBO()
            {
                Id = video.Id,
                Name = video.Name
            };
        }
    }
}
