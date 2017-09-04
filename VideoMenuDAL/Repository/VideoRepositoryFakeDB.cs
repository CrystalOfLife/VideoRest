using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repository
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static List<Video> videos = new List<Video>();
        private static int Id = 1;

        public Video Create(Video video)
        {
            Video newVideo;
            videos.Add(newVideo = new Video()
            {
                Name = video.Name,
                Id = Id++
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(videos);
        }
    }
}
