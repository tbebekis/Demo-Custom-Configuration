using System;
using System.Configuration;

namespace ConfigDemo
{
    public class PersonConfigurationElement : ConfigurationElement
    {
        public PersonConfigurationElement()
        {
        }

        [ConfigurationProperty("Code")]
        public string Code { get { return this["Code"] as string; } }

        [ConfigurationProperty("FirstName", DefaultValue = "John")]
        public string FirstName { get { return this["FirstName"] as string; } }

        [ConfigurationProperty("LastName", DefaultValue = "Doe")]
        public string LastName { get { return this["LastName"] as string; } }

        [ConfigurationProperty("Country")]
        public string Country { get { return this["Country"] as string; } }

        [ConfigurationProperty("City")]
        public string City { get { return this["City"] as string; } }
    }
}
