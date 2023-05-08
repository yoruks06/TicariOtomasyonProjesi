using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //sql veritabanı baglantısı

namespace Yorukoglu_Komur_Programı
{
    class sqlbaglantisi //sınıfın ismi
    {
        public SqlConnection baglanti() //baglantı metodu ismi  //baglan nesnenin ismi
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=NURULLAH;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
