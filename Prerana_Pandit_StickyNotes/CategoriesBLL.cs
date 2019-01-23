using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerana_Pandit_StickyNotes
{
    //INHERITANCE performed through connection of DBCONNECTION Class--OOP
   public  class CategoriesBLL : Dbconnection
    {
        //properties
        private int categoryId;
        private string Category;


        public CategoriesBLL()
        {
            
        }

        //getter and setter for all labels
        public int _categoryId
        {
            get { return categoryId; }
            set { this.categoryId = value; }
        }

        public string _category
        {
            get { return Category; }
            set { Category = value; }
        }



        //insertion query of category form by using exception handeling
        public void insertCategory()
        {
            String query;
            query = "insert into Categories(Categories_Name)values('" + Category + "')";
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }

        }
        
        //for unite testing
        public int insertCategoriesTest()
        {
            DataTable dt = null;
            string query = "select COUNT(Categories_Name) from Categories";
            dt = Retrieve(query);
            return int.Parse(dt.Rows[0][0].ToString());
        }


        //selection query of category form by using exception handeling
        public DataTable retrieveCategory()
        {
            string query;
            query = "select categories_ID, Categories_Name from  Categories";
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


        //update query of category form by using exception handeling
        public void updateCategory(int categoryId)
        {
            string updateUsers;
            updateUsers = "Update Categories set Categories_Name='" + Category + "' where Categories_ID = " + categoryId;
            try
            {
                Manipulate(updateUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
        }


        //selection query from data grid view table by involving exception handeling concept 
        public DataTable SelectCategory(int categoryId)
        {
            string query;
            query = "select Categories_Name from Categories where Categories_ID = " + categoryId;
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


        //delete query form data grid view bu involving exception handeling concept
        public void deleteCategory(int categoryId)
        {
            string query;
            query = "delete from Categories where Categories_ID =" + categoryId;
            try
            {
                Manipulate(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excetion caught{ex}");
            }
        }

    }
}
