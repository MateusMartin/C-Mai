using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace StFrenteAndroid.Models
{
    public class Produto
    {

        [PrimaryKey, AutoIncrement]
        //Dados Do Produto
        public int Codigo { get; set; }
        public String CdBarras { get; set; }
        public double QtdPadrao { get; set; }
        public String Descricao { get; set; }
        public int CdFabricante { get; set; }
        public DateTime DtAtCad { get; set; }
        public DateTime DtAtPrec { get; set; }
        public int CdUnMed { get; set; }
        public String UndMedida { get; set; }
        public double CustoUnd { get; set; }
        //Aplica margem de juros em %
        public double PorcMargem { get; set; }
        //Preço de venda unitario
        public double PrcoVendUnd { get; set; }
        // % De Desconto Maximo
        public double PorcDesMax { get; set; }
        //Preço de venda do Produto em atacado
        public double PrcoVdAtacado { get; set; }
        //Quantidade Miníma para compra em atacado
        public double MinAtacado { get; set; }
        //Porcentual de Acrecimo de comissão de vendedores
        public double PorcCom { get; set; }
        //Codigo para formação de preço de venda por indice
        public int CdFormInd { get; set; }
        //Fornecedor Princ
        public int CdFornPrinc { get; set; }
        public String FornPrinc { get; set; }
        //End fornecedor
        public int CodDepart { get; set; }
        public String Depart { get; set; }
        public int CodSubDepart { get; set; }
        public String SubDepart { get; set; }
        //Cor Predominante
        public int CodCor { get; set; }
        public String CorPred { get; set; }
        //Valor Unitario De converção em compras
        public double QtdeConver { get; set; }
        public String Local1 { get; set; }
        public String Local2 { get; set; }
        //Validade Controloda
        public Boolean VldCntrl { get; set; }
        //Carga De balança Validade
        public Boolean BalanVal { get; set; }
        public String DiasValBal { get; set; }
        //end val balan
        //Indíce da aliquota para venda A. ECF
        public double AECF { get; set; }
        //FIM DADOS PROD

        //TRIBUTOS        
        //Valor unitario de tributos na origem em R$
        public double TribOrigem { get; set; }
        //Valor unitario de tributos a agregar em R$
        public double TribAgregado { get; set; }
        //FIM TRIBUTOS


        //Dados NFE
        public int CdCNCM { get; set; }
        public String CNCM { get; set; }
        public int CdCest { get; set; }
        public String CEST { get; set; }
        public int CodSitTrib { get; set; }
        public String SitTrib { get; set; }
        public int CFOP { get; set; }
        //Tipo Produto
        public int CdTipoProd { get; set; }
        public String TipoProd { get; set; }
        //Icms %
        public double Icms { get; set; }
        //Difer %
        public double Difer { get; set; }
        //Ipi %
        public double Ipi { get; set;  }
        public int CdEX { get; set; }
        public int CodTribIcsmCson { get; set; }
        //CSOSN Tridutação de ICMS pelo Simples Nacional
        public String TribIcmsSimples { get; set; }
        public int CodigoOrigem { get; set; }
        public String Origem { get; set; }
        //Codigo do genero do item
        public int CodGen { get; set; }       
        public double IcmsIO { get; set; }
        public Boolean ProdEscRelec { get; set; }
        public String CnpjFabri { get; set; }
        //% FPC
        public double Fpc { get; set; }    
        //% FPC ST
        public double FpcST { get; set; }
        //Codigo de Beneficiario Fiscal na UF
        public double CBenFiscUF { get; set; }
        public Boolean PdSemBarra { get; set; }
        //Situação Tributaria do Pis
        public int CdSitTribPis { get; set; }
        public String SitTribPis { get; set; }
        // % PIS
        public double Pis { get; set; }
        //Situação Tributaria do Confins 
        public int CdTribConf { get; set; }
        public String TribConf { get; set; }
        // % Confins
        public Double Confins { get; set; }
        //Cod Grupo Combust
        public String GrupCombu { get; set; }
        //% GLP
        public double GLP { get; set; }  
        //% v part
        public double VPart { get; set; }
        //Descrição do produto Conforme Anp
        public String DescriProdConfAnp { get; set; }

    }
}
