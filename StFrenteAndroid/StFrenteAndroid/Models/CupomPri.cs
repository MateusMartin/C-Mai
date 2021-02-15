using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    //classe Venda Primaria
    public class CupomPri
    {
        [PrimaryKey, AutoIncrement]      
        public int ID_CP { get; set; }
        public DateTime DATA_CP { get; set; }
        public DateTime HORA_CP { get; set; }
        public Boolean STATUS_CP { get; set; }
        public int OPERADOR_CP { get; set; }
        public Boolean RETAG_CP { get; set; }
        public Boolean FECHADO_CP { get; set; }
        public String FORMAPG_CP { get; set; }
        public Double TOTAL_CP { get; set; }
        public int VENDEDOR_CP { get; set; }
        public String NFCE_CP { get; set; }
        public Boolean EMITIDANFCE_CP { get; set; }
        public int NFCEATIVA_CP { get; set; }
        public int CLIENTE_CP { get; set; }
        public String CPF_CP { get; set; }

    }
}
