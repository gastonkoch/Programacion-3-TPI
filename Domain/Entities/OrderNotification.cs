﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderNotification
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        public string Message { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}