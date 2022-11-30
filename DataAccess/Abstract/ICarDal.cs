using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        List<Car> GetAllCars();
        void Update(Car car);
        void Delete(int id);
        List<Car> GetById(int brandId);
    }
}
