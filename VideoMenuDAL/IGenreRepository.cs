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
        IEnumerable<Genre> GetAllById(List<int> ids);
        Genre Get(int Id);

        Genre Delete(int Id);
    }
}
