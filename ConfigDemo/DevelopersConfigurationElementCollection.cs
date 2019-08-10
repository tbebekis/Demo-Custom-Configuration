using System;
using System.Configuration;

namespace ConfigDemo
{
    public class DevelopersConfigurationElementCollection : ConfigurationElementCollection
    {

        /* overrides */        
        protected override ConfigurationElement CreateNewElement()
        {
            return new PersonConfigurationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as PersonConfigurationElement).Code;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override string ElementName
        {
            get { return "Developer"; }
        }

        /* public */
        public int IndexOf(string Code)
        {
            Code = Code.ToLower();

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Code.ToLower() == Code)
                    return i;
            }
            return -1;
        }

        /* properties */
        public new PersonConfigurationElement this[string Code]
        {
            get
            {
                int Index = IndexOf(Code);
                return Index >= 0 ? BaseGet(Index) as PersonConfigurationElement : null;
            }
        }
        public PersonConfigurationElement this[int Index] { get { return BaseGet(Index) as PersonConfigurationElement; } }

    }
}
