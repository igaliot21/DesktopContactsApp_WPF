using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Model
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(256)]
        [Unique]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(32)]
        public string Phone { get; set; }
        public Contact(){}
        public Contact(string Name, string Email, string Phone)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
        }
    }
}