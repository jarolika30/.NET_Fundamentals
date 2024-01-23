
using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly asm = Assembly.LoadFrom(@"..\..\..\..\ConfigurationManagerLib\bin\Debug\ConfigurationManagerLib.dll");

            Type t = asm.GetType("ConfigurationManagerLib.CustomConfigurationComponent");

            var methodInfo = t?.GetMethod("LoadSettings");

            if (methodInfo == null)
            {
                // never throw generic Exception - replace this with some other exception type
                throw new Exception("No such method exists.");
            }

            var o = Activator.CreateInstance(t);

            var r = methodInfo.Invoke(o, null);
        }
    }
}
