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
	public partial class CadCores : PopupPage
    {
		public CadCores ()
		{
			InitializeComponent ();
            MontaTab();
        }

        public void MontaTab()
        {
            CommandCores CmdCores = new CommandCores();
            CmdCores.CriarBancoCores();
            List<Cor> Lcor = new List<Cor>();
            Lcor = CmdCores.GetCor();

            Tabela_Cores.ItemsSource = Lcor;
         
        }

        private void SalvarCor_Clicked(object sender, EventArgs e)
        {
            Boolean Salvar = true;
            int codigo = 1;
            if (InputCdCor.Text == "" || InputCdCor.Text == null)
            {
                CommandCores CmCr = new CommandCores();
                CmCr.CriarBancoCores();
                List<Cor> Lcr = CmCr.GetMax();
                if (Lcr.Count > 0)
                {
                    codigo = Lcr[0].IdCor + 1;
                }
            }
            else
            {
                codigo = Convert.ToInt32(InputCdCor.Text);
            }

            if (InputCor.Text == "" || InputCor.Text == null)
            {
                DownInputCodCor.IsVisible = true;
                DownInputCodCor.Text = "Informe a Cor";
                Salvar = false;
            }

            if (Salvar == true)
            {
                CommandCores CmdCores = new CommandCores();
                CmdCores.CriarBancoCores();

                Cor CodCor = new Cor();
                CodCor.IdCor = codigo;
                CodCor.Descricao = InputCor.Text;
                CmdCores.InserirCor(CodCor);
            }
            MontaTab();


        }

        private void Tabela_Cores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_Cores.SelectedItem != null) { 
            var ItemSelected = (Cor)Tabela_Cores.SelectedItem;
                InputCdCor.Text = ItemSelected.IdCor.ToString();
                InputCor.Text = ItemSelected.Descricao;

            }
        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (Cor)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover a Cor " + item.IdCor + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandCores CmdCor = new CommandCores();
                CmdCor.CriarBancoCores();

                CmdCor.DeletarComandaSQL(item);

                MontaTab();
            }
        }
    }
}