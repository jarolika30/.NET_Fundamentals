using System;
using System.Configuration;
using System.Collections.Specialized;

namespace ConfigurationManagerLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationManagerItem: Attribute
    {
        private string _propertyName;

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
        }
    }
}
