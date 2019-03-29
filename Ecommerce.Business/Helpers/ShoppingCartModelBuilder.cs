﻿using Ecommerce.Models;
using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class ShoppingCartModelBuilder
    {
        public static ShoppingCartModel Create(ShoppingCart cart)
        {
            if (cart == null) return null;

            var cartModel = new ShoppingCartModel
            {
                id = cart.Id,
                userId = cart.User == null ? 0 : cart.User.Id,
                shoppingProducts = new List<ShoppingProductModel>()
            };

            if (cart.ShoppingProducts == null || cart.ShoppingProducts.Count == 0)
            {
                return cartModel;
            }

            foreach (var prod in cart.ShoppingProducts)
            {
                cartModel.shoppingProducts.Add(ShoppingProductModelBuilder.Create(prod));
            }

            return cartModel;
        }
    }
}
