using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Rg.Plugins.Popup.Services;
using StFrenteAndroid.Models;
using StFrenteAndroid.SQL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StFrenteAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoProduto : ContentPage
	{
		public NovoProduto ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            var mensagem_tap = new TapGestureRecognizer();
            mensagem_tap.Tapped += async (s, e) =>
            {
                var app = new PopUpProdutosCadastrosSub();        
                await PopupNavigation.PushAsync(app);
            };

            IdCadastro.GestureRecognizers.Add(mensagem_tap);
            CarregaInfo();

        }

        public void CarregaInfo()
        {
            CommandFornecedores CmdFor = new CommandFornecedores();
            CmdFor.CriarBancoFornecedores();
            List<Fornecedores> LFor = CmdFor.GetFornecedores();
            InputFornPri.ItemsSource = LFor;

            CommandDepartamento CmdDepart = new CommandDepartamento();
            CmdDepart.CriarBancoDepartamento();
            List<Departamento> LDprt = CmdDepart.GetDepartamento();
            InputDepartamento.ItemsSource = LDprt;

            CommandUnidadeMedida CmdUndMed = new CommandUnidadeMedida();
            CmdUndMed.CriarUnidadeMedida();
            List<UnidadeMedida> LMed = CmdUndMed.GetUnidadeMedida();
            InputUndMed.ItemsSource = LMed;

            CommandCncm CmdCncm = new CommandCncm();
            CmdCncm.CriarBancoCNCM();
            List<CNCM> LCncm = CmdCncm.GetCNCM();
            InputCncm.ItemsSource = LCncm;
            
            List<SituacaoTributaria> LTrib = new List<SituacaoTributaria>();

            SituacaoTributaria Li = new SituacaoTributaria();
            Li.Codigo = 00;
            Li.Descricao = "Tributada integralmente";
            LTrib.Add(Li);

            SituacaoTributaria Li1 = new SituacaoTributaria();
            Li1.Codigo = 10;
            Li1.Descricao = "Tributada e com cobrança do ICMS por substituição tributária";
            LTrib.Add(Li1);

            SituacaoTributaria Li2 = new SituacaoTributaria();
            Li2.Codigo = 20;
            Li2.Descricao = "Com redução de base de cálculo";
            LTrib.Add(Li2);

            SituacaoTributaria Li3 = new SituacaoTributaria();
            Li3.Codigo = 30;
            Li3.Descricao = "Isenta ou não tributada e com cobrança do ICMS por substituição tributária";
            LTrib.Add(Li3);

            SituacaoTributaria Li4 = new SituacaoTributaria();
            Li4.Codigo = 40;
            Li4.Descricao = "Isenta";
            LTrib.Add(Li4);

            SituacaoTributaria Li5 = new SituacaoTributaria();
            Li5.Codigo = 41;
            Li5.Descricao = "Não tributada";
            LTrib.Add(Li5);

            SituacaoTributaria Li6 = new SituacaoTributaria();
            Li6.Codigo = 50;
            Li6.Descricao = "Suspensão";
            LTrib.Add(Li6);

            SituacaoTributaria Li7 = new SituacaoTributaria();
            Li7.Codigo = 51;
            Li7.Descricao = "Diferimento";
            LTrib.Add(Li7);

            SituacaoTributaria Li8 = new SituacaoTributaria();
            Li8.Codigo = 70;
            Li8.Descricao = "Com redução de base de cálculo e cobrança do ICMS por substituição tributária";
            LTrib.Add(Li8);

            SituacaoTributaria Li9 = new SituacaoTributaria();
            Li9.Codigo = 90;
            Li9.Descricao = "Outras";
            LTrib.Add(Li9);
            
            InputSitTributa.ItemsSource = LTrib;

            List<CSON> LTrb = new List<CSON>();

            CSON Cs = new CSON();
            Cs.Codigo = 101;
            Cs.Descricao = "Tributada pelo Simples Nacional com permissão de crédito";
            LTrb.Add(Cs);

            CSON Cs1 = new CSON();
            Cs1.Codigo = 102;
            Cs1.Descricao = "Tributada pelo Simples Nacional sem permissão de crédito";
            LTrb.Add(Cs1);

            CSON Cs2 = new CSON();
            Cs2.Codigo = 103;
            Cs2.Descricao = "Isenção do ICMS no Simples Nacional para faixa de receita bruta";
            LTrb.Add(Cs2);

            CSON Cs3 = new CSON();
            Cs3.Codigo = 201;
            Cs3.Descricao = "Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por substituição tributária";
            LTrb.Add(Cs3);

            CSON Cs4 = new CSON();
            Cs4.Codigo = 202;
            Cs4.Descricao = "Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por substituição tributária";
            LTrb.Add(Cs4);

            CSON Cs5 = new CSON();
            Cs5.Codigo = 203;
            Cs5.Descricao = "Isenção do ICMS no Simples Nacional para faixa de receita bruta e com cobrança do ICMS por substituição tributária";
            LTrb.Add(Cs5);

            CSON Cs6 = new CSON();
            Cs6.Codigo = 300;
            Cs6.Descricao = "Imune";
            LTrb.Add(Cs6);

            CSON Cs7 = new CSON();
            Cs7.Codigo = 400;
            Cs7.Descricao = "Não tributada pelo Simples Nacional";
            LTrb.Add(Cs7);

            CSON Cs8 = new CSON();
            Cs8.Codigo = 500;
            Cs8.Descricao = "ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação";
            LTrb.Add(Cs8);

            CSON Cs9 = new CSON();
            Cs9.Codigo = 900;
            Cs9.Descricao = "Outros";
            LTrb.Add(Cs9);

            InputCsonTribIcms.ItemsSource = LTrb;

            List<Origem> LOri = new List<Origem>();

            Origem COrigem = new Origem();
            COrigem.Codigo = 1;
            COrigem.Descricao = "Estrangeira - Importação Direta";
            LOri.Add(COrigem);

            Origem COrigem1 = new Origem();
            COrigem1.Codigo = 2;
            COrigem1.Descricao = "Estrangeira - Adquirida no Mercado Interno";
            LOri.Add(COrigem1);

            Origem COrigem2 = new Origem();
            COrigem2.Codigo = 2;
            COrigem2.Descricao = "Nacional merc.ContImp.sup. 40% e inferior a 70%";
            LOri.Add(COrigem2);

            Origem COrigem3 = new Origem();
            COrigem3.Codigo = 3;
            COrigem3.Descricao = "Nacional cuja prod tenha sido feita em confo";
            LOri.Add(COrigem3);

            Origem COrigem4 = new Origem();
            COrigem4.Codigo = 4;
            COrigem4.Descricao = "Nacional, com Conteúdo de Impinferior a 40%";
            LOri.Add(COrigem4);

            Origem COrigem5 = new Origem();
            COrigem5.Codigo = 5;
            COrigem5.Descricao = "Estrangeira Importação direta sem similar nac";
            LOri.Add(COrigem5);

            Origem COrigem6 = new Origem();
            COrigem6.Codigo = 6;
            COrigem6.Descricao = "Estrangeira Adqu no merc int sem similar nac";
            LOri.Add(COrigem6);

            Origem COrigem7 = new Origem();
            COrigem7.Codigo = 7;
            COrigem7.Descricao = "Nacional com Conteúdo de Importação sup a 70%";
            LOri.Add(COrigem7);

            InputOrigem.ItemsSource = LOri;

            List<TipoProduto> LTProd = new List<TipoProduto>();

            TipoProduto TProd = new TipoProduto();
            TProd.Codigo = 0;
            TProd.Descricao = "MERCADORIA PARA REVENDA";
            LTProd.Add(TProd);

            TipoProduto TProd1 = new TipoProduto();
            TProd1.Codigo = 1;
            TProd1.Descricao = "MATÉRIA PRIMA";
            LTProd.Add(TProd1);

            TipoProduto TProd2 = new TipoProduto();
            TProd2.Codigo = 2;
            TProd2.Descricao = "EMBALAGEM";
            LTProd.Add(TProd2);

            TipoProduto TProd3 = new TipoProduto();
            TProd3.Codigo = 3;
            TProd3.Descricao = "PRODUTO EM PROCESSO";
            LTProd.Add(TProd3);

            TipoProduto TProd4 = new TipoProduto();
            TProd4.Codigo = 4;
            TProd4.Descricao = "PRODUTO ACABADO";
            LTProd.Add(TProd4);

            TipoProduto TProd5 = new TipoProduto();
            TProd5.Codigo = 5;
            TProd5.Descricao = "SUBPRODUTO";
            LTProd.Add(TProd5);

            TipoProduto TProd6 = new TipoProduto();
            TProd6.Codigo = 6;
            TProd6.Descricao = "PRODUTO INTERMEDIÁRIO";
            LTProd.Add(TProd6);

            TipoProduto TProd7 = new TipoProduto();
            TProd7.Codigo = 7;
            TProd7.Descricao = "MATERIAL USO CONSUMO";
            LTProd.Add(TProd7);

            TipoProduto TProd8 = new TipoProduto();
            TProd8.Codigo = 8;
            TProd8.Descricao = "ATIVO IMOBILIZADO";
            LTProd.Add(TProd8);

            TipoProduto TProd9 = new TipoProduto();
            TProd9.Codigo = 9;
            TProd9.Descricao = "SERVIÇOS";
            LTProd.Add(TProd9);

            TipoProduto TProd10 = new TipoProduto();
            TProd10.Codigo = 10;
            TProd10.Descricao = "OUTROS INSUMOS";
            LTProd.Add(TProd10);

            TipoProduto TProd99 = new TipoProduto();
            TProd99.Codigo = 99;
            TProd99.Descricao = "OUTROS";
            LTProd.Add(TProd99);

            InputTipoProd.ItemsSource = LTProd;

            List<CodigoSitTibutaria> LCSitT = new List<CodigoSitTibutaria>();

            CodigoSitTibutaria CdSitTrib1 = new CodigoSitTibutaria();
            CdSitTrib1.Codigo = 1;
            CdSitTrib1.Descricao = "Operação Tributável (base de cálculo = valor da operação alíquota normal(cumulativo/não cumulativo))";
            LCSitT.Add(CdSitTrib1);

            CodigoSitTibutaria CdSitTrib2 = new CodigoSitTibutaria();
            CdSitTrib2.Codigo = 2;
            CdSitTrib2.Descricao = "Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))";
            LCSitT.Add(CdSitTrib2);

            CodigoSitTibutaria CdSitTrib3 = new CodigoSitTibutaria();
            CdSitTrib3.Codigo = 3;
            CdSitTrib3.Descricao = "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)";
            LCSitT.Add(CdSitTrib3);

            CodigoSitTibutaria CdSitTrib4 = new CodigoSitTibutaria();
            CdSitTrib4.Codigo = 4;
            CdSitTrib4.Descricao = "Operação Tributável (tributação monofásica (alíquota zero))";
            LCSitT.Add(CdSitTrib4);

            CodigoSitTibutaria CdSitTrib5 = new CodigoSitTibutaria();
            CdSitTrib5.Codigo = 5;
            CdSitTrib5.Descricao = "Operação Tributável (Substituição Tributária)";
            LCSitT.Add(CdSitTrib5);

            CodigoSitTibutaria CdSitTrib6 = new CodigoSitTibutaria();
            CdSitTrib6.Codigo = 6;
            CdSitTrib6.Descricao = "Operação Tributável (alíquota zero).";
            LCSitT.Add(CdSitTrib6);

            CodigoSitTibutaria CdSitTrib7 = new CodigoSitTibutaria();
            CdSitTrib7.Codigo = 7;
            CdSitTrib7.Descricao = "Operação Isenta da Contribuição";
            LCSitT.Add(CdSitTrib7);

            CodigoSitTibutaria CdSitTrib8 = new CodigoSitTibutaria();
            CdSitTrib8.Codigo = 8;
            CdSitTrib8.Descricao = "Operação Sem Incidência da Contribuição";
            LCSitT.Add(CdSitTrib8);

            CodigoSitTibutaria CdSitTrib9 = new CodigoSitTibutaria();
            CdSitTrib9.Codigo = 9;
            CdSitTrib9.Descricao = "Operação com Suspensão da Contribuição";
            LCSitT.Add(CdSitTrib9);

            CodigoSitTibutaria CdSitTrib49 = new CodigoSitTibutaria();
            CdSitTrib49.Codigo = 49;
            CdSitTrib49.Descricao = "Outras operações de saida";
            LCSitT.Add(CdSitTrib49);

            CodigoSitTibutaria CdSitTrib98 = new CodigoSitTibutaria();
            CdSitTrib98.Codigo = 98;
            CdSitTrib98.Descricao = "Outras operações de entrada";
            LCSitT.Add(CdSitTrib98);

            CodigoSitTibutaria CdSitTrib99 = new CodigoSitTibutaria();
            CdSitTrib99.Codigo = 99;
            CdSitTrib99.Descricao = "Outras Operações.";
            LCSitT.Add(CdSitTrib99);

            InputCdSituaCofins.ItemsSource = LCSitT;
            InputCdSitua.ItemsSource = LCSitT;

            CommandCores CmCor = new CommandCores();
            List<Cor> LCor = CmCor.GetCor();
            InputCorPredo.ItemsSource = LCor;

            List<CEST> List = new List<CEST>();

            CEST cst = new CEST();
            cst.Codigo = 1;
            cst.Descricao = "Autopeças";
            List.Add(cst);

            CEST cst2 = new CEST();
            cst2.Codigo = 2;
            cst2.Descricao = "Bebidas Alcoólicas, exeto cerveja e chope";
            List.Add(cst2);

            CEST cst3 = new CEST();
            cst3.Codigo = 3;
            cst3.Descricao = "Cervejas, chopes, refrigerantes, águas e outras bebidas";
            List.Add(cst3);

            CEST cst4 = new CEST();
            cst4.Codigo = 4;
            cst4.Descricao = "Cigarros e outros produtos derivados do fumo";
            List.Add(cst4);

            CEST cst5 = new CEST();
            cst5.Codigo = 5;
            cst5.Descricao = "Cimentos";
            List.Add(cst5);

            CEST cst6 = new CEST();
            cst6.Codigo = 6;
            cst6.Descricao = "Combustíveis e lubrificantes";
            List.Add(cst6);

            CEST cst7 = new CEST();
            cst7.Codigo = 7;
            cst7.Descricao = "Energia elétrica";
            List.Add(cst7);

            CEST cst8 = new CEST();
            cst8.Codigo = 8;
            cst8.Descricao = "Ferramentas";
            List.Add(cst8);

            CEST cst9 = new CEST();
            cst9.Codigo = 9;
            cst9.Descricao = "Lâmpadas, reatores e “starter”";
            List.Add(cst9);

            CEST cst10 = new CEST();
            cst10.Codigo = 10;
            cst10.Descricao = "Materiais de construção e congêneres";
            List.Add(cst10);

            CEST cst11 = new CEST();
            cst11.Codigo = 11;
            cst11.Descricao = "Materiais de limpeza";
            List.Add(cst11);

            CEST cst12 = new CEST();
            cst12.Codigo = 12;
            cst12.Descricao = "Materiais elétricos";
            List.Add(cst12);

            CEST cst13 = new CEST();
            cst13.Codigo = 13;
            cst13.Descricao = "Medicamentos e outros produtos farmacêuticos para uso humano";
            List.Add(cst13);

            CEST cst14 = new CEST();
            cst14.Codigo = 14;
            cst14.Descricao = "Papéis";
            List.Add(cst14);

            CEST cst15 = new CEST();
            cst15.Codigo = 15;
            cst15.Descricao = "Plásticos";
            List.Add(cst15);

            CEST cst16 = new CEST();
            cst16.Codigo = 16;
            cst16.Descricao = "Pneumáticos, câmaras de ar e protetores de borracha";
            List.Add(cst16);

            CEST cst17 = new CEST();
            cst17.Codigo = 17;
            cst17.Descricao = "Produtos alimentícios";
            List.Add(cst17);

            CEST cst18 = new CEST();
            cst18.Codigo = 18;
            cst18.Descricao = "Produtos cerâmicos";
            List.Add(cst18);

            CEST cst19 = new CEST();
            cst19.Codigo = 19;
            cst19.Descricao = "Produtos de papelaria";
            List.Add(cst19);

            CEST cst20 = new CEST();
            cst20.Codigo = 20;
            cst20.Descricao = "Produtos de perfumaria e de higiene pessoal e cosméticos";
            List.Add(cst20);

            CEST cst21 = new CEST();
            cst21.Codigo = 21;
            cst21.Descricao = "Produtos eletrônicos, eletroeletrônicos e eletrodomésticos";
            List.Add(cst21);

            CEST cst22 = new CEST();
            cst22.Codigo = 22;
            cst22.Descricao = "Rações para animais domésticos";
            List.Add(cst22);

            CEST cst23 = new CEST();
            cst23.Codigo = 23;
            cst23.Descricao = "Sorvetes e preparados para fabricação de sorvetes em máquinas";
            List.Add(cst23);

            CEST cst24 = new CEST();
            cst24.Codigo = 24;
            cst24.Descricao = "Tintas e vernizes";
            List.Add(cst24);

            CEST cst25 = new CEST();
            cst25.Codigo = 25;
            cst25.Descricao = "Veículos automotores";
            List.Add(cst25);

            CEST cst26 = new CEST();
            cst26.Codigo = 26;
            cst26.Descricao = "Veículos de duas e três rodas motorizados";
            List.Add(cst26);

            CEST cst27 = new CEST();
            cst27.Codigo = 27;
            cst27.Descricao = "Vidros";
            List.Add(cst27);

            CEST cst28 = new CEST();
            cst28.Codigo = 28;
            cst28.Descricao = "Venda de mercadorias pelo sistema porta a porta";
            List.Add(cst28);

            CEST cst1702201 = new CEST();
            cst1702201.Codigo = 1702201;
            cst1702201.Descricao = "Leite em recipiente de conteúdo superior a 1 litro";
            List.Add(cst1702201);

            CEST cst1702601 = new CEST();
            cst1702601.Codigo = 1702601;
            cst1702601.Descricao = "Iogurte e leite fermentado em recipiente de conteúdo superior a 2 litros";
            List.Add(cst1702601);

            CEST cst1703001 = new CEST();
            cst1703001.Codigo = 1703001;
            cst1703001.Descricao = "Manteiga, em embalagem de conteúdo superior a 1 kg";
            List.Add(cst1703001);

            CEST cst1703202 = new CEST();
            cst1703202.Codigo = 1703202;
            cst1703202.Descricao = "Outras margarinas e cremes vegetais em recipiente de conteúdo inferior a 1 kg, exceto as embalagens individuais de conteúdo inferior";
            List.Add(cst1703202);

            CEST cst1709701 = new CEST();
            cst1709701.Codigo = 1709701;
            cst1709701.Descricao = "Produtos hortícolas, frutas, cascas de frutas e outras partes de plantas, conservados com açúcar (passados por calda, glaceados ou cristalizados), em embalagens de conteúdo superior a 1 kg";
            List.Add(cst1709701);

            CEST cst1710602 = new CEST();
            cst1710602.Codigo = 1710602;
            cst1710602.Descricao = "Açúcar cristal adicionado de aromatizante ou de corante, em embalagens de conteúdo superior a 5 kg";
            List.Add(cst1710602);

            CEST cst1710802 = new CEST();
            cst1710802.Codigo = 1710802;
            cst1710802.Descricao = "Outros tipos de açúcar adicionado de aromatizante ou de corante, em embalagens de conteúdo superior a 5 kg";
            List.Add(cst1710802);

            CEST cst1710901 = new CEST();
            cst1710901.Codigo = 1710901;
            cst1710901.Descricao = "Outros açúcares, em embalagens de conteúdo superior a 2 kg e inferior ou igual a 5 kg";
            List.Add(cst1710901);

            CEST cst1710902 = new CEST();
            cst1710902.Codigo = 1710902;
            cst1710902.Descricao = "Outros açúcares, em embalagens de conteúdo superior a 5 kg";
            List.Add(cst1710902);

            CEST cst2003901 = new CEST();
            cst2003901.Codigo = 2003901;
            cst2003901.Descricao = "Chupetas e bicos para mamadeiras e para chupetas, de silicone";
            List.Add(cst2003901);

            CEST cst2003501 = new CEST();
            cst2003501.Codigo = 2003501;
            cst2003501.Descricao = "Lenços Umedecidos";
            List.Add(cst2003501);

            InputCest.ItemsSource = List;

        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new ProdutosMenu());

            return true;
        }

        private void BtnGravar_Clicked(object sender, EventArgs e)
        {
            if (InputCodProduto.Text == "" ||  InputCodProduto.Text == null)
            {
                /**
                   Filtro de Produtos
                */
                Produto Prd = new Produto();
                Prd.Codigo = 0;
                Prd.CdBarras = InputBarras.Text;
                Prd.QtdPadrao = Convert.ToDouble(InputLblQtde.Text);
                Prd.Descricao = PrdInputDescricao.Text;
                Prd.CdFabricante = Convert.ToInt32(InputCodFabric.Text);
                Prd.DtAtCad = DtPickAtCad.Date;
                Prd.DtAtPrec = DtPickAtPrco.Date;
                //
                var UnidadeMed = (UnidadeMedida)InputUndMed.SelectedItem;
                Prd.CdUnMed = UnidadeMed.idUnida;
                Prd.UndMedida = UnidadeMed.Descricao;
                Prd.CustoUnd = Convert.ToDouble(InputCstUnit.Text);
                Prd.PorcMargem = Convert.ToDouble(InputAplicar.Text);
                Prd.PrcoVendUnd = Convert.ToDouble(InputVndUnit.Text);
                Prd.PorcDesMax = Convert.ToDouble(InputDescM.Text); 
                Prd.MinAtacado = Convert.ToDouble(InputMAtacado.Text);
                Prd.PrcoVdAtacado = Convert.ToDouble(InputVlrAtacado.Text);
                Prd.PorcCom = Convert.ToDouble(InputAcresCom.Text);
                Prd.CdFormInd = Convert.ToInt32(InputFormPrec.Text);
                //
                var Fornecedor = (Fornecedores)InputFornPri.SelectedItem;
                Prd.CdFornPrinc = Fornecedor.Codigo;
                Prd.FornPrinc = Fornecedor.RazaoSocial;

                var Departamento = (Departamento)InputDepartamento.SelectedItem;
                Prd.CodDepart = Departamento.IdDepart;
                Prd.Depart = Departamento.Descricao;

                var SubDepartamento = (SubDepartamento)InputSubDepartamento.SelectedItem;
                Prd.CodSubDepart = SubDepartamento.CodSubDepartamento;
                Prd.SubDepart = SubDepartamento.Descricao;

                var VarCr = (Cor)InputCorPredo.SelectedItem;
                Prd.CodCor = VarCr.IdCor;
                Prd.CorPred = VarCr.Descricao;


                Prd.QtdeConver = Convert.ToDouble(InputQtdeConvers.Text);
                Prd.Local1 = InputLocal1.Text;
                Prd.Local2 = InputLocal2.Text;

                Prd.VldCntrl = ChkValControl.IsChecked;
                Prd.BalanVal = ChkCargBalVal.IsChecked;
                Prd.DiasValBal = InputDias.Text;

                Prd.AECF = Convert.ToDouble(InputAecf.Text);
                Prd.TribOrigem = Convert.ToDouble(InputTribOrigem.Text);
                Prd.TribAgregado = Convert.ToDouble(InputTribAgregado.Text);

                var InCncm = (CNCM)InputCncm.SelectedItem;
                Prd.CdCNCM = InCncm.CodCNCM;
                Prd.CNCM = InCncm.Descricao;

                var ICest = (CEST)InputCest.SelectedItem;
                Prd.CdCest = ICest.Codigo;
                Prd.CEST = ICest.Descricao;

                var VarSitTri = (SituacaoTributaria)InputSitTributa.SelectedItem;
                Prd.CodSitTrib = VarSitTri.Codigo;
                Prd.SitTrib = VarSitTri.Descricao;

                Prd.CFOP = Convert.ToInt32(InputCFOP.Text);

                var TpoProduto = (TipoProduto)InputTipoProd.SelectedItem;
                Prd.CdTipoProd = TpoProduto.Codigo;
                Prd.TipoProd = TpoProduto.Descricao;
                Prd.Icms = Convert.ToDouble(InputICMS.Text);
                Prd.Difer = Convert.ToDouble(InputDifer.Text);
                Prd.Ipi = Convert.ToDouble(InputIpi.Text);
                Prd.CdEX = Convert.ToInt32(InputCodEx.Text);

                var TribIcms = (CSON)InputCsonTribIcms.SelectedItem;
                Prd.CodTribIcsmCson = TribIcms.Codigo;
                Prd.TribIcmsSimples = TribIcms.Descricao;

                var InfoOrigon = (Origem)InputOrigem.SelectedItem;
                Prd.CodigoOrigem = InfoOrigon.Codigo;
                Prd.Origem = InfoOrigon.Descricao;

                Prd.CodGen = Convert.ToInt32(InputCodGn.Text);
                Prd.IcmsIO = Convert.ToInt32(InputIcmsOI.Text);
                Prd.ProdEscRelec = ChkPrdEscRel.IsChecked;
                Prd.CnpjFabri = InputPrdEscRel.Text;
                Prd.Fpc = Convert.ToDouble(InputFcp.Text);
                Prd.FpcST = Convert.ToDouble(InputFcpSt.Text);
                Prd.CBenFiscUF = Convert.ToDouble(InputBenFisc.Text);

                // #######//
                Prd.PdSemBarra = false;

                var CodSitu = (CodigoSitTibutaria)InputCdSituaCofins.SelectedItem;
                Prd.CdSitTribPis = CodSitu.Codigo;
                Prd.SitTribPis = CodSitu.Descricao;
                Prd.Pis = Convert.ToDouble(InputPis.Text);

                var CodTrbConf = (CodigoSitTibutaria)InputCdSituaCofins.SelectedItem;
                Prd.CdTribConf = CodTrbConf.Codigo;
                Prd.TribConf = CodTrbConf.Descricao;
                Prd.Confins = Convert.ToInt32(InputCofins.Text);
                Prd.GrupCombu = InputCdGrupComb.Text;
                Prd.GLP = Convert.ToDouble(InputGlp.Text);
                Prd.VPart = Convert.ToDouble(InputVPart.Text);
                Prd.DescriProdConfAnp = LblDescriAnp.Text;

                CommandProdutos CmdPrd = new CommandProdutos();
                CmdPrd.CriarProduto();
                CmdPrd.InserirProduto(Prd);

            }
            else if (InputCodProduto.Text != "" && InputCodProduto.Text != null)
            {

            }
        }

        private void InputCodFornPri_Unfocused(object sender, FocusEventArgs e)
        {
            if (InputCodFornPri.Text != "" && InputCodFornPri.Text != null)
            {
                int Cod = Convert.ToInt32(InputCodFornPri.Text);
                CommandFornecedores CmdForn = new CommandFornecedores();
                CmdForn.CriarBancoFornecedores();
                List<Fornecedores> LForn = CmdForn.GetFornecedoresByID(Cod);
                List<Fornecedores> LFrn = (List<Fornecedores>)InputFornPri.ItemsSource;

                int i = 0;
                int a = 0;

                foreach (Fornecedores Dep in LFrn)
                {
                    if (Dep.Codigo == LForn[0].Codigo)
                    {
                        a = i;
                    }
                    i++;
                }
                InputFornPri.SelectedIndex = a;

            }
        }

        private void InputCodDepartamento_Unfocused(object sender, FocusEventArgs e)
        {
            if (InputCodDepartamento.Text != "" && InputCodDepartamento.Text != null)
            {
                int Cod = Convert.ToInt32(InputCodDepartamento.Text);
                CommandDepartamento CmDerp = new CommandDepartamento();
                CmDerp.CriarBancoDepartamento();

                List<Departamento> LDepar = CmDerp.GetDepartamentoID(Cod);
                List<Departamento> LDpr = (List<Departamento>)InputDepartamento.ItemsSource;
                int i = 0;
                int a = 0;

                foreach (Departamento Dep in LDpr)
                {
                    if (Dep.IdDepart == LDepar[0].IdDepart)
                    {
                        a = i;
                    }
                    i++;
                }
                InputDepartamento.SelectedIndex = a;
            }
        }

        private void InputDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputDepartamento.SelectedItem != null)
            {               
                var itm = (Departamento)InputDepartamento.SelectedItem;
                InputCodDepartamento.Text = itm.IdDepart.ToString();
                CommandSubDepartamento CmSub = new CommandSubDepartamento();
                CmSub.CriarBancoSubDepartamento();
                List<SubDepartamento> Ldprt = CmSub.GetSubDepartamentoByDprt(itm.IdDepart);

                InputSubDepartamento.ItemsSource = Ldprt;
                InputCodSubDepartamento.Text = "";
            }
        }

        private void InputFornPri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputFornPri.SelectedItem != null)
            {
                var itm = (Fornecedores)InputFornPri.SelectedItem;
                InputCodFornPri.Text = itm.Codigo.ToString();
            }
        }

        private void InputSubDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputSubDepartamento.SelectedItem != null)
            {
                var itm = (SubDepartamento)InputSubDepartamento.SelectedItem;
                InputCodSubDepartamento.Text = itm.CdDepartamento.ToString();
            }
        }

        private void InputUndMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputUndMed.SelectedItem != null)
            {
                var itm = (UnidadeMedida)InputUndMed.SelectedItem;
                InputCodUndMed.Text = itm.idUnida.ToString();
            }
        }

        private void InputCncm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCncm.SelectedItem != null)
            {
                var itm = (CNCM)InputCncm.SelectedItem;
                InputCodCncm.Text = itm.CodCNCM.ToString();
            }
        }

        private void InputSitTributa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputSitTributa.SelectedItem != null)
            {
                var itm = (SituacaoTributaria)InputSitTributa.SelectedItem;
                InputCodSitTributa.Text = itm.Codigo.ToString();
            }
        }

        private void InputCsonTribIcms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InputTipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputTipoProd.SelectedItem != null)
            {
                var itm = (TipoProduto)InputTipoProd.SelectedItem;
                InputCodTipoProd.Text = itm.Codigo.ToString();
            }
        }

        private void InputCorPredo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCorPredo.SelectedItem != null)
            {
                var itm = (Cor)InputCorPredo.SelectedItem;
                InputCodCorPredo.Text = itm.IdCor.ToString();
            }
        }


    }
}