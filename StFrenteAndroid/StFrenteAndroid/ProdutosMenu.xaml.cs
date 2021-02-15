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
	public partial class ProdutosMenu : ContentPage
	{
		public ProdutosMenu ()
		{
			InitializeComponent ();
            CarregaInfo();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        public void CarregaInfo()
        {
            CommandProdutos CmdP = new CommandProdutos();
            CmdP.CriarProduto();

            List<Produto> LProd = new List<Produto>();
            LProd = CmdP.GetProduto();

            Tabela_Produto.ItemsSource = LProd;
        }

        private void BtnCadProd_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new NovoProduto());
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MenuSistema());       
            return true;
        }

    }
}