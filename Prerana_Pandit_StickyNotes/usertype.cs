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
    public partial class usertype : Form
    {
        public usertype()
        {
            InitializeComponent();
        }

        //information hiding (encapsulation)--OOP

        UserTypeBLL userTypeBll = new UserTypeBLL();

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation done for userTypeName;
            if (txtUserTypeName.Text == "")
            {
                MessageBox.Show("please enter the usertype name!!");
                txtUserTypeName.Focus();
                return;
            }

            //assigning
            string userTypeName;

            //labelname identified
            userTypeName = txtUserTypeName.Text;

            //setter and getter

            userTypeBll._userTypeName = userTypeName;

            //--if condition for either SAVE and UPDATE steps
            if (btnSave.Text == "SAVE")
            {
                //insertquery from BLL
                userTypeBll.insertuserType();
                MessageBox.Show("Rows are inserted!!");
                //retrieved on datagrid view
                dgData.DataSource = userTypeBll.retrieveUserType();
                txtUserTypeName.Text = "";
            }
            //UPDATE Code begins
            else if (btnSave.Text == "UPDATE")
            {
                int userTypeId;
                userTypeId = int.Parse(dgData.CurrentRow.Cells["userTypeId"].Value.ToString());
                //update query retrived from BLL
                userTypeBll.updateUserType(userTypeId);
                MessageBox.Show("Rows are updated by the user!!!!");
                txtUserTypeName.Text = "";
                btnSave.Text = "SAVE";
                dgData.DataSource = userTypeBll.retrieveUserType();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MAINDASHBOARD main = new MAINDASHBOARD();
            main.ShowDialog();
        }

        private void usertype_Load(object sender, EventArgs e)
        {
            //values retrieved on datagrid view
            dgData.DataSource = userTypeBll.retrieveUserType();
        }

        private void dgData_Click(object sender, EventArgs e)
        {
            //EDIT click event Begins
            btnSave.Text = "UPDATE";

            int userTypeId;
            int columnIndex = dgData.CurrentCell.ColumnIndex;
            userTypeId = int.Parse(dgData.CurrentRow.Cells["Usertype_ID"].Value.ToString());

            if (dgData.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
            {
                DataTable dataTable = userTypeBll.selectUserType(userTypeId);

                txtUserTypeName.Text = dataTable.Rows[0][0].ToString();
            }

            //Delete click event Begins
            else if (dgData.CurrentRow.Cells[columnIndex].Value.ToString() == "Delete")
            {
                //displayInfo with interactive messagebox

                DialogResult confirmResult = MessageBox.Show("Are you sure to delete this row?", "confirm Delete?",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    //delete query from BLL
                    userTypeBll.deleteUserType(userTypeId);
                    dgData.DataSource = userTypeBll.retrieveUserType();
                    MessageBox.Show("One row is deleted successfully!!!!");
                    txtUserTypeName.Text = "";
                }
                else
                {
                    MessageBox.Show("Any row is not deleted!!!!");
                    txtUserTypeName.Text = "";
                }
            }
        }
    }
}
