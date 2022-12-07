using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Business.Abstract
{
    public interface IColorServices
    {
        IResult Add(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
