using Rg.Plugins.Popup.Pages;
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
	public partial class CadUnidadeMedida :  PopupPage
	{
		public CadUnidadeMedida ()
		{
			InitializeComponent ();
            CarregaTab();

        }

        public void CarregaTab()
        {
            CommandUnidadeMedida CmdUn = new CommandUnidadeMedida();
            CmdUn.CriarUnidadeMedida();
            List<UnidadeMedida> LUnMed = CmdUn.GetUnidadeMedida();

            Tabela_UnidadeMedida.ItemsSource = LUnMed;
        }

        private void SalvarUnidadeMedida_Clicked(object sender, EventArgs e)
        {
            String String = InputCadUnidadeMedida.Text;
            UnidadeMedida UniM = new UnidadeMedida();
            CommandUnidadeMedida CmUnid = new CommandUnidadeMedida();

            if (String == "" || String == null)
            {
                List<UnidadeMedida> LCncm = CmUnid.GetMax();
                int Cod = 1;
                if (LCncm.Count > 0)
                {
                    Cod = LCncm[0].idUnida + 1;
                }
                UniM.idUnida = Cod;
            }
            else
            {
                UniM.idUnida = Convert.ToInt32(InputCadUnidadeMedida.Text);
            }
            UniM.Descricao = InputUnidadeMedida.Text;
            CmUnid.InserirUnidadeMedida(UniM);
            CarregaTab();
        }

        private void Tabela_UnidadeMedida_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_UnidadeMedida.SelectedItem != null)
            {
                var ItemSelected = (UnidadeMedida)Tabela_UnidadeMedida.SelectedItem;

                InputCadUnidadeMedida.Text = ItemSelected.idUnida.ToString();
                InputUnidadeMedida.Text = ItemSelected.Descricao;        

            }
        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (UnidadeMedida)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover a Unidade Medida" + item.idUnida + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandUnidadeMedida CmdCor = new CommandUnidadeMedida();
                CmdCor.CriarUnidadeMedida();

                CmdCor.DeletarUnidadeMedida(item);

                CarregaTab();
            }
        }

    
    }
}