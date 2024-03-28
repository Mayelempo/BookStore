using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException()
        {

        }

        public AlreadyExistException(string message)
        {
                
        }

        public AlreadyExistException(string message, Exception exception)
            :base(message, exception)
        {
                
        }
    }
}
