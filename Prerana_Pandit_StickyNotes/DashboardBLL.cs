using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //INHERITANCE performed through connection of DBCONNECTION Class--OOP
   public  class DashboardBLL:Dbconnection
    {
        //properties
        private string Username;
        private string Userid;
        private string Title;
        private string Content;
        private int Categoryid;
        private int StickyID;

        public DashboardBLL()
        {

        }

     

        //getter and setter used in all labels
        public int _categoryid
        {
            get { return Categoryid; }
            set { Categoryid = value; }
        }

        public string _username
        {
            get { return Username; }
            set { Username = value; }

        }
        public string _userid
        {
            get { return Userid; }
            set { Userid = value; }
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
        public int _StickyID
        {
            get { return StickyID; }
            set { StickyID = value; }
        }

        //selecting userId from Users query reffered wuth exception handeling
        public string userIDD()
        {
            string query = "select  Users_ID from Users where Username = '" + Username + "';";
            DataTable datatable = null;
            try
            {
                datatable = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }

            //userName retrieved through rows(0,0)
            string userid = datatable.Rows[0][0].ToString();
            return userid;
        }

        //selecting title and content from stickynotes through exception handeling
        public DataTable titleandcontent()
        {
            String query = "select Title,Content_Of_Notes,StickyNotes_ID from StickyNotes where Users_ID = " + Userid + ";";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;
        }



        //selecting title and contents of notes from notes sticked by exception handeling performed
        public DataTable titleandcontent2()
        {
            String query = "select Title,Content_Of_Notes,StickyNotes_ID from StickyNotes where IsStickied = +1 and Users_ID= " + Userid + ";";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;
        }

        //selection query for title and contents where notes are completed by performing exception handeling
        public DataTable titleandcontent3()
        {
            String query = "select Title,Content_Of_Notes,StickyNotes_ID from StickyNotes where IsCompleted = +1 and Users_ID= " + Userid + ";";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;
        }

        //update query for stickyNotes on dashboard with exception handeling
        public void updateContent()
        {
            String query = "update StickyNotes set Content_of_Notes = '" + Content + "',Categories_ID=" + Categoryid + " where Title = '" + Title + "';";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
        }

        //For unit Testing
        public int updateNotesCount()
        {
            DataTable dt = null;
            string query = "select COUNT(Categories_ID) from StickyNotes";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }


        //selection query of title and contents,date of stickynotes with exception handeling 
        public DataTable titleandcontent4()
        {
            String query = "select Title,Content_of_Notes,Date_Created,StickyNotes_ID from StickyNotes where Users_ID = " + Userid + " order by Date_Created desc;";
            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;

        }

        //selection query of title, content from notes from its title
        public DataTable titleandcontent5()
        {
            String query = "select Title,Content_of_Notes,StickyNotes_ID from StickyNotes where Title = '" + Title + "' and Users_ID= " + Userid + ";";

            DataTable dt = null;
            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;

        }

        //delete query from stickyNote with title by exception handeling
        public void deletesticky()
        {
            String query = "delete from StickyNotes where Users_ID= " + Userid + " and Title = '" + Title + "';";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
        }


        //category obtaining query through exception handeling
        public DataTable getcategory()
        {
            string Categoryid = "select Categories_ID from StickyNotes where StickyNotes_ID=" + StickyID + ";";
            DataTable dt3 = Retrieve(Categoryid);
            Categoryid = dt3.Rows[0][0].ToString();
            string Categoryname = "select * from Categories where Categories_ID=" + Categoryid + ";";
            DataTable dt4 = null;

            try
            {
                dt4 = Retrieve(Categoryname);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt4;
        }

        //getcategory2
        public DataTable getcategory1()
        {
            string Categoryid = "select Categories_ID from StickyNotes where StickyNotes_ID=" + StickyID + ";";
            DataTable dt3 = Retrieve(Categoryid);
            Categoryid = dt3.Rows[0][0].ToString();
            string query = "select* from Categories where Categories_ID!='" + Categoryid + "';";

            DataTable dt = null;

            try
            {
                dt = Retrieve(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
            return dt;

        }


    }
}
