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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        bool orderDesc = false;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            readDatabase();
        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            readDatabase();
        }
        void readDatabase() {
            using (var conn = new SQLiteConnection(App.dbName))
            {
                var createResult = conn.CreateTable<Contact>();
                if (orderDesc)
                    contacts = conn.Table<Contact>().OrderByDescending(c => c.Name, new CaseInsensitiveComparer()).ToList();
                else
                    contacts = conn.Table<Contact>().OrderBy(c => c.Name, new CaseInsensitiveComparer()).ToList();
            }
            if (contacts != null) {
                /*
                foreach (var contact in contacts){
                    lstContacts.Items.Add(new ListViewItem(){
                       Content = contact
                    });
                }
                */
                lstContacts.ItemsSource = contacts;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTextBox = sender as TextBox;
            lstContacts.ItemsSource = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
        }

        public class CaseInsensitiveComparer : IComparer<string>{
            public int Compare(string x, string y){
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void btnOrderAsc_Click(object sender, RoutedEventArgs e)
        {
            orderDesc = false;
            readDatabase();
        }

        private void btnOrderDesc_Click(object sender, RoutedEventArgs e)
        {
            orderDesc = true;
            readDatabase();
        }

        private void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)lstContacts.SelectedItem;
            if (selectedContact != null) {
                var contactDetailWindow = new ContactDetailWindow(selectedContact);
                contactDetailWindow.ShowDialog();
                readDatabase();
            }
        }
    }
}
