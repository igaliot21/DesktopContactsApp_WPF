using DesktopContactsApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contact contact;
        public ContactDetailWindow(Contact Contact)
        {
            InitializeComponent();
            this.contact = Contact;
            txtName.Text = contact.Name;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e )
        {
            if (MessageBox.Show("The contact is going to be updated", "Update contact", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {

                contact.Name = txtName.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtPhone.Text;
                using (var conn = new SQLiteConnection(App.dbName))
                {
                    var createResult = conn.CreateTable<Contact>();
                    var insertResult = conn.Update(contact);
                }
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("The contact is going to be deleted", "Delete contact", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                using (var conn = new SQLiteConnection(App.dbName))
                {
                    var createResult = conn.CreateTable<Contact>();
                    var insertResult = conn.Delete(contact);
                }
                this.Close();
            }
        }
    }
}
