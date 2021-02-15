using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class CNCM
    {
        [PrimaryKey]
        public int CodCNCM { get; set; }
        public String Descricao { get; set; }
        public String CEST { get; set; }
    }
}
