using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginpagetest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database database = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginuser = username.Text;
            var passworduser = password.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user,login_user,password_user from register where login_user='{loginuser}' and password_user='{passworduser}'";
            SqlCommand command = new SqlCommand(querystring, database.Getconnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count==1)
            {
                MessageBox.Show("qewey");
            }

            else
            {
                MessageBox.Show("wrong");
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Window1 r1 = new Window1();
            this.Close();
            r1.Show();
        }
    }
}
