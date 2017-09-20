using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repository
{
    class RentalRepository : IRentalRepository
    {
        VideoMenuContext _context;
        public RentalRepository(VideoMenuContext context)
        {
            _context = context;
        }

        public Rental Create(Rental rental)
        {
            _context.Rentals.Add(rental);
            return rental;
        }

        public Rental Delete(int Id)
        {
            var rental = Get(Id);
            _context.Rentals.Remove(rental);
            return rental;
        }

        public Rental Get(int Id)
        {
            return _context.Rentals.FirstOrDefault(r => r.Id == Id);
        }

        public List<Rental> GetAll()
        {
            return _context.Rentals.ToList();
        }
    }
}
