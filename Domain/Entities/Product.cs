using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public float Price { get; set; }

        [Column(TypeName = "nvarchar(400)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "int(4.0)")]
        public int Stock {  get; set; }

       
    }
}
