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
        GenreConverter gConv = new GenreConverter();
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
                var vid = conv.Convert(uow.VideoRepository.Get(Id));

                /*vid.Genres = vid.GenreIds?
                    .Select(id => gConv.Convert(uow.GenreRepository.Get(id)))
                    .ToList();*/

                vid.Genres = uow.GenreRepository.GetAllById(vid.GenreIds)
                    .Select(g => gConv.Convert(g))
                    .ToList();

                return vid;
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

                videoEntity.Genres.RemoveAll(
                    ca => !videoUpdated.Genres.Exists(
                        g => g.GenreId == ca.GenreId &&
                        g.VideoId == ca.VideoId));

                videoUpdated.Genres.RemoveAll(
                    ca => videoEntity.Genres.Exists(
                        g => g.GenreId == ca.GenreId &&
                        g.VideoId == ca.VideoId));

                videoEntity.Genres.AddRange(
                    videoUpdated.Genres);

                uow.Complete();
                return conv.Convert(videoEntity);
            }
        }
    }
}
