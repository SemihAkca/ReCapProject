using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerServices
    {
        IResult Add(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
