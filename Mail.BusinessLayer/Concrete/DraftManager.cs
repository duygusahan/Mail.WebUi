using Mail.BusinessLayer.Abstract;
using Mail.DataAccessLayer.Abstract;
using Mail.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        private readonly IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void TDelete(int id)
        {
            _draftDal.Delete(id);
        }

        public Draft TGetById(int id)
        {
            return _draftDal.GetById(id);   
        }

        public List<Draft> TGetListAll()
        {
           return _draftDal.GetListAll();
        }

        public void TInsert(Draft entity)
        {
            _draftDal.Insert(entity);
        }

        public void TUpdate(Draft entity)
        {
           _draftDal.Update(entity);
        }
    }
}
