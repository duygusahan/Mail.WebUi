using Mail.DataAccessLayer.Abstract;
using Mail.DataAccessLayer.Context;
using Mail.DataAccessLayer.Repositories;
using Mail.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        MailContext _context= new MailContext();
        public EfMessageDal(MailContext mailContext) : base(mailContext)
        {
        }

        public List<Message> GetLast3MessagesByAppUser(string m)
        {
            var value = _context.Messages.Where(x => x.ReceiverMail == m && x.Status == true && x.IsDraft ).OrderByDescending(x=>x.Date).Take(3).ToList();
            return value;   
        }

        public List<Message> GetListReciverMessage(string m)
        {
           var value =_context.Messages.Where(x=>x.ReceiverMail==m && x.Status==true && x.IsDraft==false).ToList();
            return value;   
        }

        public List<Message> GetListSendMessage(string m)
        {
            var value= _context.Messages.Where(x => x.SenderMail == m && x.Status == true && x.IsDraft == false).ToList();
            return value;   
        }

       

        public List<Message> GetTrashBox(string m)
        {
            var value = _context.Messages.Where(x => x.Status == false && (x.SenderMail == m || x.ReceiverMail == m)).ToList();
            return value ;
        }
    }
}
