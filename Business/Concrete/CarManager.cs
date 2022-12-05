using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarServices
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception(
                    "Araba ismi en az iki karakter içermelidir ve arabanın günlük fiyatı 0 dan büyük olmalıdır.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public Car Get(int id)
        {
            return _carDal.Get(c => c.Id == id);
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
        public void Update(Car car)
        {
            if (CarStatus(car))
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait araç bulunamadı!");
            }
        }

        public void Delete(Car car)
        {
            if (CarStatus(car))
            {
               _carDal.Delete(car);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait araç bulunamadı!");
            }
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.CarDetails();
        }
    }
}
