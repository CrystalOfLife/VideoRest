using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusiessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;

namespace VideoMenuBLL.Services
{
    class RentalService : IRentalService
    {
        RentalConverter conv = new RentalConverter();

        private DALFacade _facade;

        public RentalService(DALFacade facade)
        {
            _facade = facade;
        }

        public RentalBO Create(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Create(conv.Convert(rental));
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(Id);
                var videoEntity = uow.VideoRepository.Get(Id);
                rentalEntity.Video = uow.VideoRepository.Get(rentalEntity.VideoId);
                return conv.Convert(rentalEntity);
            }
        }

        public List<RentalBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RentalRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public RentalBO Update(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(rental.Id);
                if (rentalEntity == null)
                {
                    throw new InvalidOperationException("rental not found");
                }
                rentalEntity.From = rental.From;
                rentalEntity.To = rental.To;
                rentalEntity.VideoId = rental.VideoId;
                uow.Complete();
                rentalEntity.Video = uow.VideoRepository.Get(rentalEntity.VideoId);
                return conv.Convert(rentalEntity);
            }
        }
    }
}
