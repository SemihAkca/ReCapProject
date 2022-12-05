using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(color => color.Id == id);
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
        public void Update(Color color)
        {
            if (ColorStatus(color))
            {
                _colorDal.Update(color);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait renk bulunamadı!");
            }
        }

        public void Delete(Color color)
        {
            if (ColorStatus(color))
            {
                _colorDal.Delete(color);
            }
            else
            {
                Console.WriteLine("Bu Id'ye ait renk bulunamadı!");
            }
        }
    }
}
