using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorServices
    {
        void Add(Color color);
        List<Color> GetAll();
        Color GetById(int id);
        void Update(Color color);
        void Delete(Color color);
    }
}
