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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        

        public void TDelete(int id)
        {
           _messageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetLast3MessagesByAppUser(string m)
        {
            return _messageDal.GetLast3MessagesByAppUser(m);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> TGetListReciverMessage(string m)
        {
            return _messageDal.GetListReciverMessage(m);
        }

        public List<Message> TGetListSendMessage(string m)
        {
            return _messageDal.GetListSendMessage(m);
        }

        public List<Message> TGetTrashBox(string m)
        {
           return _messageDal.GetTrashBox(m);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        //public List<Message> TLast3Message(string m)
        //{
        //    throw new NotImplementedException();
        //}

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
