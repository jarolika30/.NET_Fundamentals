using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.Collections.Specialized;

namespace ReflectionApp
{
    public class ConfigurationComponentBase
    {

        public void SaveSettings()
        {

        }

        public void LoadSettings()
        {
            //use reflection to get and set attributed properties of

            var currentObject = this.GetType();
            var propsToSet = currentObject.GetProperties().Where(property => property.GetCustomAttribute<ConfigurationManagerItem>() != null);
            //get object property and set object's value 
            Console.WriteLine("Properties of System.Type are:");

            if (propsToSet.ToArray().Length != 0)
            {
                List<string> appConfigProperties = new List<string>();

                foreach (PropertyInfo prop in propsToSet)
                {
                    var customAttr = prop.GetCustomAttribute<ConfigurationManagerItem>(false);

                    Console.WriteLine(prop.Name);
                    Console.WriteLine(customAttr);
                    Console.WriteLine(customAttr?.PropertyName);

                    if (customAttr != null)
                    {
                        appConfigProperties.Add(customAttr.PropertyName);
                    
                    }
                }

                if (appConfigProperties.Count > 0)
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;

                    foreach (string keyName in appConfigProperties)
                    {
                        Console.WriteLine(appSettings.Get(keyName));
                    }

                }

            }


        }
    }
}
