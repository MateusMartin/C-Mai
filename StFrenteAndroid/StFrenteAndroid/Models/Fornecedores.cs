using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Models
{
    public class Fornecedores
    {
        [PrimaryKey,AutoIncrement]
        public int Codigo { get; set; }
        public String RazaoSocial { get; set; }
        public String Cep { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
        public String CodigoDeMunicipios { get; set; }
        public String CodigoPais { get; set; }
        public String Pais { get; set; }
        public String CNPJ { get; set; }
        public String Inscricao { get; set; }
        public String Telefone1 { get; set; }
        public String Telefone2 { get; set; }
        public Boolean DiferIcms { get; set; }
        public String Email { get; set; }
        public String HomePage { get; set; }
        public String Banco { get; set; }
        public String Agencia { get; set; }
        public String Conta { get; set; }
        public String Score { get; set; }
        public String Observacao { get; set; }
    }
}
