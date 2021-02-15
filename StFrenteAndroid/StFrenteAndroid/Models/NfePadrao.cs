using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class NfePadrao
    {
        [PrimaryKey, AutoIncrement]
        public int Cod_Cel { get; set; }
        public int Id_PN { get; set; }
        public String NOME_PN { get; set; }
        public String CNPJ_PN { get; set; }
        public String ENDERECO_PN { get; set; }
        public String NUMERO_PN { get; set; }
        public String CPL_PN { get; set; }
        public String bairro_pn { get; set; }
        public String CODMUN_PN { get; set; }
        public String CIDADE_PN { get; set; }
        public String uf_PN { get; set; }
        public String CEP_PN { get; set; }
        public String FONE_PN { get; set; }
        public String FONE_PNIE_PN { get; set; }
        public String IE_PN { get; set; }
        public String MODELO_PN { get; set; }
        public int SERIE_PN { get; set; }
        public String PATH_CHAVE { get; set; }
        public String PATH_SCHEMAS { get; set; }
        public String PATH_MOVIMENTO { get; set; }
        public String SENHA_CERTIFICADO { get; set; }
        public int AMBIENTE_PN { get; set; }
        public String CODUF_PN { get; set; }
        public String RAZAO_PN { get; set; }
        public int BASEICMS_PN { get; set; }
        public int BASEST_PN { get; set; }
        public int SIMPLES_PN { get; set; }
        public int PERFILAPRS_PN { get; set; }
        public int INDICAATIVI_PN { get; set; }
        public String inscmun_PN { get; set; }
        public String EMAIL_PN { get; set; }
        public Boolean USACOD_PN { get; set; }
        public String LOCBACK_PN { get; set; }
        public int PERCREDCSO { get; set; }
        public String Msg_fisco { get; set; }
        public String Msg_Contri { get; set; }
        public Boolean IPI_PN { get; set; }
        public Boolean IMPRIMEAMBOS_PN { get; set; }
        public Boolean TIPOCNPJBAIXAR_PN { get; set; }
        public String CNPJBAIXAR_prd { get; set; }
        public String ISENTO_ATE { get; set; }
        public String cIdToken { get; set; }
        public String CSC { get; set; }

    }
}
