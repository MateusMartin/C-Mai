using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    class Cor
    {

        [PrimaryKey]
        public int IdCor { get; set; }
        public String Descricao { get; set; }

    }
}
