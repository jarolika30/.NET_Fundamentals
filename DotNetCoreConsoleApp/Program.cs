using ConcatUserNameHelper;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please input your name!");
var name = Console.ReadLine() ?? string.Empty;
DateTimeDecorator dateTimeDecorator = new DateTimeDecorator();
string output = dateTimeDecorator.ConcatUserName(name);
Console.WriteLine(output);

