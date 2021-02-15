using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace StFrenteAndroid.Models
{
    //classe Venda Secundária
    public class CupomSec
    {
        [PrimaryKey, AutoIncrement]
        public int NumeraAuto { get; set; }
        public int ID_CS { get; set; }
        public int ITEM_CS { get; set; }
        public int CODPRO_CS { get; set; }
        public String DESCRI_CS { get; set; }
        public String ALIQUOTA_CS { get; set; }
        public double QTDE_CS { get; set; }
        public double VLRUNI_CS { get; set; }
        public double VLRTOT_CS { get; set; }
        public double CUSTO_CS { get; set; }
        public String GRADE_CS { get; set; }
        public double DESCONTO_CS { get; set; }        
        public Boolean STATUS_CS { get; set; }
        public double TRIBUTOS_CS { get; set; }
    }
}
