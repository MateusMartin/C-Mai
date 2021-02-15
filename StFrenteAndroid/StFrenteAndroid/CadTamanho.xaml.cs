using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using StFrenteAndroid.Models;
using StFrenteAndroid.SQL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StFrenteAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadTamanho : PopupPage
    {
		public CadTamanho ()
		{
			InitializeComponent ();
            MontaTab();

        }

        public void MontaTab()
        {

            CommandTamanho CmdCores = new CommandTamanho();
            CmdCores.CriarBancoCores();
            List<Tamanho> LCDTAM = new List<Tamanho>();
            LCDTAM = CmdCores.GetCadTamanho();

            Tabela_Tamanhos.ItemsSource = LCDTAM;

        }        

        private void Tabela_Tamanhos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_Tamanhos.SelectedItem != null)
            {
                var ItemSelected = (Tamanho)Tabela_Tamanhos.SelectedItem;
                InputCdTam.Text = ItemSelected.IdTam.ToString();
                InputTam.Text = ItemSelected.Descricao;

            }
        }

        private void SalvarTama_Clicked(object sender, EventArgs e)
        {
            Boolean Salvar = true;
            int cod = 1;
            if (InputCdTam.Text == "" || InputCdTam.Text == null)
            {
                CommandTamanho Ctam = new CommandTamanho();
                List<Tamanho> LTam = Ctam.GetMax();
                if (LTam.Count > 0)
                {
                    cod = LTam[0].IdTam + 1;
                }
            }
            else
            {
                cod = Convert.ToInt32(InputCdTam.Text);
            }

            if (InputTam.Text == "" || InputTam.Text == null)
            {
                DownInputTaman.IsVisible = true;
                DownInputTaman.Text = "Informe o Tamanho";
                Salvar = true;
            }

            if (Salvar == true)
            {
                CommandTamanho CmdCores = new CommandTamanho();
                CmdCores.CriarBancoCores();

                Tamanho CodTam = new Tamanho();
                CodTam.IdTam = cod;
                CodTam.Descricao = InputTam.Text;
                CmdCores.InserirCadTamanho(CodTam);
            }
            MontaTab();

        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (Tamanho)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover a Cor " + item.IdTam + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandTamanho CmdCor = new CommandTamanho();
                CmdCor.CriarBancoCores();

                CmdCor.DeletarCadTamanho(item);

                MontaTab();
            }
        }

    }
}