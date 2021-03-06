﻿using System;
using System.Collections.Generic;

namespace BethanysPieShop2.Models {
    public class OrderRepository : IOrderRepository {

        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart) {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        //public void CreateOrder(Order order) {

        //    order.OrderPlaced = DateTime.Now;

        //    _appDbContext.Orders.Add(order);
        //    _appDbContext.SaveChanges();

        //    var shoppingCartItems = _shoppingCart.ShoppingCartItems;

        //    foreach (var shoppingCartItem in shoppingCartItems) {
        //        var orderDetail = new OrderDetail() {
        //            Amount = shoppingCartItem.Amount,
        //            PieId = shoppingCartItem.Pie.PieId,
        //            OrderId = order.OrderId,
        //            Price = shoppingCartItem.Pie.Price
        //        };

        //        _appDbContext.OrderDetails.Add(orderDetail);
        //    }
        //    _appDbContext.SaveChanges();
        //}

        public void CreateOrder(Order order) {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            // adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems) {
                var OrderDetail = new OrderDetail {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(OrderDetail);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}
