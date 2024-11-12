using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace disklinik
{
    class hastalar
    {
        public void hasta_ekle(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection baglanti = MyConnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = query;
            komut.ExecuteNonQuery();   
            baglanti.Close();
        }

    }
}
