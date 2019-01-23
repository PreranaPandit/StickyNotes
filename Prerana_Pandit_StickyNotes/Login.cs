using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prerana_Pandit_StickyNotes
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //encapsulation applied (data hiding)
            LoginBLL LoginBLL = new LoginBLL();

            //trims the spaces from textboxes of username and password
            LoginBLL._username = txtUserName.Text.Trim();
            LoginBLL._password = txtPassword.Text.Trim();

            //check valid user 
            bool isValidUser = LoginBLL.checkUser();

            if (isValidUser)
            {
                MessageBox.Show("Succefully logged in!!!..");
                this.Hide();
                Dashboard obj = new Dashboard(txtUserName.Text);
               
                obj.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please check your Username or password again. It is incorrect!!!!");
            }
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            //back to maindashboard
            this.Hide();
            Userentry main = new Userentry();
            main.ShowDialog();
        }
    }
}
