using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Repository;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get
            {
                return new VideoRepositoryEFMemory(new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMemory();
            }
        }
    }
}
