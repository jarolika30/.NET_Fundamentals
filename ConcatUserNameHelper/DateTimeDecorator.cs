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