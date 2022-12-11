using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalServices
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            bool status = true;
            DateTime rentDate = rental.RentDate;
            DateTime retunDate = rental.ReturnDate;
            if (_rentalDal.GetAll().Count == 0) 
            {
                _rentalDal.Add(rental);
            }

            foreach (var rental1 in _rentalDal.GetAll())
            {
                if (rental1.CarId == rental.CarId)
                {
                    status = false;
                    rentDate = rental1.RentDate;
                    retunDate = rental1.ReturnDate;
                    break;
                }
            }

            if (retunDate == null)
            {
                return new ErrorResult($"Bu araç {rentDate} bu tarihte kiralandı fakat ne zaman teslim edileceği belli değil");
            }
            if (status)
            {
                _rentalDal.Add(rental);
                return new SuccesResult($"{rental.CarId} id'sine ait aracı {rental.RentDate}" + " tarihinde kiraladınız.");
            }
            
            else
            {
                return new ErrorResult($"Bu araç {rentDate} bu tarihten {retunDate} bu tarihe kadar kiralandı");
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(rental => rental.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.UpdatedRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.DeletedRental);
        }
    }
}
