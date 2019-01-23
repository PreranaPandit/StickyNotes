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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        
        //information hiding (encapsulation)--OOP 
        CategoriesBLL category = new CategoriesBLL();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation done for all labels from category form:

            if (txtCategoryType.Text == "")
            {
                MessageBox.Show("Ente the category type!!..");
                txtCategoryType.Focus();
                return;
            }

            else
            {
                //variables

                string categoryType;

                categoryType = txtCategoryType.Text;


                //getter and setter


                category._category = categoryType;


                //SAVE and UPDATE code begins 
                //if condition for SAVE
                if (btnSave.Text == "SAVE")
                {
                    category.insertCategory();
                    MessageBox.Show("Rows are inserted successfully!!");

                    dgData.DataSource = category.retrieveCategory();
                    //erases the input values

                    txtCategoryType.Text = "";

                }

                //update click event through if-condition
                else if (btnSave.Text == "UPDATE")
                {
                    int categoryId = int.Parse(dgData.CurrentRow.Cells["Categories_ID"].Value.ToString());

                    //update code retrieved form BLL
                    category.updateCategory(categoryId);
                    MessageBox.Show("Rows are updated successfully by user!!");
                    //UPDATE changes to SAVE again
                    btnSave.Text = "SAVE";

                    dgData.DataSource = category.retrieveCategory();
                    //erases the updated values

                    txtCategoryType.Text = "";

                }


            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            //Select query retrieved while load
            dgData.DataSource = category.retrieveCategory();
        }

        private void dgData_Click(object sender, EventArgs e)
        {
            //EDIT click event Begins
            btnSave.Text = "UPDATE";

            int categoryId;
            int columnIndex = dgData.CurrentCell.ColumnIndex;
            categoryId = int.Parse(dgData.CurrentRow.Cells["Categories_ID"].Value.ToString());

            if (dgData.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
            {
                DataTable dataTable = category.SelectCategory(categoryId);

                txtCategoryType.Text = dataTable.Rows[0][0].ToString();
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
                    category.deleteCategory(categoryId);
                    dgData.DataSource = category.retrieveCategory();
                    MessageBox.Show("One row is deleted successfully!!!!");
                    txtCategoryType.Text = "";
                }
                else
                {
                    MessageBox.Show("Any row is not deleted!!!!");
                    txtCategoryType.Text = "";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //back to dashboard event through making objects
            this.Hide();
            MAINDASHBOARD main = new MAINDASHBOARD();
            main.ShowDialog();
        }
    }
}
