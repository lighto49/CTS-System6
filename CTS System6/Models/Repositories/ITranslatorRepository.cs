using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public interface ITranslatorRepository<TEntity>
    {

        IList<TEntity> List();
        IList<TEntity> List(string id);

        TEntity Find(string id);

        void Add(TEntity entity);

        void Update(string id, TEntity entity);
        void Delete(string id);

    }
}
