using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClientVibration
{
    public static class Constants
    {
        private const string DBFileName = "SQLite_test_client.db3";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get { return Path.Combine("C:\\Git\\MainClient\\MainClientVibration\\", DBFileName); }
        }
    }
}
