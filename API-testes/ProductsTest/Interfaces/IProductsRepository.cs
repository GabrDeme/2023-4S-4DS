using ProductsTest.Domains;

namespace ProductsTest.Interfaces
{
    public interface IProductsRepository
    {
        public List<Products> GetAll();

        public Products GetById(Guid id);

        public void Register(Products product);

        void Update(Guid id, Products product);

        void Delete(Guid id);
    }
}
