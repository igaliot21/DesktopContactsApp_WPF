using DesktopContactsApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact(txtName.Text, txtEmail.Text, txtPhone.Text);

            /*
            var conn = new SQLiteConnection(dbName); // var conn = new SQLiteConnection(databasePath);
            var createResult = conn.CreateTable<Contact>();
            var insertResult = conn.Insert(contact);
            conn.Close();
            */

            using (var conn = new SQLiteConnection(App.dbName)) {
                var createResult = conn.CreateTable<Contact>();
                var insertResult = conn.Insert(contact);
            }

            this.Close();
        }
    }
}
