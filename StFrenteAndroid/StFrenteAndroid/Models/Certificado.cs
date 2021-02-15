using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace StFrenteAndroid.Models
{
    public class Certificado
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String  Local { get; set; }
        public String Senha { get; set; }

    }
}
