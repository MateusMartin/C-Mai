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
	public partial class CadDepartamento : PopupPage
    {
		public CadDepartamento ()
		{
			InitializeComponent ();

            MontaTab();
        }

        public void MontaTab()
        {
            CommandDepartamento CmdCores = new CommandDepartamento();
            CmdCores.CriarBancoDepartamento();
            List<Departamento> LDep = new List<Departamento>();
            LDep = CmdCores.GetDepartamento();

            Tabela_Departamento.ItemsSource = LDep;
        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (Departamento)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover a Cor " + item.IdDepart + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandDepartamento CmdCor = new CommandDepartamento();
                CmdCor.CriarBancoDepartamento();

                CmdCor.DeletarDepartamento(item);

                MontaTab();
            }
        }

        private void Tabela_Departamento_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_Departamento.SelectedItem != null)
            {
                var ItemSelected = (Departamento)Tabela_Departamento.SelectedItem;
                InputCodDepartamento.Text = ItemSelected.IdDepart.ToString();
                InputDepartamento.Text = ItemSelected.Descricao;
            }
        }

        private void SalvarDepartamento_Clicked(object sender, EventArgs e)
        {
            Boolean Salvar = true;
            int cod = 1;
            if (InputCodDepartamento.Text == "" || InputCodDepartamento.Text == null)
            {
                CommandDepartamento Cmd = new CommandDepartamento();
                Cmd.CriarBancoDepartamento();
                List<Departamento> LDprt = Cmd.GetDepartamento();
                if (LDprt.Count > 0)
                {
                    cod = LDprt[0].IdDepart;
                }
            }
            else
            {
                cod = Convert.ToInt32(InputCodDepartamento.Text);
            }

            if (InputDepartamento.Text == "" || InputDepartamento.Text == null)
            {
                DownInputDepartamento.IsVisible = true;
                DownInputDepartamento.Text = "Informo o Departamento";
                Salvar = false;
            }

            if (Salvar == true)
            {
                CommandDepartamento CmdCores = new CommandDepartamento();
                CmdCores.CriarBancoDepartamento();

                Departamento CodDep = new Departamento();
                CodDep.IdDepart = cod;
                CodDep.Descricao = InputDepartamento.Text;
                CodDep.Carrinho = ChkCompras.IsChecked;
                CmdCores.InserirDepartamento(CodDep);
            }
            MontaTab();
        }
    }
}