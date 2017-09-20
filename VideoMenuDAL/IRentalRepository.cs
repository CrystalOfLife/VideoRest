using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
    public interface IRentalRepository
    {
        Rental Create(Rental rental);

        List<Rental> GetAll();
        Rental Get(int Id);

        Rental Delete(int Id);
    }
}
