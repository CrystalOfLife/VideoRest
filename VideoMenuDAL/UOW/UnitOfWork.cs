﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repository;

namespace VideoMenuDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        public IGenreRepository GenreRepository { get; internal set; }
        private VideoMenuContext context;

        public UnitOfWork()
        {
            context = new VideoMenuContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
            GenreRepository = new GenreRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}