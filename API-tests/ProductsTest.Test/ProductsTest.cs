using Moq;
using ProductsTest.Domains;
using ProductsTest.Interfaces;
using ProductsTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductsTest.Test
{
    public class ProductsTest() { 
        //Indica que o método é de teste de unidade
        [Fact]
        public void Get()
        {
            //Lista de produtos
            var product = new List<Products>
            {
                new Products {Id = Guid.NewGuid(), Name = "Product 1", Price = 10 },
                new Products {Id = Guid.NewGuid(), Name = "Product 2", Price = 20 },
                new Products {Id = Guid.NewGuid(), Name = "Product 3", Price = 30 }
            };

            //Cria um obj de simulação do tipo ProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o método GetAll para retornar a lista de produtos "mock"
            mockRepository.Setup(x => x.GetAll()).Returns(product);

            //Chama o método GetAll() e armazena o resultado em result
            var result = mockRepository.Object.GetAll();

            //Prova se o resultado esperado é igual ao resultado obtido através de busca
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetById() 
        {
            var productId = Guid.NewGuid();
            var product = new Products { Id = productId, Name = "Product 1", Price = 10 };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetById(productId)).Returns(product);

            var result = mockRepository.Object.GetById(productId);

            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
        }

        //[Fact]
        //public void Register()
        //{
        //    var product = new Products { Id = Guid.NewGuid(), Name = "Product 2", Price = 20 };

        //    var mockRepository = new Mock<IProductsRepository>();
        //    mockRepository.Setup(x => x.Register(product));

        //    var result = mockRepository.Object.Register(product);

        //    Assert.NotNull(result);
        //    Assert.Equal(product.Id, result.Id);
        //    Assert.Equal("Product 2", result.Name);
        //    Assert.Equal(20, result.Price);
        //}

        [Fact]
        public void Post() 
        {
            Products product = new Products { Id = Guid.NewGuid(), Name = "Kiwi", Price = 0.5m };

            var productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Register(product)).Callback<Products>(x => productList.Add(product));

            mockRepository.Object.Register(product);

            Assert.Contains(product, productList);
        }

        [Fact]
        public void Update() 
        {
            // Arrange
            Products product = new Products { Id = Guid.NewGuid(), Name = "Kiwi", Price = 0.5m };
            var productList = new List<Products> { product };

            var updatedProduct = new Products { Id = product.Id, Name = "Updated Kiwi", Price = 0.75m };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Update(It.IsAny<Products>())).Callback<Products>(updatedProd =>
            {
                var index = productList.FindIndex(p => p.Id == updatedProd.Id);
                if (index != -1)
                {
                    productList[index] = updatedProd;
                }
            });

            // Act
            mockRepository.Object.Update(updatedProduct);

            // Assert
            var productInList = productList.Find(p => p.Id == updatedProduct.Id);
            Assert.NotNull(productInList);
            Assert.Equal("Updated Kiwi", productInList.Name);
            Assert.Equal(0.75m, productInList.Price);
        }

        [Fact]
        public void Delete()
        {
            Products product = new Products { Id = Guid.NewGuid(), Name = "Kiwi", Price = 0.5m };
            var productList = new List<Products> { product };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(id => productList.RemoveAll(p => p.Id == id));

            mockRepository.Object.Delete(product.Id);

            Assert.DoesNotContain(product, productList);
        }
    }
}
