using LibrarySystem.Helpers;
using System.Data;
using System.Data.SQLite;

namespace LibrarySystem.Database
{
    public static class SQLiteHelper
    {
        private static SQLiteConnection sQLiteConnection;

        private static SQLiteConnection DbConnection()
        {
            sQLiteConnection = new SQLiteConnection(BaseHelper.GetSQLiteConnectionString());
            sQLiteConnection.Open();
            return sQLiteConnection;
        }

        public static void ExecuteSQLiteScript(string SQLite)
        {
            using (SQLiteConnection myConnection = DbConnection())
            {
                SQLiteCommand oCmd = new SQLiteCommand(SQLite, myConnection);
                oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public static DataTable ExecuteSQLiteCommand(string SQLite)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection myConnection = DbConnection())
            {
                SQLiteCommand command = new SQLiteCommand(SQLite, myConnection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);

                da.Fill(dt);
                myConnection.Close();
                da.Dispose();
            }

            return dt;
        }
    }
}