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
using System.Windows.Shapes;

namespace loginpagetest
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
         Database database = new Database();
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");
            //con.Open();
            //string ad_data = "INSERT INTO [dbo].[user] VALUES(@username,password)";
            //SqlCommand cmd = new SqlCommand(ad_data, con);
            //
            //cmd.Parameters.AddWithValue("@username", username.Text);
            //cmd.Parameters.AddWithValue("@password", password.Password);
            //cmd.ExecuteNonQuery();
            //con.Close();



            var loginuser = username1.Text;
            var passworduser = password1.Password;


            string quertystring = $"insert into register(login_user,password_user) values('{loginuser}','{passworduser}')";

            SqlCommand command = new SqlCommand(quertystring,database.Getconnection());

            database.Openconnection();

            if(command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("qeweey yarandii");
                MainWindow r1 = new MainWindow();
                this.Close();
                r1.Show();
            }

            else
            {
                MessageBox.Show("yioo alnmadi");
            }
            database.CloseConnection();
        }

        private bool checkuser()
        {
            var loginus = username1.Text;
            var passwo = password1.Password;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user,login_user,password_user from register where login_user='{loginus}' and password_user='{passwo}'";
            SqlCommand command = new SqlCommand(querystring, database.Getconnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count>0)
            {
                MessageBox.Show("yio qaqa bu ad var uje");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
