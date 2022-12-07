using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete
{
    public class SuccesResult:Result
    {
        public SuccesResult(string message) : base(true, message)
        {
        }

        public SuccesResult():base(true)
        {
            
        }
    }
}
