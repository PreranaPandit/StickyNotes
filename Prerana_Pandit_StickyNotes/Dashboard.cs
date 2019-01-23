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
    public partial class Dashboard : Form
    {
        //properties
        private string username;

        public Dashboard(string username)
        {

            this.username = username;
            InitializeComponent();
        }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void pieChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clears panel
            panel1.Controls.Clear();
            //piechart obtaining through makin objects.
            Piechart pie = new Piechart(lblUsername.Text);
            pie.ShowDialog();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //timer gets enabled on load
            timer1.Enabled = true;
            //assigning labels
            lblUsername.Text = username;

            panel1.Controls.Clear();
            //objects created
            DashboardBLL dash = new DashboardBLL();

            dash._username = lblUsername.Text;
            //selection query retrieved for userId
            string userid = dash.userIDD();
            dash._userid = userid;
            //stickynotes properties retreived
            DataTable dt = dash.titleandcontent2();

            //panel sees while on-loading 
            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                //creating childPanel
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.GreenYellow;
                childPanel.Size = new Size(250, 250);

                //label for id
                Label lblid = new Label();
                lblid.Text = "0" + d;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;

                //label for title
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                lbltitle.Location = new Point(10, 10);
                lbltitle.BackColor = Color.Blue;
                lbltitle.ForeColor = Color.White;

                //combobox;
                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }

                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";
                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                cmbcategory.BackColor = Color.Yellow;

                //textbox of content with multilines
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;

                //button cretated as 'save'
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                btnclick.BackColor = Color.Blue;
                btnclick.ForeColor = Color.White;
                n = n + 1;

                //inner click event for button
                btnclick.Click += (z, a) =>
                {
                    btnclick.Text = "UPDATE";
                    if (MessageBox.Show("Are you Sure you want to Update?", "SAVE", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        //update query 
                        dash.updateContent();
                        MessageBox.Show("Successfully updated!!!..");
                        dt = dash.titleandcontent2();
                        btnclick.Text = "SAVE";
                    }
                    else
                    {

                        MessageBox.Show("Not Updated!");
                    }
                };

                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }
            }

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //object made for Maindashboard
            this.Hide();
            MAINDASHBOARD main = new MAINDASHBOARD();
            main.ShowDialog();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clears panel
            panel1.Controls.Clear();
            DashboardBLL dash = new DashboardBLL();
            dash._username = lblUsername.Text;
            //selecting user
            string userid = dash.userIDD();
            dash._userid = userid;
            //selection query retreived
            DataTable dt = dash.titleandcontent();

            //panel begins for stickyNotes
            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                //childpanel method begins
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.GreenYellow;
                childPanel.Size = new Size(250, 250);

                //label for id
                Label lblid = new Label();
                lblid.Text = "0" + d;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;

                //label for title
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                lbltitle.Location = new Point(10, 10);
                lbltitle.BackColor = Color.Blue;
                lbltitle.ForeColor = Color.White;

                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }

                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";
                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                cmbcategory.BackColor = Color.Yellow;

                //content 
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;

                //button
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                btnclick.BackColor = Color.Blue;
                btnclick.ForeColor = Color.White;
                n = n + 1;
                //inner click event
                btnclick.Click += (z, a) =>
                {
                    btnclick.Text = "UPDATE";
                    if (MessageBox.Show("Are you Sure you want to Update?", "SAVE", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        dash.updateContent();
                        MessageBox.Show("Successfully updated!!!..");
                        dt = dash.titleandcontent();
                        btnclick.Text = "SAVE";
                    }
                    else
                    {

                        MessageBox.Show("Not Updated!");
                    }
                };

                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }

            }

        }

        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create new notes form will be opened
            //clears panel
            panel1.Controls.Clear();
            Stickynote sticky = new Stickynote();
            sticky.ShowDialog();
        }

        private void completedStickyNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //object made
            DashboardBLL dash = new DashboardBLL();
            dash._username = lblUsername.Text;
            //selection query retrieved for userid
            string userid = dash.userIDD();
            dash._userid = userid;
            //selecting completed notes query
            DataTable dt = dash.titleandcontent3();

            //stickynotes created on panel
            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                //childpanel
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.GreenYellow;
                childPanel.Size = new Size(250, 250);

                //label for id
                Label lblid = new Label();
                lblid.Text = "0" + d;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;

                //label for title
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                lbltitle.Location = new Point(10, 10);
                lbltitle.BackColor = Color.Blue;
                lbltitle.ForeColor = Color.White;

                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }

                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";
                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                cmbcategory.BackColor = Color.Yellow;

                //contents through textbox multiline
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;

                //button created
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                btnclick.BackColor = Color.Blue;
                btnclick.ForeColor = Color.White;
                n = n + 1;

                //button inner click event
                btnclick.Click += (z, a) =>
                {
                    btnclick.Text = "UPDATE";
                    if (MessageBox.Show("Are you Sure you want to Update?", "SAVE", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        //upadte query
                        dash.updateContent();
                        MessageBox.Show("Successfully updated");
                        btnclick.Text = "SAVE";
                        dt = dash.titleandcontent3();
                    }
                    else
                    {

                        MessageBox.Show("Not Updated!");
                    }
                };

                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }

            }
        }

        private void incompleteStickyNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //dashboard obtained through class and objects
            DashboardBLL dash = new DashboardBLL();

            dash._username = lblUsername.Text;
            //retreiveing userId through query
            string userid = dash.userIDD();
            dash._userid = userid;
            //incompleted notes query retreived
            DataTable dt = dash.titleandcontent2();

            //stickynotes on panel
            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                //childpanel
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.GreenYellow;
                childPanel.Size = new Size(250, 250);

                //label for id
                Label lblid = new Label();
                lblid.Text = "0" + d;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;

                //label for title
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                lbltitle.Location = new Point(10, 10);
                lbltitle.BackColor = Color.Blue;
                lbltitle.ForeColor = Color.White;

                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }

                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";
                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                cmbcategory.BackColor = Color.Yellow;

                //contents text on multiline
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;

                //button created
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                btnclick.BackColor = Color.Blue;
                btnclick.ForeColor = Color.White;
                n = n + 1;
                //buttton inner click event
                btnclick.Click += (z, a) =>
                {
                    btnclick.Text = "UPDATE";
                    if (MessageBox.Show("Are you Sure you want to Update?", "SAVE", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        //update query begins
                        dash.updateContent();
                        MessageBox.Show("Successfully upadted!!!..");
                        btnclick.Text = "SAVE";
                        dt = dash.titleandcontent2();
                    }
                    else
                    {
                        MessageBox.Show("Not Updated!");
                    }
                };

                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }
            }
        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //encapsulation
            DashboardBLL dash = new DashboardBLL();

            dash._username = lblUsername.Text;
            //userId retreived
            string userid = dash.userIDD();
            dash._userid = userid;
            //selection query for searching by date
            DataTable dt = dash.titleandcontent4();

            //notes created on panel
            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                //childPannel
                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.GreenYellow;
                childPanel.Size = new Size(250, 250);

                //label for ID
                Label lblid = new Label();
                lblid.Text = "0" + d;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;

                //label for title
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                lbltitle.Location = new Point(10, 10);
                lbltitle.BackColor = Color.Blue;
                lbltitle.ForeColor = Color.White;

                //lblDATE
                Label lbldate = new Label();
                lbldate.Text = dt.Rows[n][2].ToString();
                lbldate.Location = new Point(10, 205);
                lbldate.Visible = true;

                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }

                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";
                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                cmbcategory.BackColor = Color.Yellow;

                //content--multiline
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;

                //button created
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                btnclick.BackColor = Color.Blue;
                btnclick.ForeColor = Color.White;
                n = n + 1;

                //button inner click event
                btnclick.Click += (z, a) =>
                {
                    btnclick.Text = "UPDATE";
                    if (MessageBox.Show("Are you Sure you want to Update?", "SAVE", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        //update query 
                        dash.updateContent();
                        MessageBox.Show("Successfully updated!!!!..");
                        btnclick.Text = "SAVE";
                        dt = dash.titleandcontent4();
                    }
                    else
                    {

                        MessageBox.Show("Not Updated!");
                    }
                };

                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(lbldate);
                childPanel.Controls.Add(txtcontent);

                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            DashboardBLL dash = new DashboardBLL();
            dash._title = tstxt1.Text.ToString();
            dash._username = lblUsername.Text;
            string userid = dash.userIDD();
            dash._userid = userid;
            DataTable dt = dash.titleandcontent5();


            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {

                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.AliceBlue;
                childPanel.Size = new Size(250, 250);
                Label lblid = new Label();
                lblid.Text = dt.Rows[n][2].ToString(); ;
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();

                lbltitle.Location = new Point(10, 10);
                ComboBox cmbcategory = new ComboBox();
                dash._StickyID = int.Parse(lblid.Text);
                DataTable dt1 = dash.getcategory();
                DataTable dt2 = dash.getcategory1();

                for (int i = 0; i < dt2.Rows.Count; i++)

                {
                    DataRow dataRow = dt1.NewRow();
                    dataRow["Categories_Name"] = dt2.Rows[i][1].ToString();
                    dataRow["Categories_ID"] = dt2.Rows[i][0].ToString();
                    dt1.Rows.Add(dataRow);
                }


                cmbcategory.DataSource = dt1;
                cmbcategory.DisplayMember = "Categories_Name";

                cmbcategory.ValueMember = "Categories_ID";
                cmbcategory.Location = new Point(120, 10);
                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();


                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;
                Button btnclick = new Button();
                btnclick.Text = "SAVE";
                btnclick.Location = new Point(170, 200);
                n = n + 1;
                //inner click event
                btnclick.Click += (z, a) =>
                {
                    if (MessageBox.Show("Are you Sure you want to Save?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        dash._categoryid = int.Parse(cmbcategory.SelectedValue.ToString());
                        dash._title = lbltitle.Text;
                        dash._content = txtcontent.Text;
                        dash.updateContent();
                        MessageBox.Show("Successfully saved");
                        panel1.Controls.Clear();
                    }
                    else
                    {

                        MessageBox.Show("Not Updated!");
                    }



                };
                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(cmbcategory);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }
            }
        }

        private void technicalSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clears panel
            panel1.Controls.Clear();
            //help form opens through class and objects
            Help help = new Help();
            help.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            DashboardBLL dash = new DashboardBLL();
            dash._title = tstxt2.Text.ToString();
            dash._username = lblUsername.Text;
            string userid = dash.userIDD();
            dash._userid = userid;
            DataTable dt = dash.titleandcontent5();


            int x = 10, y = 50;
            int d = 1;
            int n = 0;
            for (int s = 0; s < dt.Rows.Count; s++)
            {

                Panel childPanel = new Panel();
                childPanel.Location = new Point(x, y);
                childPanel.BackColor = Color.AliceBlue;
                childPanel.Size = new Size(250, 250);
                Label lblid = new Label();
                lblid.Text = dt.Rows[n][2].ToString();
                lblid.Location = new Point(10, 220);
                lblid.Visible = true;
                Label lbltitle = new Label();
                lbltitle.Text = dt.Rows[n][0].ToString();
                dash._title = lbltitle.Text;
                lbltitle.Location = new Point(10, 10);

                TextBox txtcontent = new TextBox();
                txtcontent.Text = dt.Rows[n][1].ToString();
                dash._content = txtcontent.Text;
                txtcontent.Size = new Size(200, 150);
                txtcontent.Location = new Point(10, 40);
                txtcontent.Multiline = true;
                Button btnclick = new Button();
                btnclick.Text = "DELETE";
                btnclick.Location = new Point(170, 200);
                n = n + 1;
                //inner click event
                btnclick.Click += (z, a) =>
                {


                    if (MessageBox.Show("Are you Sure you want to delete?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {

                        dash._content = txtcontent.Text;
                        dash.deletesticky();
                        MessageBox.Show("Successfully Deleted");
                        panel1.Controls.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Not deleted!");
                    }



                };
                //adding to Child Panel
                childPanel.Controls.Add(lblid);
                childPanel.Controls.Add(lbltitle);
                childPanel.Controls.Add(txtcontent);
                childPanel.Controls.Add(btnclick);
                //adding child panel to parent panel
                panel1.Controls.Add(childPanel);
                x = x + childPanel.Width + 10;
                d = d + 1;
                if (x > 1300)
                {
                    x = 10;
                    y = y + childPanel.Width + 10;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //locating current time and date on dashboard"
            lblTime.Text = DateTime.Now.ToString("yyyy/MM/dd        hh:mm:ss");
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
