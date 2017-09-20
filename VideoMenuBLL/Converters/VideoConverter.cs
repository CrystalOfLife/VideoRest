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
            if (video == null) { return null; }
            return new Video()
            {
                Id = video.Id,
                Name = video.Name,
                PricePrDay = video.PricePrDay,
                GenreId = video.GenreId
            };
        }

        internal VideoBO Convert(Video video)
        {
            if (video == null) { return null; }
            return new VideoBO()
            {
                Id = video.Id,
                Name = video.Name,
                PricePrDay = video.PricePrDay,
                Genre = new GenreConverter().Convert(video.Genre),
                GenreId = video.GenreId
            };
        }
    }
}
