using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusiessObjects;

namespace VideoMenuBLL
{
    public interface IGenreService
    {
        GenreBO Create(GenreBO video);

        List<GenreBO> GetAll();
        GenreBO Get(int Id);

        GenreBO Update(GenreBO video);

        GenreBO Delete(int Id);
    }
}
