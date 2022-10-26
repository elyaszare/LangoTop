﻿using System.Collections.Generic;

namespace _01_Query.Contracts.Order
{
    public class OrderQueryModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string AccountFullName { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public string CreationDate { get; set; }
        public List<OrderItemQueryModel> OrderItems { get; set; }
    }
}
