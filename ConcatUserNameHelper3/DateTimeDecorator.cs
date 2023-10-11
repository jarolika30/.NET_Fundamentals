using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatUserNameHelper
{
    public class DateTimeDecorator
    {
        public string ConcatUserName(string name)
        {

            return $"{DateTime.Now} Hello, {name}!";
        }
    }
}
