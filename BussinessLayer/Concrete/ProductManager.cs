using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BussinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public void TInsert(Product entity)
        {
            //Buraya Eklemek iin gerekli şartlar konulabilir
            if (entity != null)
            {
                _productDal.Insert(entity);
            }
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
