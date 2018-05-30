using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.Services.Interfaces
{
    public interface IVideo
    {
        IEnumerable<Video> GetAllVideos();
        Video Get(int id);
        Video Add(Video model);
        Video Edit(Video model);
        void Delete(int id, Video model);
    }
}