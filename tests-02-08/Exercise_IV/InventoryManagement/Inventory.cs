using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public static class Inventory
    {
        private static Dictionary<string, int> products = new Dictionary<string, int>();

        public static void AddProduct(string name, int amount)
        {
            if (products.ContainsKey(name))
            {
                products[name] += amount;
            }
            else
            {
                products[name] = amount;
            }
        }

        public static int GetAmountOfProducts(string name)
        {
            return products.ContainsKey(name) ? products[name] : 0;
        }

        public static void ResetInventory()
        {
            products.Clear();
        }
    }
}
