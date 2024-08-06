using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mail.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class 
    {
        void Insert(T entity);  
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetListAll();
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
    
}
