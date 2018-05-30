using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Data;
using Spin.Models;
using Spin.Services.Interfaces;

namespace Spin.Services
{
    public class EFVideoService : IVideo
    {
        protected readonly SpinContext _context;

        public EFVideoService(SpinContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Video> GetAllVideos()
        {
            var videos = _context.Videos.ToList();

            return videos;
        }

        public Video Add(Video model)
        {
            _context.Videos.Add(model);
            _context.SaveChanges();

            throw new NotImplementedException();
        }

        public void Delete(int id, Video model)
        {
            throw new NotImplementedException();
        }

        public Video Edit(Video model)
        {
            throw new NotImplementedException();
        }

        public Video Get(int id)
        {
            var video = _context.Videos.FirstOrDefault(a => a.Id == id);

            return video;
        }

    }
}