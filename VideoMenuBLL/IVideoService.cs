using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;

namespace VideoMenuBLL
{
    public interface IVideoService
    {
        VideoBO Create(VideoBO video);

        List<VideoBO> GetAll();
        VideoBO Get(int Id);

        VideoBO Update(VideoBO video);

        VideoBO Delete(int Id);
    }
}
