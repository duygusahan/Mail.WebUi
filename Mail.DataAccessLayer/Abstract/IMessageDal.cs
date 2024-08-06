using Mail.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetListReciverMessage(string m);
        
        List<Message> GetListSendMessage(string m);

        List<Message> GetLast3MessagesByAppUser(string m);

        List<Message> GetTrashBox(string m);    
    }
}
