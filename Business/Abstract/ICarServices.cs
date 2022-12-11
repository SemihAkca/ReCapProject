using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarServices
    {
        IResult Add(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetById(int id);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
