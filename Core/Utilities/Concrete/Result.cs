using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete
{
    public class Result:IResult
    {
        public bool Succes { get; }
        public string Message { get; }

        public Result(bool succes, string message):this(succes)
        {
            Message = message;
        }

        public Result(bool succes)
        {
            Succes = succes;
        }
    }
}
