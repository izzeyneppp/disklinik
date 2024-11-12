using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace disklinik
{
    class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = @"Data Source=DESKTOP-F695QET;Initial Catalog=disklinik;Integrated Security=True;Trust Server Certificate=True";
            return baglanti;
        }
    }
}
