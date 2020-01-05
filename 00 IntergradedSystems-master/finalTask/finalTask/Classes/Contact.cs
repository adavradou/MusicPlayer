using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalTask.Classes
{
    class Contact{

        private string name;
        private string lastName;
        private string telephone;
        private string email;
        private string date;

        public Contact() { }

        public Contact(string name, string lastName, string telephone, string email,string date){
            this.name = name;
            this.lastName = lastName;
            this.telephone = telephone;
            this.email = email;
            this.date = date;
        }

        public void setEmail(string mail) { this.email = mail; }
        public void setName(string name) { this.name = name; }
        public void setlastName(string lastName) { this.lastName = lastName; }
        public void setTelephone(string telephone) { this.telephone = telephone; }
        public void setDate(string date) { this.date = date; }

        public string getName() { return this.name; }
        public string getLastName() { return this.lastName; }
        public string getEmail() { return this.email; }
        public string getTelephone() { return this.telephone; }
        public string getDate() { return this.date; }
        
        public string toString()
        {
            return this.name + " " + this.lastName + " " + this.telephone + " " + this.email + " " + this.date;
        }
    }
}
