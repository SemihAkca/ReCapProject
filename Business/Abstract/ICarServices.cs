using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarServices
    {
        void Add(Car car);
        List<Car> GetAll();
        void Update(Car car);
        void Delete(int id);
        List<Car> GetById(int brandId);

    }
}
