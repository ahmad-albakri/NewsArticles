using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsArticlesDomain.Exeptions
{
    public class ThisUserIsNotAuthorizedToPostArticles :Exception
    {
        public ThisUserIsNotAuthorizedToPostArticles() : base("This user is not authorized to post articles")
        { }
    }
}
