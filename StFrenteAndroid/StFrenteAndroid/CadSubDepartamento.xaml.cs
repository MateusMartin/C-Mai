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
    public partial class CadSubDepartamento : PopupPage
    {
        public CadSubDepartamento()
        {
            InitializeComponent();
            Select();
            CarregaTab();
        }

        public void Select()
        {
            CommandDepartamento Cmd = new CommandDepartamento();            
            Cmd.CriarBancoDepartamento();
            List<Departamento> Depart = Cmd.GetDepartamento();
            pickerDepartamento.ItemsSource = Depart;
        }

        public void CarregaTab()
        {
            CommandSubDepartamento CmdSub = new CommandSubDepartamento();
            CmdSub.CriarBancoSubDepartamento();
            List<SubDepartamento> LSub = CmdSub.GetTabSubDepartamento();
            Tabela_SubDepartamento.ItemsSource = LSub;


        }

        private void SalvarSubDepart_Clicked(object sender, EventArgs e)
        {
            String CdSubDepart = InputCodSubDepart.Text;
            SubDepartamento Dpart = new SubDepartamento();
            CommandSubDepartamento CmdSub = new CommandSubDepartamento();
            CmdSub.CriarBancoSubDepartamento();
            Dpart.Descricao = InputDescricao.Text;
            if (pickerDepartamento.SelectedItem != null)
            {
                var subDerp = (Departamento)pickerDepartamento.SelectedItem;
                Dpart.CodSubDepartamento = subDerp.IdDepart;
            }
            if (InputCodSubDepart.Text == "" || InputCodSubDepart.Text == null)
            {         
                List<SubDepartamento> Dep = CmdSub.GetMax();
                int cod = 1;
                if (Dep.Count != 0)
                {
                    cod = Dep[0].CodSubDepartamento + 1;
                }
                Dpart.CodSubDepartamento = cod;
               
                if (pickerDepartamento.SelectedItem != null)
                {
                    var PkDepartamento = (Departamento)pickerDepartamento.SelectedItem;
                    Dpart.CdDepartamento = PkDepartamento.IdDepart;
                }
            }
            CmdSub.InserirSubDepartamento(Dpart);
            CarregaTab();

            InputCodSubDepart.Text = "";
            InputDescricao.Text = "";
            pickerDepartamento.SelectedItem = null;

        }

        private void Tabela_SubDepartamento_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Tabela_SubDepartamento.SelectedItem != null)
            {
                var TabSub = (SubDepartamento)Tabela_SubDepartamento.SelectedItem;

                InputCodSubDepart.Text = TabSub.CodSubDepartamento.ToString();
                InputDescricao.Text = TabSub.Descricao;

                List<Departamento> LDep = (List<Departamento>)pickerDepartamento.ItemsSource;
                int i = 0;
                int a = 0;
                foreach (Departamento Dep in LDep)
                {
                    if (Dep.IdDepart == TabSub.CdDepartamento)
                    {
                        a = i;
                    }
                        i++;                   
                }
                pickerDepartamento.SelectedIndex = a;
            }

        }

        private async void BtnRemover_Clicked(object sender, EventArgs e)
        {
            var send = sender as Button;
            var item = (SubDepartamento)send.CommandParameter;

            bool answer = await DisplayAlert("Comanda", "Deseja Remover o Sub Departamento " + item.CodSubDepartamento + "  " + item.Descricao, "Sim", "Não");
            if (answer == true)
            {
                CommandSubDepartamento CmdCor = new CommandSubDepartamento();
                CmdCor.CriarBancoSubDepartamento();

                CmdCor.DeletarSubDepartamento(item);

                CarregaTab();
            }
        }
    }
}