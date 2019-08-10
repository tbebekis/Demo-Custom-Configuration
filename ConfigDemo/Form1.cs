using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;

namespace ConfigDemo
{
    public partial class Form1 : Form
    {

        void AnyClick(object sender, EventArgs ea)
        {
            if (btnCase1 == sender)
            {
                Case1();
            }
            else if (btnCase2 == sender)
            {
                Case2();
            }
            else if (btnCase3 == sender)
            {
                Case3();
            }
            else if (btnCase4 == sender)
            {
                Case4();
            }
            else if (btnCase5 == sender)
            {
                Case5();
            }
        }

        void FormInitialize()
        {
            btnCase1.Click += AnyClick;
            btnCase2.Click += AnyClick;
            btnCase3.Click += AnyClick;
            btnCase4.Click += AnyClick;
            btnCase5.Click += AnyClick;
        }
        // 1. Using the preset appSettings section tag
        void Case1()
        {           
            string FirstName = ConfigurationManager.AppSettings["FirstName"];
            string LastName = ConfigurationManager.AppSettings["LastName"];
        }
        // 2. Using a custom section
        void Case2()
        {            
            NameValueCollection Section = ConfigurationManager.GetSection("Location") as NameValueCollection;
            if (Section != null)
            {
                string Country = Section["Country"];
                string City = Section["City"];
            }
        }
        // 3. Using a custom section group
        void Case3()
        {
            NameValueCollection Section = ConfigurationManager.GetSection("InfoGroup/PersonInfo") as NameValueCollection;
            if (Section != null)
            {
                string FirstName = Section["FirstName"];
                string LastName = Section["LastName"];
            }

            Section = ConfigurationManager.GetSection("InfoGroup/AddressInfo") as NameValueCollection;
            if (Section != null)
            {
                string Country = Section["Country"];
                string City = Section["City"];
            }
        }
        // 4. Using a custom ConfigurationSection class and a custom ConfigurationElement class
        void Case4()
        {
            PersonConfigurationSection Section = ConfigurationManager.GetSection("Person") as PersonConfigurationSection;
            if (Section != null && Section.Person2 != null)
            {
                string FirstName = Section.Person2.FirstName;
                string LastName = Section.Person2.LastName;
                string Country = Section.Person2.Country;
                string City = Section.Person2.City;                
            }
        }
        // 5. Using a custom ConfigurationElementCollection to have a section that simulates a collection of elements
        void Case5()
        {
            DevelopersConfigurationSection Section = ConfigurationManager.GetSection("Developers") as DevelopersConfigurationSection;
            if (Section != null && Section.Developers != null)
            {
                PersonConfigurationElement Developer = Section.Developers["THB"];

                if (Developer != null)
                {
                    string Code = Developer.Code;
                    string FirstName = Developer.FirstName;
                    string LastName = Developer.LastName;
                    string Country = Developer.Country;
                    string City = Developer.City;
                }
            }
        }

 
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();

            base.OnShown(e);
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
