using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class Departamento
    {
        [PrimaryKey]
        public int IdDepart { get; set; }
        public String Descricao { get; set; }
        public Boolean Carrinho { get; set; }
    }
}
