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
    public partial class Piechart : Form
    {
        //properties
        private string username;

        public Piechart(string username)
        {

            this.username = username;
            InitializeComponent();
        }

        public Piechart()
        {
            InitializeComponent();
        }

        //class and object method applied
        PichartBLL piechart = new PichartBLL();

        //todays statistic
        private void Todaychart()
        {
            string todayDate = DateTime.Now.ToString("yyyy/MM/dd");

            DataTable dt = piechart.NoteCounttodaydate(todayDate);
            DataTable dts = piechart.NoteCounttodaydate2(todayDate);
            float x, y;
            float xx, yy;
            x = float.Parse(dt.Rows[0][0].ToString());
            y = float.Parse(dts.Rows[0][0].ToString());
            if (x <= 0)
            {
                xx = 0;
            }
            else
            {
                xx = ((x / (x + y)) * 100);
            }
            if (y <= 0)
            {
                yy = 0;
            }
            else
            {
                yy = ((y / (x + y)) * 100);
            }
            bool isData = true;
            if (x > 0 && y > 0)
            {
                ct1.Series["CurrentDate"].Points.AddXY("Completed", x);
                ct1.Series["CurrentDate"].Points.AddXY("Incompleted", y);
            }

            else if (x > 0 && y < 1)
            {
                ct1.Series["CurrentDate"].Points.AddXY("Completed", x);
            }

            else if (x < 1 && y > 0)
            {
                ct1.Series["CurrentDate"].Points.AddXY("Incompleted", y);
            }

            else
            {
                ct1.Series["CurrentDate"].Points.AddXY("No data", 0);
                isData = false;
            }

            if (isData)
            {
                lbl1.Text = "Completed :" + String.Format("{0:0.00}", xx) + "%";
                lbl2.Text = "Incompleted : " + String.Format("{0:0.00}", yy) + "%";
                ct1.Titles.Add("TODAY");
            }

            else
            {
                lbl1.Text = "";
                lbl2.Text = "";
                ct1.Titles.Add("No data to evaluate");
            }
        }

        //weekly statistics
        private void WeekChart()
        {
            string todayDate = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
            string nowdate = DateTime.Now.ToString("yyyy/MM/dd");
            DataTable dt = piechart.NoteCountweekdate(nowdate, todayDate);
            DataTable dts = piechart.NoteCountweekdate2(todayDate, nowdate);
            float x, y, xx, yy;
            x = float.Parse(dt.Rows[0][0].ToString());
            y = float.Parse(dts.Rows[0][0].ToString());
            if (x <= 0)
            {
                xx = 0;
            }
            else
            {
                xx = ((x / (x + y)) * 100);
            }
            if (y <= 0)
            {
                yy = 0;
            }
            else
            {
                yy = ((y / (x + y)) * 100);
            }
            bool isData = true;
            if (x > 0 && y > 0)
            {
                ct2.Series["OneWeek"].Points.AddXY("Completed", x);
                ct2.Series["OneWeek"].Points.AddXY("Incompleted", y);
            }

            else if (x > 0 && y < 1)
            {
                ct2.Series["OneWeek"].Points.AddXY("Completed", x);
            }

            else if (x < 1 && y > 0)
            {
                ct2.Series["OneWeek"].Points.AddXY("Incompleted", y);
            }

            else
            {
                ct2.Series["OneWeek"].Points.AddXY("No data", 0);
                isData = false;
            }

            if (isData)
            {
                lbl3.Text = "Completed :" + String.Format("{0:0.00}", xx) + "%";
                lbl4.Text = "Incompleted : " + String.Format("{0:0.00}", yy) + "%";
                ct2.Titles.Add("THIS WEEK");
            }

            else
            {
                lbl3.Text = "";
                lbl4.Text = "";
                ct2.Titles.Add("No data to evaluate");
            }
        }

        //monthly statistics
        private void MonthChart()
        {
            string todayDate = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
            string nowdate = DateTime.Now.ToString("yyyy/MM/dd");

            DataTable dt = piechart.NoteCountmonthdate(nowdate, todayDate);
            DataTable dts = piechart.NoteCountmonthdate2(nowdate, todayDate);
            float x, y, xx, yy;
            x = float.Parse(dt.Rows[0][0].ToString());
            y = float.Parse(dts.Rows[0][0].ToString());
            if (x <= 0)
            {
                xx = 0;
            }
            else
            {
                xx = ((x / (x + y)) * 100);
            }
            if (y <= 0)
            {
                yy = 0;
            }
            else
            {
                yy = ((y / (x + y)) * 100);
            }
            bool isData = true;
            if (x > 0 && y > 0)
            {
                ct3.Series["OneMonth"].Points.AddXY("Completed", x);
                ct3.Series["OneMonth"].Points.AddXY("Incompleted", y);
            }

            else if (x > 0 && y < 1)
            {
                ct3.Series["OneMonth"].Points.AddXY("Completed", x);
            }

            else if (x < 1 && y > 0)
            {
                ct3.Series["OneMonth"].Points.AddXY("Incompleted", y);
            }

            else
            {
                ct3.Series["OneMonth"].Points.AddXY("No data", 0);
                isData = false;
            }

            if (isData)
            {
                lbl5.Text = "Completed :" + String.Format("{0:0.00}", xx) + "%";
                lbl6.Text = "Incompleted : " + String.Format("{0:0.00}", yy) + "%";
                ct3.Titles.Add("THIS MONTH");
            }

            else
            {
                lbl5.Text = "";
                lbl6.Text = "";
                ct3.Titles.Add("No data to evaluate");
            }
        }

        //yearly statistics
        private void Yearchart()
        {
            string todayDate = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            string nowdate = DateTime.Now.ToString("yyyy/MM/dd");
            DataTable dt = piechart.NoteCountyeardate(nowdate, todayDate);
            DataTable dts = piechart.NoteCountyeardate2(nowdate, todayDate);
            float x, y, xx, yy;
            x = float.Parse(dt.Rows[0][0].ToString());
            y = float.Parse(dts.Rows[0][0].ToString());
            if (x <= 0)
            {
                xx = 0;
            }
            else
            {
                xx = ((x / (x + y)) * 100);
            }
            if (y <= 0)
            {
                yy = 0;
            }
            else
            {
                yy = ((y / (x + y)) * 100);
            }
            bool isData = true;
            if (x > 0 && y > 0)
            {
                ct4.Series["Oneyear"].Points.AddXY("Completed", x);
                ct4.Series["Oneyear"].Points.AddXY("Incompleted", y);
            }

            else if (x > 0 && y < 1)
            {
                ct4.Series["Oneyear"].Points.AddXY("Completed", x);
            }

            else if (x < 1 && y > 0)
            {
                ct4.Series["Oneyear"].Points.AddXY("Incompleted", y);
            }

            else
            {
                ct4.Series["Oneyear"].Points.AddXY("No data", 0);
                isData = false;
            }

            if (isData)
            {
                lbl7.Text = "Completed :" + String.Format("{0:0.00}", xx) + "%";
                lbl8.Text = "Incompleted : " + String.Format("{0:0.00}", yy) + "%";
                ct4.Titles.Add("THIS YEAR");
            }

            else
            {
                lbl7.Text = "";
                lbl8.Text = "";
                ct4.Titles.Add("No data to evaluate");
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Piechart_Load(object sender, EventArgs e)
        {
            //on load 
            lblusername.Text = username;
            piechart._username = lblusername.Text;
            Todaychart();
            WeekChart();
            MonthChart();
            Yearchart();
        }

        private void ct4_Click(object sender, EventArgs e)
        {

        }

        private void lblusername_Click(object sender, EventArgs e)
        {

        }
    }
}
