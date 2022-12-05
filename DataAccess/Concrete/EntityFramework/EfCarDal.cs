using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfRepositoryBase<Car,CarProjectContext>,ICarDal
    {
        public List<CarDetailsDto> CarDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars join b in context.Brands 
                    on c.BrandId equals b.Id join rgb in context.Colors 
                    on b.Id equals rgb.Id 
                    select new CarDetailsDto()
                    {
                        CarName = c.Description, BrandName = b.BrandName, ColorName = rgb.ColorName, DailyPrice = c.DailyPrice 
                    };
                return result.ToList();
            }
        }
    }
}
