using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete
{
    public class DataResult<T>:IDataResult<T>
    {
        public bool Succes { get; }
        public string Message { get; }
        public T Data { get; }

        public DataResult(T data, bool succes, string message):this(data,succes)
        {
            Message = message;
        }

        public DataResult(T data,bool succes)
        {
            Succes = succes;
            Data = data;
        }
    }
}
