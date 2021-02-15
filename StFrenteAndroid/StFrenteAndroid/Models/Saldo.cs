using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class Saldo
    {
        // ID 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Chave { get; set; }
        public DateTime Data { get; set; }
        public String Historico { get; set; }
        public Double Valor { get; set; }
        public int operador { get; set; }
        // 1 abertura 2 suprimento 3 sangria 4 fechamento
        public int Tipo { get; set; }

    }
}
