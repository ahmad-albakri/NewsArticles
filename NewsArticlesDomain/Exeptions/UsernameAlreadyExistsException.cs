using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticlesDomain.Exeptions
{
    public class UsernameAlreadyExistsException : Exception

    {
        public UsernameAlreadyExistsException() : base("UsernameAlreadyExistsException")
        { }
    }
}
