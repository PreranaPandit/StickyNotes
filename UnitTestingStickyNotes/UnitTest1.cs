using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prerana_Pandit_StickyNotes;

namespace UnitTestingStickyNotes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void loginTesting()
        {
            LoginBLL loginbll = new LoginBLL();
            loginbll._username = "prerana";
            loginbll._password = "prerana";
            bool actualResult = loginbll.checkUser();
            bool ExpectedRuslt = true;
            Assert.AreEqual(ExpectedRuslt,actualResult);
        }

        [TestMethod]
        public void loginTest_for_invalid_user()
        {
            LoginBLL loginbll = new LoginBLL();
            loginbll._username = "Test";
            loginbll._password = "Test";
            bool actualResult = loginbll.checkUser();
            bool ExpectedRuslt = true;
            Assert.AreEqual(ExpectedRuslt, actualResult);
        }


        [TestMethod]
        public void addStickyNote_test()
        {
            stickyBLL stickybll = new stickyBLL();
            int expectedResult = stickybll.addStickyNote_count();
            stickybll._userid = "2";
            stickybll._title = "testTitle";
            stickybll._isstickied = 1;
            stickybll._iscompleted = 1;
            stickybll._date = "2018/07/19";
            stickybll._content = "Test Content";
            stickybll._categoriesid = "2";
            int actualResult = stickybll.addStickyNote_count();
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void inserUserCount_test() {
            UserEntryBLL userEntry = new UserEntryBLL();
            int ExpectedRusult = userEntry.insertUsers_Count();
            userEntry._userTypeId = 2;
            userEntry._firstName = "Mohammed";
            userEntry._lastName = "Husen";
            userEntry._gender = "Male";
            userEntry._address = "Teku";
            userEntry._email = "Mohammed@gmail.com";
            userEntry._Username = "parrot";
            userEntry._Password = "parrot";
            userEntry._phoneNumber = "9851187651";
            int actualResult = userEntry.insertUsers_Count();
            Assert.AreEqual(ExpectedRusult, actualResult);
        }


        [TestMethod]
        public void inserUsersCount_test()
        {
            UserEntryBLL userEntry = new UserEntryBLL();
            int ExpectedRusult = userEntry.insertUsers_Count() +1;
            userEntry._userTypeId = 2;
            userEntry._firstName = "Mohammed";
            userEntry._lastName = "Husen";
            userEntry._gender = "Male";
            userEntry._address = "Teku";
            userEntry._email = "Mohammed@gmail.com";
            userEntry._Username = "parrot";
            userEntry._Password = "parrot";
            userEntry._phoneNumber = "9851187651";
            int actualResult = userEntry.insertUsers_Count();
            Assert.AreEqual(ExpectedRusult, actualResult);
        }



        [TestMethod]
        public void insertCategoriesTesting()
        {
            CategoriesBLL category = new CategoriesBLL();
            int expectedResult = category.insertCategoriesTest() + 1;
            string categoryName = "Demo";
            category._category = categoryName;
            category.insertCategory();
            int actualResut = category.insertCategoriesTest();
            Assert.AreEqual(expectedResult,actualResut);

        }


        [TestMethod]
        public void delete_user_testing()
        {
            UserEntryBLL userDelete = new UserEntryBLL();
            int ExpectedResutl = userDelete.deleteUserCount() - 1;
            int userId = 1;
            userDelete.deleteUsers(userId);
            int actualResult = userDelete.deleteUserCount();
            Assert.AreEqual(ExpectedResutl,actualResult);
        }


        [TestMethod]
        public void update_user_testing()
        {
            UserEntryBLL userUpdate = new UserEntryBLL();
            int ExpectedResutl = userUpdate.updateUserCount();
            int userId = 1;
            userUpdate.updateUsers(userId);
            int actualResult = userUpdate.updateUserCount();
            Assert.AreEqual(ExpectedResutl, actualResult);
        }



        [TestMethod]
        public void update_notes_testing()
        {
            DashboardBLL notesUpdate = new DashboardBLL();
            int ExpectedResutl = notesUpdate.updateNotesCount();
           
            notesUpdate.updateContent();
            int actualResult = notesUpdate.updateNotesCount();
            Assert.AreEqual(ExpectedResutl, actualResult);
        }

     


    }
}
