using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagement.Test
{
    public class InventaryUnitTest
    {
        public InventaryUnitTest()
        {
            Inventory.ResetInventory();
        }

        [Fact]
        public void TestingInventoryManagementMethod()
        {
            var product = "Produto Teste";
            var amount = 5;

            Inventory.AddProduct(product, amount);

            Assert.Equal(amount, Inventory.GetAmountOfProducts(product));
        }

        [Fact]
        public void TestingExistingProductMethod()
        {
            var product = "Produto Teste";
            var initialAmount = 5;
            var AdditionalAmount = 3;

            Inventory.AddProduct(product, initialAmount);
            Inventory.AddProduct(product, AdditionalAmount);

            Assert.Equal(initialAmount + AdditionalAmount, Inventory.GetAmountOfProducts(product));
        }

        [Fact]
        public void TestingNonexistentProductMethod()
        {
            var product = "Produto Inexistente";

            var amount = Inventory.GetAmountOfProducts(product);

            Assert.Equal(0, amount);
        }
    }
}
