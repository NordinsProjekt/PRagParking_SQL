using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Prag
{
    public static class DatabasHantering
    {
        private static string connectionString = "Din databas sträng";
        public static string ConnectionString
        {
            set { connectionString = value; }
            get { return connectionString; }
        }
          
        public static string[] GetCSVFromQuerySQL(SQLQuery sq, string separator)
        {
            StringBuilder sb = new StringBuilder();
            using (sq.conn)
            {
                sq.conn.Open();
                using SqlDataReader rdr = sq.com.ExecuteReader();
                {
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (i + 1 == rdr.FieldCount)
                                sb.Append(rdr.GetValue(i) + "\n");
                            else
                                sb.Append(rdr.GetValue(i) + separator);
                        }
                    }
                }
            }
            //Tar bort sista enterslaget och sedan splittar till array.
            string temp = sb.ToString().Substring(0, sb.ToString().Length - 1);
            string[] resultat = temp.Split("\n");
            return resultat;
        }
       
        public static string GetStringFromQuery(SQLQuery sq, string separator)
        {
            using (sq.conn)
            {
                sq.conn.Open();
                using SqlDataReader rdr = sq.com.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (i + 1 == rdr.FieldCount)
                            sb.Append(rdr.GetValue(i) + "\n");
                        else
                            sb.Append(rdr.GetValue(i) + separator);
                    }
                }
                //Tar bort det sista ENTER slaget.
                if (sb.Length <= 0)
                    return "";
                else
                    return sb.ToString().Substring(0, sb.Length - 1);
            }
        }
        public static int SendSqlQuery(SQLQuery sq)
        {
            int rows = 0;
            //Här skickas en fråga rakt in i databasen.
            //Med parametrar
            using (sq.conn)
            {
                sq.conn.Open();
                rows = sq.com.ExecuteNonQuery();
            }
            return rows;
        }
        public static int SendSqlQuery(string sql)
        {
            int rows;
            using SqlConnection conn = new SqlConnection(connectionString);
            {
                SqlCommand comm = conn.CreateCommand();
                {
                    conn.Open();
                    comm.CommandText = sql;
                   rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }
    }
}
