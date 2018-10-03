using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.Common;

namespace SQL_Test
{
    public static class Globals
    {
        public static List<Adviser> adviserList;
        public static List<Adviser> cmbAdviserList;
    }

    class DBFunctions
    {
        public SqlConnection dbConn;

        private void OpenDB()
        {
            try
            {
                Debug.WriteLine("Connecting to Database ...");
                dbConn = new SqlConnection("Data Source=DESKTOP-939S9AC;Initial Catalog=TestDatabase;Integrated Security=True");
                dbConn.Open();
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error : " + e.Message);
            }
        }

        public void GetTestTable()
        {
            Globals.adviserList = new List<Adviser>();
            Globals.cmbAdviserList = new List<Adviser>();

            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "SELECT * FROM TestTable";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int pid = reader.GetInt32(2);

                        Adviser newAdviser = new Adviser(id, name, pid);
                        Globals.adviserList.Add(newAdviser);
                        Globals.cmbAdviserList.Add(newAdviser);
                    }
                    reader.NextResult();
                }
                else
                {
                    Debug.WriteLine("Error : Empty Table");
                }
            }
        }
        public void EditTestTableRecord(Adviser adv)
        {
            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "UPDATE TestTable SET colName = '" + adv.name + "', colPID = " + adv.pid + " WHERE id = " + adv.id;
            Debug.WriteLine(sqlQuery.CommandText);
            sqlQuery.ExecuteNonQuery();
        }
    }

    public class Adviser
    {
        public int id;
        public string name;
        public int pid;

        public Adviser(int id, string name, int pid)
        {
            this.id = id;
            this.name = name;
            this.pid = pid;
        }
    }
}
