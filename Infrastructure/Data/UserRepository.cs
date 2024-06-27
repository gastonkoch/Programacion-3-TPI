using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    // La clase UserRepository hereda de EfRepository<User>.
    // Esto significa que UserRepository obtiene todas las propiedades y métodos definidos en EfRepository para trabajar específicamente con entidades de tipo User.

    // Al definir UserRepository : EfRepository<User>, T se convierte en User en toda la cadena de herencia.
    // Por lo tanto, UserRepository hereda métodos y propiedades de EfRepository<User>, que a su vez hereda de RepositoryBase<User>.
    public class UserRepository : EfRepository<User>, IUserRepository // Cuando defines UserRepository, estás especializando EfRepository para el tipo User.
    {
        //El constructor de UserRepository acepta un parámetro de tipo ApplicationDbContext y lo pasa al constructor de su clase base (EfRepository).
        //Esto se hace mediante la llamada : base(context).
        public UserRepository(ApplicationDbContext context) : base(context) { }

        // Nosotros al usar el contructor de EfRepository, como le estamos pasando un tipo de contexto a su constructor, utilizando el base, vamos a poder a acceder a _aplicationDbContext
        // Nosotros estamos heredando el _aplicationDbContext
        public User? GetByUserEmail(string userEmail)
        {
            return _applicationDbContext.Users.SingleOrDefault(p => p.Email == userEmail);
        }
    }
}
