using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserServices
    {
        IResult Add(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Update(User user);
        IResult Delete(User user);
    }
}

