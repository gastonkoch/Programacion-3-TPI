using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Infrastructure.Data
    {
        public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            private readonly DbContext _dbContext;
            public RepositoryBase(DbContext dbContext)
            {
                _dbContext = dbContext;
            } 
        }
    }

}
