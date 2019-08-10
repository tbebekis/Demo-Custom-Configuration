using System;
using System.Configuration;

namespace ConfigDemo
{
    public class DevelopersConfigurationSection : ConfigurationSection
    {
        public DevelopersConfigurationSection()
        {
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public DevelopersConfigurationElementCollection Developers { get { return base[""] as DevelopersConfigurationElementCollection; } } 
    }


}
