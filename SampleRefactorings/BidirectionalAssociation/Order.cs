﻿using System;
using System.Collections.Generic;

namespace SampleRefactorings.BidirectionalAssociation
{
    public class Order
    {
        private Customer _customer;

        /// <summary>
        /// 1 Customer is linked to N Orders => link is managed in Order
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer?.FriendOrders().Remove(this);     //remove link from old customer to this order
                _customer = value;                               //change customer
                _customer?.FriendOrders().Add(this);        //add link for new customer to this order
            }
        }

        public double GetDiscountedPrice() => GetGrossPrice() * (1 - _customer.GetDiscount());

        public double GetGrossPrice() => 100500;
    }

    public class Customer
    {
        public ISet<Order> Orders { get; } = new HashSet<Order>();

        /// <summary>
        /// should be used in Order only - when the association is changed
        /// </summary>
        internal ISet<Order> FriendOrders() => Orders;

        //optional
        public void AddOrder(Order anOrder) => anOrder.Customer = this;

        //chaos monkey style 
        public double GetDiscount() => new Random(DateTime.UtcNow.Millisecond).NextDouble();

        public double GetPriceFor(Order order)
        {
            if (Orders.Contains(order))
                return order.GetDiscountedPrice();

            throw new Exception($"{nameof(Orders)} should contain {order} for customer {this}");
        }
    }
}