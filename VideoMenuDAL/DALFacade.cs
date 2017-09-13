using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Repository;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
