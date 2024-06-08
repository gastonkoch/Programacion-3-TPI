using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column(TypeName = "int(4.0)")]
        public int AmountProducts { get; set; } = 0;// ver como hacer para que el amoute se calcule segun la cantidad de elementos que tenga product
        
        public PaymentMethod PaymentMethod { get; set; }
        
        public StatusOrder StatusOrder { get; set; } = StatusOrder.InProgress;
        
        [Required]
        //public int CustomerId { get; set; }
        public User Customer { get; set; } // Revisar si conviene usar el id o el objeto
        
        [Required]
        //public int SellerId { get; set; }
        public User Seller { get; set; } // Revisar si conviene usar el id o el objeto

        public IEnumerable<Product> ProductsInOrder { get; set; }

    }
}
