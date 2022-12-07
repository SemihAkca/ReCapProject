using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
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
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccesResult(Messages.AddedProduct);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(),Messages.ListedProducts);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == id));
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
        public IResult Update(Brand brand)
        {
            if (BrandStatus(brand))
            {
                _brandDal.Update(brand);
                return new SuccesResult(Messages.UpdatedProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }

        public IResult Delete(Brand brand)
        {
            if (BrandStatus(brand))
            {
                _brandDal.Delete(brand);
                return new SuccesResult(Messages.DeleteProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }
    }
}
