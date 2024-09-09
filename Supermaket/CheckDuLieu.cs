using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Supermaket
{
    public static class CheckDuLieu
    {
        public static List<string> checkloilist = new List<string>();
        public static bool CheckSDT(string sdt,string select)
        {
            bool ktr = true;
            if (MainClass.GetConnection().State == ConnectionState.Closed)
                MainClass.GetConnection().Open();
            string sql = select;
            SqlDataAdapter ad = new SqlDataAdapter(sql, MainClass.GetConnection());
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["SĐT"].ToString());
            }
            if (checkloilist.Contains(sdt))
            {
                ktr = false;
            }
            return ktr;
        }
        public static bool CheckGmail(string gmail,string select)
        {
            bool ktr = true;
            if (MainClass.GetConnection().State == ConnectionState.Closed)
                MainClass.GetConnection().Open();
            string sql = select;
            SqlDataAdapter ad = new SqlDataAdapter(sql, MainClass.GetConnection());
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["EMAIL"].ToString());
            }
            if (checkloilist.Contains(gmail))
            {
                ktr = false;
            }
            return ktr;
        }
        

    }

}
