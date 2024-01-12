namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var config = new CustomConfigurationComponent();
            config.LoadSettings();
        }
    }
}
