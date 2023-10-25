using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNameHelper
{
    public class DateTimeDecorator
    {
        public string ConcatUserName(string name)
        {

            return $"{DateTime.Now} Hello, {name}!";
        }
    }
}
