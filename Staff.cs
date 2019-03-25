using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _152120151071_OOP2_Lab
{
    class Staff
    {
        
        private string ID;
        private string name;
        private string surname;
        private string address;
        private int salary;
      public  Staff(string ıd,string Name,string Surname,string Address,int Salary)
        {
            this.ID = ıd;
            this.name = Name;
            this.surname = Surname;
            this.address = Address;
            this.salary = Salary;
        }
       
      public string ıd
        {
            get { return ID; }
            set { ID = value;  }
            
        }
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
       

    }
}
