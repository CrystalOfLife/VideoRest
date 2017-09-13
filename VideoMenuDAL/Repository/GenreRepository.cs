﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repository
{
    class GenreRepository : IGenreRepository
    {
        VideoMenuContext _context;
        public GenreRepository(VideoMenuContext context)
        {
            _context = context;
        }

        public Genre Create(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            _context.Genres.Remove(genre);
            return genre;
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}