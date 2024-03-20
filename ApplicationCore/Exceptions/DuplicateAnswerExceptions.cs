using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class DuplicateAnswerException: Exception
    {
        public DuplicateAnswerException(string message) : base(message)
        {
        }
    }
}
