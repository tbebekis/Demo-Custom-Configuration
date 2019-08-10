using System;
using System.Configuration;

namespace ConfigDemo
{
  
    public class PersonConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Person1")]
        public PersonConfigurationElement Person1
        {
            get { return this["Person1"] as PersonConfigurationElement; }
            set { this["Person1"] = value; }
        }
        [ConfigurationProperty("Person2")]
        public PersonConfigurationElement Person2
        {
            get { return this["Person2"] as PersonConfigurationElement; }
            set { this["Person2"] = value; }
        }
    }


}
