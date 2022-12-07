using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorServices
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccesResult(Messages.AddedProduct);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll(),Messages.ListedProducts);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(color => color.Id == id));
        }

        bool ColorStatus(Color color)
        {
            bool status = false;
            foreach (var color1 in _colorDal.GetAll().Where(color1 => color1.Id == color.Id))
            {
                status = true;
            }
            return status;
        }
        public IResult Update(Color color)
        {
            if (ColorStatus(color))
            {
                _colorDal.Update(color);
                return new SuccesResult(Messages.UpdatedProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }

        public IResult Delete(Color color)
        {
            if (ColorStatus(color))
            {
                _colorDal.Delete(color);
                return new SuccesResult(Messages.DeleteProduct);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProduct);
            }
        }
    }
}
