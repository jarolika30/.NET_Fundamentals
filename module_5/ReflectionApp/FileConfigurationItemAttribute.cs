using System;

namespace ReflectionApp
{
    public class FileConfigurationItemAttribute: Attribute
    {
        public string KeyName { get; set; }

        public FileConfigurationItemAttribute(string name)
        {
            KeyName = name;
        }
    }
}
