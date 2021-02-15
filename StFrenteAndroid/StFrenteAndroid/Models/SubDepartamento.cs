using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class SubDepartamento
    {

        [PrimaryKey, AutoIncrement]
        public int CodSubDepartamento { get; set; }
        public String Descricao { get; set; }
        public String DescriDepart { get; set; }
        public int CdDepartamento { get; set; }
    }
}
