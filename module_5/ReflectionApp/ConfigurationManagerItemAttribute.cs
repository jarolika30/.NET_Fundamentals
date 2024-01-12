using System;
using System.Configuration;
using System.Collections.Specialized;

namespace ReflectionApp
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationManagerItem: Attribute
    {
        private string _propertyName;
        private NameValueCollection appSettings;

        public string PropertyName
        {
            get
            {
                return _propertyName;
            }
        }

        public ConfigurationManagerItem(string propertyName)
        {
            _propertyName = propertyName;
            appSettings = ConfigurationManager.AppSettings;
        }

        /* public string ReadConfigurationManagerItem(string keyName)
        {
            return appSettings.Get(keyName) ?? string.Empty;
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        } */
    }
}
