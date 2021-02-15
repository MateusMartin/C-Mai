using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    class Tamanho
    {
        [PrimaryKey]
        public int IdTam { get; set; }
        public String Descricao { get; set; }

    }
}
