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
	public partial class CadCNCM : PopupPage
    {
		public CadCNCM ()
		{
			InitializeComponent();
            TabelaM();
        }

        public void TabelaM()
        {
            CommandCncm Cncm = new CommandCncm();
            Cncm.CriarBancoCNCM();
            List<CNCM> LCNCM = Cncm.GetCNCM();
            Tabela_CNCM.ItemsSource = LCNCM;

        }

        private void Tabela_CNCM_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_CNCM.SelectedItem != null)
            {
                var ItemSelected = (CNCM)Tabela_CNCM.SelectedItem;

                InputCodCNCM.Text = ItemSelected.CodCNCM.ToString();
                InputCNCM.Text = ItemSelected.Descricao;
                InputCEST.Text = ItemSelected.CEST;

            }
        }

        private void SalvarCNCM_Clicked(object sender, EventArgs e)
        {
            String SvCodigo = InputCodCNCM.Text;
            CNCM CN = new CNCM();
            CommandCncm CmdCncm = new CommandCncm();
            CmdCncm.CriarBancoCNCM();
            if (SvCodigo == "" || SvCodigo == null)
            {
                List<CNCM> LCncm = CmdCncm.GetMax();
                int Cod = 1;
                if (LCncm.Count > 0)
                {
                    Cod = LCncm[0].CodCNCM + 1;
                }
                CN.CodCNCM = Cod;
            }
            else
            {
                CN.CodCNCM = Convert.ToInt32(SvCodigo);
            }
            CN.Descricao = InputCNCM.Text;
            CN.CEST = InputCEST.Text;
            CmdCncm.InserirCNCM(CN);
            TabelaM();
        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (CNCM)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover a CNCM " + item.CodCNCM + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandCncm CmdCor = new CommandCncm();
                CmdCor.CriarBancoCNCM();

                CmdCor.DeletarCNCMSQL(item);

                TabelaM();
            }
        }

    }
}