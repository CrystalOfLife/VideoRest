﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusiessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;

namespace VideoMenuBLL.Services
{
    class GenreService : IGenreService
    {
        GenreConverter conv = new GenreConverter();

        private DALFacade _facade;

        public GenreService(DALFacade facade)
        {
            _facade = facade;
        }

        public GenreBO Create(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Create(conv.Convert(genre));
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(Id);
                return conv.Convert(genreEntity);
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(genre.Id);
                if (genreEntity == null)
                {
                    throw new InvalidOperationException("genre not found");
                }
                genreEntity.Name = genre.Name;
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }
    }
}
