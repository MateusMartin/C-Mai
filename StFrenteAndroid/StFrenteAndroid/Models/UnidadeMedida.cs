using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class UnidadeMedida
    {
        [PrimaryKey]
        public int idUnida { get; set; }
        public String Descricao { get; set; }

    }
}
