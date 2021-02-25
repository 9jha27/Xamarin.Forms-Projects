using ContactBookApp.iOS.Persistence;
using ContactBookApp.Persistence;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBookApp.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb //implements the ISQLiteDb interface
    {
        public SQLiteAsyncConnection GetConnection() //gets connection established in the interface
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);

        }
    }
}