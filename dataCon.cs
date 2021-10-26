using Community.CsharpSqlite.SQLiteClient;

namespace Cash_Calc_v2
{
    class dataCon
    {
        SqliteConnection connection = new SqliteConnection("Data Source = data.db");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) connection.Close();
        }
        public SqliteConnection getConnection()
        {
            return connection;
        }
    }
}
