using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class PopUpProdutosCadastrosSub : PopupPage
	{
		public PopUpProdutosCadastrosSub ()
		{
			InitializeComponent ();

            TapLoad();

        }
        
        public void TapLoad()
        {
            var IdCores_tap = new TapGestureRecognizer();
            IdCores_tap.Tapped += async (s, e) =>
            {
                var app = new CadCores();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);

            };
            IdCores.GestureRecognizers.Add(IdCores_tap);

            var IdTamanhos_tap = new TapGestureRecognizer();
            IdTamanhos_tap.Tapped += async (s, e) =>
            {
                var app = new CadTamanho();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);

            };
            IdTamanhos.GestureRecognizers.Add(IdTamanhos_tap);

            var IdDepartamentos_tap = new TapGestureRecognizer();
            IdDepartamentos_tap.Tapped += async (s, e) =>
            {
                var app = new CadDepartamento();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);

            };
            IdDepartamentos.GestureRecognizers.Add(IdDepartamentos_tap);


            var IdFornecedores_tap = new TapGestureRecognizer();
            IdFornecedores_tap.Tapped += async (s, e) =>
            {
                var app = new CadFornecedor();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);

            };
            IdFornecedores.GestureRecognizers.Add(IdFornecedores_tap);

            var IdSubDepartamentos_tap = new TapGestureRecognizer();
            IdSubDepartamentos_tap.Tapped += async (s, e) =>
            {
                var app = new CadSubDepartamento();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);
            };
            IdSubDepartamentos.GestureRecognizers.Add(IdSubDepartamentos_tap);
            
            var IdCNCM_tap = new TapGestureRecognizer();
            IdCNCM_tap.Tapped += async (s, e) =>
            {
                var app = new CadCNCM();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);
            };
            IdCNCM.GestureRecognizers.Add(IdCNCM_tap);

            var IdUnidadeDeMedida_tap = new TapGestureRecognizer();
            IdUnidadeDeMedida_tap.Tapped += async (s, e) =>
            {
                var app = new CadUnidadeMedida();
                await PopupNavigation.PopAsync();
                await PopupNavigation.PushAsync(app);
            };
            IdUnidadeDeMedida.GestureRecognizers.Add(IdUnidadeDeMedida_tap);

        }
    }
}