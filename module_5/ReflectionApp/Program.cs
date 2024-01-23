namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var config = new CustomConfigurationComponent();

            config.Application = "reflection2";
            config.Amount = 2.23;
            config.Files = 77;
            config.JsonFile = "./events.json";
            //config.LoadSettings();
            //config.SaveSettings();
            config.LoadFilePropertiesInfo();
        }
    }
}
