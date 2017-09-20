using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IGenreRepository GenreRepository { get; }
        IRentalRepository RentalRepository { get; }

        int Complete();
    }
}
