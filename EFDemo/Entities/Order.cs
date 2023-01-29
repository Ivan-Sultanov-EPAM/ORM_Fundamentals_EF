﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
    }
}