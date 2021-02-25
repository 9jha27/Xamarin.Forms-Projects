using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactBookApp.Droid.Persistence;
using ContactBookApp.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBookApp.Droid.Persistence
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