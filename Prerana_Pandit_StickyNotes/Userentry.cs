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
    public partial class Userentry : Form
    {
        public Userentry()
        {
            InitializeComponent();
        }
        //information hiding (encapsulation)

        UserEntryBLL userBll = new UserEntryBLL();


        //encapsulation for retrieving the userTypeName from userType 

        UserEntryBLL userTypeBll = new UserEntryBLL();


        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation done for all labels from users form:

            if (cboUserType.Text == "")
            {
                MessageBox.Show("please enter the usertype!!");
                cboUserType.Focus();
                return;
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Enter your first name!!..");
                txtFirstName.Focus();
                return;
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Enter your last name!!..");
                txtLastName.Focus();
                return;
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("enter your address!!!");
                txtAddress.Focus();
                return;
            }
            else if (rdobtnMale.Checked == false && rdobtnFemale.Checked == false && rdobtnOthers.Checked == false)
            {
                MessageBox.Show("please choose your gender !!!");
                rdobtnMale.Focus();
                return;
            }

            else if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("enter your phone numnber!!!");
                txtPhoneNumber.Focus();
                return;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("enter your email id!!!");
                txtEmail.Focus();
                return;
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("enter username for login!!");
                txtUserName.Focus();
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("enter strong password and remeber it!!");
                txtPassword.Focus();
                return;
            }
            else
            {

                int userTypeId;
                string firstName;
                string lastName;
                string address;
                string gender;

                string phoneNumber;
                string email;
                string Username;
                string Password;

                userTypeId = (int)cboUserType.SelectedValue;
                firstName = txtFirstName.Text;
                lastName = txtLastName.Text;
                address = txtAddress.Text;

                //vaidation for gender
                if (rdobtnMale.Checked == true)
                {
                    gender = "Male";
                }
                else if (rdobtnFemale.Checked == true)
                {
                    gender = "Female";
                }
                else if (rdobtnOthers.Checked == true)
                {
                    gender = "Others";
                }
                else
                {
                    MessageBox.Show("please do not leave the gender section unchecked !!!");
                    return;
                }


                phoneNumber = txtPhoneNumber.Text;
                email = txtEmail.Text;
                Username = txtUserName.Text;
                Password = txtPassword.Text;


                //getter and setter

                userBll._userTypeId = userTypeId;
                userBll._firstName = firstName;
                userBll._lastName = lastName;
                userBll._address = address;
                userBll._gender = gender;

                userBll._phoneNumber = phoneNumber;
                userBll._email = email;
                userBll._Username = Username;
                userBll._Password = Password;

                //SAVE and UPDATE code begins 
                //if condition for SAVE
                if (btnSave.Text == "SAVE")
                {
                    userBll.insertUsers();
                    MessageBox.Show("Rows are inserted successfully!!");

                    dgData.DataSource = userBll.retrieveUsers();
                    //erases the input values
                    cboUserType.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNumber.Text = "";
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";

                }

                //update click event through if-condition
                else if (btnSave.Text == "UPDATE")
                {
                    int UserId = int.Parse(dgData.CurrentRow.Cells["UserId"].Value.ToString());

                    //update code retrieved form BLL
                    userBll.updateUsers(UserId);
                    MessageBox.Show("Rows are updated successfully by user!!");
                    //UPDATE changes to SAVE again
                    btnSave.Text = "SAVE";

                    dgData.DataSource = userBll.retrieveUsers();
                    //erases the updated values
                    cboUserType.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNumber.Text = "";
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";

                }


            }
        }

        
        //for combobox usertype (class created)
        UserTypeBLL usertypebll = new UserTypeBLL();

        private void Userentry_Load(object sender, EventArgs e)
        {
            dgData.DataSource = userBll.retrieveUsers();
            //userTypeName retrieve begins
            cboUserType.DataSource = usertypebll.retrieveUserType();
            cboUserType.DisplayMember = "Usertype_Name";
            cboUserType.ValueMember = "Usertype_ID";
        }

        private void dgData_Click(object sender, EventArgs e)
        {
            //EDIT click event Begins
            btnSave.Text = "UPDATE";
            int UserId;
            int columnIndex = dgData.CurrentCell.ColumnIndex;
            UserId = int.Parse(dgData.CurrentRow.Cells["Users_ID"].Value.ToString());


            if (dgData.CurrentRow.Cells[columnIndex].Value.ToString() == "EDIT")
            {
                DataTable dataTable = userBll.SelectUsers(UserId);

                cboUserType.Text = dataTable.Rows[0][0].ToString();
                txtFirstName.Text = dataTable.Rows[0][1].ToString();
                txtLastName.Text = dataTable.Rows[0][2].ToString();
                txtAddress.Text = dataTable.Rows[0][3].ToString();

                string gender = dataTable.Rows[0][4].ToString();
                if (gender == "Male")
                {
                    rdobtnMale.Focus();
                }
                else if (gender == "Female")
                {
                    rdobtnFemale.Focus();
                }
                else if (gender == "Others")
                {
                    rdobtnOthers.Focus();
                }

                txtPhoneNumber.Text = dataTable.Rows[0][5].ToString();
                txtEmail.Text = dataTable.Rows[0][6].ToString();
                txtUserName.Text = dataTable.Rows[0][7].ToString();
                txtPassword.Text = dataTable.Rows[0][8].ToString();

            }

            //Delete click event Begins
            else if (dgData.CurrentRow.Cells[columnIndex].Value.ToString() == "DELETE")
            {
                //displayInfo with interactive messagebox

                DialogResult confirmResult = MessageBox.Show("Are you sure to delete this row?", "confirm Delete?",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    userBll.deleteUsers(UserId);
                    dgData.DataSource = userBll.retrieveUsers();
                    MessageBox.Show("One row is deleted!!!!");

                    //erases the values
                    cboUserType.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNumber.Text = "";
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Any row is not deleted!!!!");

                    //erases the values
                    cboUserType.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNumber.Text = "";
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Hide();
            MAINDASHBOARD main = new MAINDASHBOARD();
            main.ShowDialog();
        }
    }
}
