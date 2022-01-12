using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
     public class database
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=MONSTER;Initial Catalog=otel_otomasyonu;Integrated Security=True;MultipleActiveResultSets=True");
        public static SqlConnection staticBaglanti = new SqlConnection(@"Data Source=MONSTER;Initial Catalog=otel_otomasyonu;Integrated Security=True;MultipleActiveResultSets=True");
    }
}
