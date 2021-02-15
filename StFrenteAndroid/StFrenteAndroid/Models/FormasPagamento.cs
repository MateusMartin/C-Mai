using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class FormasPagamento
    {
        [PrimaryKey, AutoIncrement]
        public int Cod_Forma { get; set; }
        public String Descricao { get; set; }

    }
}
