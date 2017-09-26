using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Entities;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL;
using VideoMenuBLL.Converters;

namespace VideoMenuBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();

        DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(conv.Convert(video));
                uow.Complete();
                return conv.Convert(newVideo);
            }
        }

        public void CreateAll(List<VideoBO> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    var newVideo = uow.VideoRepository.Create(conv.Convert(video));
                }
                uow.Complete();
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVideo);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoEntity = uow.VideoRepository.Get(Id);
                return conv.Convert(videoEntity);
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public VideoBO Update(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoEntity = uow.VideoRepository.Get(video.Id);
                if (videoEntity == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                var videoUpdated = conv.Convert(video);
                videoEntity.Name = videoUpdated.Name;
                videoEntity.PricePrDay = videoUpdated.PricePrDay;
                videoEntity.Genres = videoUpdated.Genres;
                uow.Complete();
                return conv.Convert(videoEntity);
            }
        }
    }
}
