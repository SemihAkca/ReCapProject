using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandServices
    {
        void Add(Brand brand);
        List<Brand> GetAll();
        Brand GetById(int id);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
