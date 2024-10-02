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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void Add(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public ContactUs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            return _contactUsDal.GetListContactUsByFalse();
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            return _contactUsDal.GetListContactUsByTrue();
        }

        public void Update(ContactUs entity)
        {
            throw new NotImplementedException();
        }
    }
}
