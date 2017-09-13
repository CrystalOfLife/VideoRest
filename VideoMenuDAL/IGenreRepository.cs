using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
    public interface IGenreRepository
    {
        Genre Create(Genre genre);

        List<Genre> GetAll();
        Genre Get(int Id);

        Genre Delete(int Id);
    }
}
