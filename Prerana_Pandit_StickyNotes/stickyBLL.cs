using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //inheritance applied--oop pillar used
   public class stickyBLL:Dbconnection
    {
        //properties
        private string Userid, Categoriesid, Date, Title, Content;
        int Isstickied, Iscompleted;

        //getter and setter
        public string _userid
        {
            get { return Userid; }
            set { Userid = value; }
        }
        public string _categoriesid
        {
            get { return Categoriesid; }
            set { Categoriesid = value; }
        }

        public string _date
        {
            get { return Date; }
            set { Date = value; }
        }

        public string _title
        {
            get { return Title; }
            set { Title = value; }
        }

        public string _content
        {
            get { return Content; }
            set { Content = value; }
        }
        public int _isstickied
        {
            get { return Isstickied; }
            set { Isstickied = value; }
        }
        public int _iscompleted
        {
            get { return Iscompleted; }
            set { Iscompleted = value; }
        }

        //get Name query through selection event
        public DataTable getName(int UserID)
        {
            String query = "select FirstName,LastName from Users where Users_ID = " + UserID + ";";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }
            return dt;
        }

        //insert sticky notes on databse;
        public void addSticky()
        {
            string query;
            query = "insert into StickyNotes(Users_ID,Categories_ID,Date_Created,Title,Content_Of_Notes,Isstickied,Iscompleted)"
                +"values('" + Userid + "'," + Categoriesid + ",'" + Date + "','" + Title + "','" + Content + "'," + 
                Isstickied + "," + Iscompleted + ");";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught{ex}");
            }

        }

        //for unit testing
        public int addStickyNote_count()
        {
            DataTable dt = null;
            string query = "select COUNT(Users_ID) from StickyNotes";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }
    }
}
