

using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLogic.Loggers.Base
{
    public class EntityLogger<T> where T : class
    {
        protected EbsContext context { get; set; }
        protected DbSet<T> DbSet => context.Set<T>();
        public virtual Task<int> Count => DbSet.CountAsync();

        protected EntityLogger(EbsContext context)
        {
            this.context = context;
        }
    }
}
