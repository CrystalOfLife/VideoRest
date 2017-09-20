﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repository
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        VideoMenuContext _context;

        public VideoRepositoryEFMemory(VideoMenuContext context)
        {
            _context = context;
        }

        public Video Create(Video video)
        {
            _context.Videoes.Add(video);
            return video;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            _context.Videoes.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return _context.Videoes.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videoes.ToList();
        }
    }
}
