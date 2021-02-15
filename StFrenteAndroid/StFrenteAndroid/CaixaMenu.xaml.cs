using Rg.Plugins.Popup.Services;
using StFrenteAndroid.Models;
using StFrenteAndroid.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StFrenteAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaixaMenu : ContentPage
    {
        public CaixaMenu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregaProduto();
            CarregaVenda();

            /**
                CommandCupomPri Cpri = new CommandCupomPri();
                Cpri.DeletarTabelaCupomPri();
                CommandCupomSec Csec = new CommandCupomSec();
                Csec.DeletarTabelaCupomSec();
            */

        }

        public void CarregaProduto()
        {
            CommandProdutos Cmd = new CommandProdutos();
            List<Produto> LProd = new List<Produto>();
            LProd = Cmd.GetProduto();
            InputProduto.ItemsSource = LProd;
        }

        private async void BtnAbertura_Clicked(object sender, EventArgs e)
        {
            var app = new PopUpAberturaSangria();
            await PopupNavigation.PushAsync(app);
        }

        private void BtnRemover_Clicked(object sender, EventArgs e)
        {

        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MenuSistema());
            return true;
        }

        private void InputProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Produto = (Produto)InputProduto.SelectedItem;
            InputCodProduto.Text = Produto.Codigo.ToString();
            InputQuantidade.Text = Produto.QtdPadrao.ToString();
            InputVlrUnit.Text = Produto.PrcoVendUnd.ToString();
            Double vlr = Produto.PrcoVendUnd * Produto.QtdPadrao;
            InputVlrTotItm.Text = vlr.ToString();

        }

        private void BtnAdcionar_Clicked(object sender, EventArgs e)
        {
            Boolean Adcionar = true;

            if (InputQuantidade.Text == "" || InputQuantidade.Text == null)
            {
                DownInputQuantidade.Text = "Informe a Quantidade do Produto";
                DownInputQuantidade.IsVisible = true;

                Adcionar = false;
            }

            if (InputCodProduto.Text == "" || DownInputProduto.Text == null)
            {
                DownInputCodProduto.Text = "";
                DownInputCodProduto.IsVisible = true;

                Adcionar = true;
            }

            if (InputProduto.SelectedItem == null)
            {
                DownInputProduto.Text = "Selecione o Produto";
                DownInputProduto.IsVisible = true;

                Adcionar = false;
            }

            if (Adcionar == true)
            {
                CommandCupomPri CmdPri = new CommandCupomPri();
                CmdPri.CriarBancoCupomPri();

                List<CupomPri> LCPri = CmdPri.GetCupomPriAberta();

                if (LCPri.Count == 0)
                {
                    CupomPri CmPri = new CupomPri();
                    CmPri.DATA_CP = DateTime.Now;
                    CmPri.HORA_CP = DateTime.Now;
                    CmPri.STATUS_CP = true;
                    CmPri.OPERADOR_CP = 1;
                    CmPri.RETAG_CP = false;
                    CmPri.FECHADO_CP = false;
                    CmPri.FORMAPG_CP = "3105";
                    CmPri.TOTAL_CP = Convert.ToDouble(InputVlrTotItm.Text);
                    CmPri.VENDEDOR_CP = 1;
                    CmPri.NFCE_CP = "";
                    CmPri.EMITIDANFCE_CP = false;
                    CmPri.NFCEATIVA_CP = 1;
                    CmPri.CLIENTE_CP = 1;
                    CmPri.CPF_CP = "";

                    Boolean BlTrue = CmdPri.InserirCupomPri(CmPri);

                    if (BlTrue == true)
                    {
                        List<CupomPri> LPri = CmdPri.GetMax();

                        if (LPri.Count > 0)
                        {
                            CommandCupomSec CmdSec = new CommandCupomSec();
                            CmdSec.CriarBancoCupomSec();
                            List<CupomSec> LsCpm = CmdSec.GetCupomSecIdPri(LPri[0].ID_CP);

                            var Produto = (Produto)InputProduto.SelectedItem;

                            CupomSec CpmSec = new CupomSec();
                            CpmSec.ID_CS = LPri[0].ID_CP;
                            CpmSec.ITEM_CS = LsCpm.Count() + 1;
                            CpmSec.CODPRO_CS = Produto.Codigo;
                            CpmSec.DESCRI_CS = Produto.Descricao;
                            CpmSec.ALIQUOTA_CS = "01";
                            CpmSec.QTDE_CS = Convert.ToDouble(InputQuantidade.Text);
                            CpmSec.VLRUNI_CS = Produto.PrcoVendUnd;
                            CpmSec.VLRTOT_CS = Produto.PrcoVendUnd * Convert.ToDouble(InputQuantidade.Text);
                            CpmSec.CUSTO_CS = Produto.CustoUnd;
                            CpmSec.GRADE_CS = "";
                            CpmSec.DESCONTO_CS = 0;
                            CpmSec.STATUS_CS = true;
                            CpmSec.TRIBUTOS_CS = 0;

                            CmdSec.InserirCupomPri(CpmSec);                                                       
                        }
                    }
                    InputSubTotal.Text = CmPri.TOTAL_CP.ToString();

                    CarregaVenda();
                }
                else
                {

                    CommandCupomSec CmdSec = new CommandCupomSec();
                    CmdSec.CriarBancoCupomSec();
                    List<CupomSec> LsCpm = CmdSec.GetCupomSecIdPri(LCPri[0].ID_CP);

                    var Produto = (Produto)InputProduto.SelectedItem;

                    CupomSec CpmSec = new CupomSec();
                    CpmSec.ID_CS = LCPri[0].ID_CP;
                    CpmSec.ITEM_CS = LsCpm.Count() + 1;
                    CpmSec.CODPRO_CS = Produto.Codigo;
                    CpmSec.DESCRI_CS = Produto.Descricao;
                    CpmSec.ALIQUOTA_CS = "01";
                    CpmSec.QTDE_CS = Convert.ToDouble(InputQuantidade.Text);
                    CpmSec.VLRUNI_CS = Produto.PrcoVendUnd;
                    CpmSec.VLRTOT_CS = Produto.PrcoVendUnd * Convert.ToDouble(InputQuantidade.Text);
                    CpmSec.CUSTO_CS = Produto.CustoUnd;
                    CpmSec.GRADE_CS = "";
                    CpmSec.DESCONTO_CS = 0;
                    CpmSec.STATUS_CS = true;
                    CpmSec.TRIBUTOS_CS = 0;

                    CmdSec.InserirCupomPri(CpmSec);

                    LCPri[0].TOTAL_CP = LCPri[0].TOTAL_CP + (Produto.PrcoVendUnd * Convert.ToDouble(InputQuantidade.Text));
                    CmdPri.ReplaceCupomPri(LCPri[0]);
                    CarregaVenda();

                }
            }
        }


        public void CarregaVenda()
        {
            CommandCupomPri CmPri = new CommandCupomPri();  
            CmPri.CriarBancoCupomPri();

            List<CupomPri> LCmpri = CmPri.GetCupomPriAberta();
            if (LCmpri.Count > 0)
            {
                int CdPri = LCmpri[0].ID_CP;

                CommandCupomSec CmSec = new CommandCupomSec();
                CmSec.CriarBancoCupomSec();

                List<CupomSec> LCupSec = CmSec.GetCupomSecIdPri(CdPri);

                InputSubTotal.Text = LCmpri[0].TOTAL_CP.ToString();

                Tabela_St_Frente.ItemsSource = LCupSec;
            }
        }

        private void InputQuantidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputProduto.SelectedItem != null)
            {
                if (InputQuantidade.Text != "" && InputQuantidade.Text != null)
                {
                    var ImpProdu = (Produto)InputProduto.SelectedItem;

                    int Qtde = Convert.ToInt32(InputQuantidade.Text);

                    Double DblPr = ImpProdu.PrcoVendUnd * Qtde;

                    InputVlrTotItm.Text = DblPr.ToString();
                }
            }
        }

        private void InputQuantidade_Unfocused(object sender, FocusEventArgs e)
        {
            if (InputQuantidade.Text == "" || InputQuantidade.Text == null)
            {
                InputQuantidade.Text = "1";
            }
        }

        private async void BtnFecharVenda_Clicked(object sender, EventArgs e)
        {
            CommandCupomPri CmdPri = new CommandCupomPri();
            CmdPri.CriarBancoCupomPri();
            List<CupomPri> LPri = CmdPri.GetCupomPriAberta();
            if (LPri.Count > 0)
            { 
                var app = new PopUpRecebimentos(LPri[0]);
                await PopupNavigation.PushAsync(app);
            }
        }

        private void BtnCancelarVenda_Clicked(object sender, EventArgs e)
        {

        }
    }
}