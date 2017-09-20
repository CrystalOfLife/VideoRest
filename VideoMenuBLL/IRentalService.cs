using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusiessObjects;

namespace VideoMenuBLL
{
    public interface IRentalService
    {
        RentalBO Create(RentalBO rental);

        List<RentalBO> GetAll();
        RentalBO Get(int Id);

        RentalBO Update(RentalBO rental);

        RentalBO Delete(int Id);
    }
}
