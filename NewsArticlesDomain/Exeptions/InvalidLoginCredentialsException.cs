using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticlesDomain.Exeptions
{
    public class InvalidLoginCredentialsException : Exception
    {
        public InvalidLoginCredentialsException() : base("Invalid login credentials")
        { }
    }
}
