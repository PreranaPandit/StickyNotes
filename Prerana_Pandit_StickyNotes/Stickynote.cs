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
    public partial class Stickynote : Form
    {
        public Stickynote()
        {
            InitializeComponent();
        }

        //dbconnection
        Dbconnection cate = new Dbconnection();

        //encapsulation 
        stickyBLL sticky = new stickyBLL();

        int Isstickied, Iscompleted;


        private void btn1_Click(object sender, EventArgs e)
        {
            if (chckbx1.Checked == true & chckbx2.Checked == false)
            {

                Isstickied = 1;
                Iscompleted = 0;

            }
            else if (chckbx1.Checked == false & chckbx2.Checked == true)
            {
                Isstickied = 0;
                Iscompleted = 1;

            }

            else if (chckbx1.Checked == true & chckbx2.Checked == true)
            {
                Isstickied = 1;
                Iscompleted = 1;


            }

            else
            {
                Isstickied = 0;
                Iscompleted = 0;
            }
            DateTime todayDate = DateTime.Now;
            sticky._userid = txt1.Text;
            sticky._categoriesid = cmb1.SelectedValue.ToString();
            sticky._date = todayDate.ToString();
            sticky._title = txt2.Text;
            sticky._content = txt3.Text;
            sticky._iscompleted = Iscompleted;
            sticky._isstickied = Isstickied;
            sticky.addSticky();
            MessageBox.Show("SAVED!!");
            txt1.Text = txt2.Text = txt3.Text = "";
        }

        private void Stickynote_Load(object sender, EventArgs e)
        {
            //query for category    
            string query;
            query = "select * from Categories";
            DataTable dt1 = cate.Retrieve(query);
            cmb1.DataSource = dt1;
            cmb1.DisplayMember = "Categories_Name";
            cmb1.ValueMember = "Categories_ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt1.Text))
            {
                int UserID = int.Parse(txt1.Text);
                DataTable dataTable = sticky.getName(UserID);

                if (dataTable.Rows.Count > 0)
                {
                    lbl1.Text = dataTable.Rows[0][0].ToString();
                    lbl2.Text = dataTable.Rows[0][1].ToString();
                    btn1.Enabled = true;
                }
                else
                {
                    lbl1.Text = lbl2.Text = "null";
                    btn1.Enabled = false;
                }
            }
        }
    }
}
