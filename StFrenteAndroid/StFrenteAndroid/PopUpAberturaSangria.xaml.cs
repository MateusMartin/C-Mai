using Rg.Plugins.Popup.Pages;
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
	public partial class PopUpAberturaSangria : PopupPage
    {
		public PopUpAberturaSangria()
		{
			InitializeComponent();
            Carrega();
        }

        public void Carrega()
        {

            CommandSaldo Cmd = new CommandSaldo();
            Cmd.CriarBancoSaldo();

            String DtAt = DateTime.Now.ToString(1+"ddMMyyyy");
            List<Saldo> LSaldo = Cmd.GetSaldoIfAberto(DtAt);
            if (LSaldo.Count > 0)
            {
                ChkAbertura.IsEnabled = false;
                ChkAbertura.Color = Color.Gray;              
            }
            else
            {
                ChkAbertura.IsEnabled = true;
            }

        }

        private async void BtnOkVlr_Clicked(object sender, EventArgs e)
        {
            if (ChkAbertura.IsChecked == false && ChkSuprimento.IsChecked == false && ChkSangria.IsChecked == false && ChkFechamento.IsChecked == false)
            {
                await DisplayAlert("St Frente","Selecione um tipo de operação","OK");
            }
            else
            {
                Saldo Svr = new Saldo();
                CommandSaldo CmdSal = new CommandSaldo();
                String Dt = DateTime.Now.ToString("ddMMyyyy");
                Svr.Chave = "1" + Dt;
                Svr.Data = DateTime.Now;
                String valor = InputValor.Text;
                valor = valor.Replace(".",",");
                if (ChkAbertura.IsChecked == true)
                {
                    Svr.Historico = "Abertura de Caixa";
                    Svr.Valor = Convert.ToDouble(valor);
                    Svr.operador = 1;
                    Svr.Tipo = 1;
                }
                else if (ChkSuprimento.IsChecked == true)
                {
                    Svr.Historico = "Suprimento";
                    Svr.Valor = Convert.ToDouble(valor);
                    Svr.operador = 1;
                    Svr.Tipo = 2;
                }
                else if (ChkSangria.IsChecked == true)
                {
                    Svr.Historico = "Sangria";
                    Svr.Valor = -Convert.ToDouble(valor);
                    Svr.operador = 1;
                    Svr.Tipo = 3;
                }
                else
                {
                    Svr.Historico = "Fechamento";
                    Svr.Valor = -Convert.ToDouble(valor);
                    Svr.operador = 1;
                    Svr.Tipo = 4;
                }
                CmdSal.CriarBancoSaldo();
                CmdSal.InserirSaldo(Svr);
                Carrega();
            }
        }
        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }

        private void ChkFechamento_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkFechamento.IsChecked == true)
            {
                if (ChkSangria.IsChecked == true)
                {
                    ChkSangria.IsChecked = false;
                }
                if (ChkSuprimento.IsChecked == true)
                {
                    ChkSuprimento.IsChecked = false;
                }
                if (ChkAbertura.IsChecked == true)
                {
                    ChkAbertura.IsChecked = false;
                }
            }
        }

        private void ChkSangria_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkSangria.IsChecked == true)
            {
                if (ChkFechamento.IsChecked == true)
                {
                    ChkFechamento.IsChecked = false;
                }
                if (ChkSuprimento.IsChecked == true)
                {
                    ChkSuprimento.IsChecked = false;
                }
                if (ChkAbertura.IsChecked == true)
                {
                    ChkAbertura.IsChecked = false;
                }
            }
        }

        private void ChkSuprimento_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkSuprimento.IsChecked == true)
            {
                if (ChkFechamento.IsChecked == true)
                {
                    ChkFechamento.IsChecked = false;
                }
                if (ChkSangria.IsChecked == true)
                {
                    ChkSangria.IsChecked = false;
                }
                if (ChkAbertura.IsChecked == true)
                {
                    ChkAbertura.IsChecked = false;
                }
            }
        }

        private void ChkAbertura_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkAbertura.IsChecked == true)
            {
                if (ChkFechamento.IsChecked == true)
                {
                    ChkFechamento.IsChecked = false;
                }
                if (ChkSangria.IsChecked == true)
                {
                    ChkSangria.IsChecked = false;
                }
                if (ChkSuprimento.IsChecked == true)
                {
                    ChkSuprimento.IsChecked = false;
                }
            }
        }


    }
}