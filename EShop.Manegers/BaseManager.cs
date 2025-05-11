using EF_Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EShop.Manegers
{

    public class BaseManager<T> where T : class
    {

        private readonly EShopContext dbcontext;
        public DbSet<T> table;
        public BaseManager(EShopContext _eShopContext)
        {

            //dbcontext = new EShopContext();

            //DI
            dbcontext = _eShopContext;
            table = dbcontext.Set<T>();
        }

        
        public IQueryable<T> Get(
            Expression<Func<T,bool>> filter = null,
            int pageSize = 4 ,
            int pageNumber = 1)
        {
            IQueryable<T> quary = table.AsQueryable();

            if (filter != null)
                quary = quary.Where(filter);

            //Pagination
            if(pageSize < 0)
                pageSize = 4;

            if(pageNumber < 0)
                pageNumber = 1;
            
            int count = quary.Count();

            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }
            
            int ToSkip = (pageNumber - 1) * pageSize;

            quary = quary.Skip(ToSkip).Take(pageSize);

            return quary;
        }
    
        public IQueryable<T> GetList(
            Expression<Func<T, bool>> filter = null)
        {
            if (filter == null) return table.AsQueryable();
            else return table.Where(filter);
        }
        public void Add(T newRow)
        {
            table.Add(newRow);
            dbcontext.SaveChanges();
        }
        public void Edit(T newRow)
        {
            table.Update(newRow);
            dbcontext.SaveChanges();
        }

        public void Delete(T row)
        {
            table.Remove(row);
            dbcontext.SaveChanges();
        }
    }
}
