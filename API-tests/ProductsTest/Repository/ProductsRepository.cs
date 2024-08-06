using ProductsTest.Context;
using ProductsTest.Domains;
using ProductsTest.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace ProductsTest.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public ProductsTestContext ctx = new ProductsTestContext();

        public List<Products> GetAll()
        {
            var products = new List<Products>();
            return products;
        }

        public Products GetById(Guid id)
        {
            try 
            {
                Products searchedProduct = ctx.Products.Find(id)!;

                return searchedProduct;
            //    List<Products> products = ctx.Products
            //        .Where(x => x.Id == id)
            //        .ToList();

                //    return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(Products product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }

        public void Update(Guid id, Products product)
        {
            try
            {
                Products searchedProduct = ctx.Products.Find(id)!;

                if (searchedProduct != null)
                {
                    ctx.Products.Update(searchedProduct);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try 
            { 
                Products searchedProduct = ctx.Products.Find(id)!;

                if(searchedProduct != null)
                {
                    ctx.Products.Remove(searchedProduct);
                }

                ctx.SaveChanges();
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
