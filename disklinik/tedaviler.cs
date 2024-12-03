using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disklinik
{
    internal class tedaviler
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
        public void tedacisil(string query)
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

        public void tedaviguncelle(string query)
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

        public DataSet Showtedavi(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection baglanti = MyConnection.GetCon();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
    }
}
