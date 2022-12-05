using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandServices
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.Id == id);
        }

        bool BrandStatus(Brand brand)
        {
            bool status = false;
            foreach (var brand1 in _brandDal.GetAll().Where(brand1 => brand1.Id == brand.Id))
            {
                status = true;
            }
            return status;
        }
        public void Update(Brand brand)
        {
            if (BrandStatus(brand))
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait model bulunamadı!");
            }
        }

        public void Delete(Brand brand)
        {
            if (BrandStatus(brand))
            {
                _brandDal.Delete(brand);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait model bulunamadı!");
            }
        }
    }
}
