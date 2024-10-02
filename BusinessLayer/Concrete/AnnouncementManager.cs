using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void Add(Announcement entity)
        {
            _announcementDal.Insert(entity);
        }

        public void Delete(Announcement entity)
        {
            _announcementDal.Delete(entity);
        } 

        public Announcement GetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.GetList();
        }

        public void Update(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}
