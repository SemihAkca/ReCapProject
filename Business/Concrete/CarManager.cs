using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager:ICarServices
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(),car);

            _carDal.Add(car);
            return new SuccesResult(Messages.AddedProduct);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedProducts);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.ListedProducts);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.ListedProducts);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        bool CarStatus(Car car)
        {
            bool status = false;
            foreach (var car1 in _carDal.GetAll().Where(car1 => car1.Id == car.Id))
            {
                status = true;
            }
            return status;
        }
        public IResult Update(Car car)
        {
            if (CarStatus(car))
            {
                _carDal.Update(car);
                return new SuccesResult(Messages.UpdatedProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }

        public IResult Delete(Car car)
        {
            if (CarStatus(car))
            {
               _carDal.Delete(car);
               return new SuccesResult(Messages.DeleteProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailsDto>>(_carDal.CarDetails(), Messages.ListedProducts);
        }
    }
}
