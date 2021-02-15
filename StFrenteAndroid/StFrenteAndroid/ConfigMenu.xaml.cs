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
	public partial class ConfigMenu : ContentPage
	{
		public ConfigMenu ()
		{
			InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ConfigFiscal_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new CadFiscal());
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MenuSistema());
            return true;
        }

    }
}