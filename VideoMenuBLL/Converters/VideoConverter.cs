using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusiessObjects;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    class VideoConverter
    {
        private GenreConverter gConv;

        public VideoConverter()
        {
            gConv = new GenreConverter();
        }

        internal Video Convert(VideoBO video)
        {
            if (video == null) { return null; }
            return new Video()
            {
                Id = video.Id,
                Genres = video.Genres?.Select(g => new VideoGenre(){
                    GenreId = g.Id,
                    VideoId = video.Id
                }).ToList(),
                Name = video.Name,
                PricePrDay = video.PricePrDay
            };
        }

        internal VideoBO Convert(Video video)
        {
            if (video == null) { return null; }
            return new VideoBO()
            {
                Id = video.Id,
                Genres = video.Genres?.Select(g => new GenreBO() {
                    Id = g.VideoId,
                    Name = g.Genre?.Name
                }).ToList(),
                Name = video.Name,
                PricePrDay = video.PricePrDay
            };
        }
    }
}
