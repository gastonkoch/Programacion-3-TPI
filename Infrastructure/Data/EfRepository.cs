using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    // El constructor de EfRepository toma un parámetro de tipo ApplicationDbContext y lo pasa al constructor de la clase base (RepositoryBase) usando : base(dbContext).
    // Luego, inicializa el campo _applicationDbContext con esta instancia.
    public class EfRepository<T> : RepositoryBase<T> where T : class
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public EfRepository(ApplicationDbContext dbContext) : base(dbContext) // El constructor de EfRepository acepta un parámetro de tipo ApplicationDbContext y lo pasa al constructor de la clase base RepositoryBase con : base(dbContext).
        {
            _applicationDbContext = dbContext; // Inicializa el campo _applicationDbContext con la instancia de ApplicationDbContext pasada como parámetro
        }
    }
}
