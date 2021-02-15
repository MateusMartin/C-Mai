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
    public partial class MenuSistema : ContentPage
    {
        public MenuSistema()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Config_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ConfigMenu());

        }

        private void Produtos_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ProdutosMenu());

        }

        protected override bool OnBackButtonPressed()
        {

            return true;
        }

        private void Caixa_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new CaixaMenu());
        }
    }
}