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

        [Required]
        [Column(TypeName = "int(4.0)")]
        public int AmountProducts { get; set; } = 0;

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public StatusOrder StatusOrder { get; set; } = StatusOrder.InProgress;

        [Required]
        public User Customer { get; set; }

        [Required]
        public User Seller { get; set; }

        [Required]
        public IEnumerable<Product> ProductsInOrder { get; set; }

    }
}
