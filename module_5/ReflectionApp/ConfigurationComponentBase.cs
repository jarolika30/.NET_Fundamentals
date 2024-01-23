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

        private IEnumerable<PropertyInfo> getConfigurationManagerItemProperties()
        {
            var currentObject = this.GetType();

            return currentObject.GetProperties().Where(property => property.GetCustomAttribute<ConfigurationManagerItem>() != null); ;
        }

        private IEnumerable<PropertyInfo> getFileConfigurationItemProperties()
        {
            var currentObject = this.GetType();

            return currentObject.GetProperties().Where(property => property.GetCustomAttribute<FileConfigurationItemAttribute>() != null); ;
        }

        private List<string> getPropertyList(IEnumerable<PropertyInfo> propsInfo)
        {
            List<string> properties = new List<string>();

            foreach (PropertyInfo prop in propsInfo)
            {
                var customAttr = prop.GetCustomAttribute<ConfigurationManagerItem>(false);

                if (customAttr != null)
                {
                    properties.Add(customAttr.PropertyName);

                }
            }

            return properties;
        }

        private Dictionary<string, string> getPropertyListWithValues(IEnumerable<PropertyInfo> propsInfo)
        {
            var properties = new Dictionary<string, string>();

            foreach (PropertyInfo prop in propsInfo)
            {
                var customAttr = prop.GetCustomAttribute<ConfigurationManagerItem>(false);

                if (customAttr != null)
                {
                    var propValue = prop.GetValue(this);
                    Console.WriteLine($"the property value'{propValue}'.");

                    if (propValue != null)
                    {
                        properties.Add(customAttr.PropertyName, propValue.ToString() ?? String.Empty);
                    }
                    else
                    {
                        Console.WriteLine($"Please set value to the property '{prop.Name}'. It will not be saved.");
                    }

                }
            }

            return properties;
        }

        public void setAppSetting(string key, string value)
        {
            //Load appsettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //Check if key exists in the settings
            if (config.AppSettings.Settings[key] != null)
            {
                //If key exists, delete it
                config.AppSettings.Settings.Remove(key);
            }
            //Add new key-value pair
            config.AppSettings.Settings.Add(key, value ?? "test");
            //Save the changed settings
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            Console.WriteLine($"Saving key - {key} and value - {value}");
        }

        public void SaveSettings()
        {
            var propsToSet = getConfigurationManagerItemProperties();

            Console.WriteLine("Saving properties of ConfigurationManagerItem type are:");

            try
            {
                if (propsToSet.ToArray().Length != 0)
                {
                    Dictionary<string, string> appConfigProperties = getPropertyListWithValues(propsToSet);
                    Console.WriteLine($"appConfigProperties: {appConfigProperties.Count}");

                    foreach (var prop in appConfigProperties)
                    {
                        setAppSetting(prop.Key, prop.Value);
                        Console.WriteLine($"prop.Key and prop.Value: {prop.Key}, {prop.Value}");
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error while saving the ConfigurationManagerItem properties");
            }
        }

        public void LoadFilePropertiesInfo()
        {
            var propsToSet = getFileConfigurationItemProperties();
            Console.WriteLine("Reading properties of FileConfigurationItem type are:");
            foreach (PropertyInfo prop in propsToSet)
            {
                var fileAttr = prop.GetCustomAttribute<FileConfigurationItemAttribute>(false);
                var propValue = prop.GetValue(this);

                if (fileAttr != null)
                {
                    Console.WriteLine($"FileConfiguration property:{fileAttr.KeyName}");
                    
                    Console.WriteLine($"the property value'{propValue}'.");
                }
            }
        }

        public void LoadSettings()
        {
            var propsToSet = getConfigurationManagerItemProperties();

            Console.WriteLine("Reading properties of ConfigurationManagerItem type are:");

            if (propsToSet.ToArray().Length != 0)
            {
                List<string> appConfigProperties = getPropertyList(propsToSet);

                if (appConfigProperties.Count > 0)
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;

                    foreach (string keyName in appConfigProperties)
                    {
                        Console.WriteLine(appSettings.Get(keyName));
                    }

                }

            }
            else
            {
                //get object property and set object's value 
                Console.WriteLine("Error while reading the ConfigurationManagerItem properties");
            }
        
        }
    }
}
