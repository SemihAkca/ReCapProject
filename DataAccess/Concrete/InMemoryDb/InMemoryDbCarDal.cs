using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemoryDb
{
    public class InMemoryDbCarDal:ICarDal
    {
        private List<Car> _cars; 
        public InMemoryDbCarDal()
        {
            _cars= new List<Car>()
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear = 2000,DailyPrice = 850,Description = "2000 Model Bmw"},
                new Car{Id = 2,BrandId = 2,ColorId = 2,ModelYear = 2000,DailyPrice = 1000,Description = "2000 Model Mercedes"},
                new Car{Id = 3, BrandId = 1, ColorId = 1, ModelYear = 2003, DailyPrice = 1000, Description = "2003 Model Bmw" },
                new Car{Id = 4, BrandId = 4, ColorId = 3, ModelYear = 2018, DailyPrice = 2000, Description = "2018 Model Volvo" },
                new Car{Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 1800, Description = "2010 Model Mercedes" },
            };
        }

        public void Add(Car car)
        {
            bool result = false;
            for (int i = 0; i < _cars.Count; i++)
            {
                if (_cars[i].Id == car.Id)
                {
                    result = true;
                    break;
                }
            }

            if (result == true)
            {
                Console.WriteLine("Invalid Car");
            }
            else
            {
                _cars.Add(car);
            }
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car cartToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            cartToUpdate.BrandId = car.BrandId;
            cartToUpdate.ColorId = car.ColorId;
            cartToUpdate.ModelYear = car.ModelYear;
            cartToUpdate.DailyPrice = car.DailyPrice;
            cartToUpdate.Description = car.Description;
        }

        public void Delete(int id)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }
    }
}
