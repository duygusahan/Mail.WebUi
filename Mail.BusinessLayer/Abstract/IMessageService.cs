
using Mail.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> TGetListReciverMessage(string m);
        //public List<Message> TLast3Message(string m);
        public List<Message> TGetListSendMessage(string m);

        public List<Message> TGetLast3MessagesByAppUser(string m);
        public List<Message> TGetTrashBox(string m);
    }
}
