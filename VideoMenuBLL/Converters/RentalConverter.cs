using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusiessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    class RentalConverter
    {
        internal Rental Convert(RentalBO rental)
        {
            if (rental == null) { return null; }
            return new Rental()
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To,
                VideoId = rental.VideoId
            };
        }

        internal RentalBO Convert(Rental rental)
        {
            if (rental == null) { return null; }
            return new RentalBO()
            {
                Id = rental.Id,
                From = rental.From,
                To = rental.To,
                Video = new VideoConverter().Convert(rental.Video),
                VideoId = rental.VideoId
            };
        }
    }
}
