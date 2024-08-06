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
    public class EfDraftDal : GenericRepository<Draft>, IDraftDal
    {
        public EfDraftDal(MailContext mailContext) : base(mailContext)
        {
        }
    }
}
