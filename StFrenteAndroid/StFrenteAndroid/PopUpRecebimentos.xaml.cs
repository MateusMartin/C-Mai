using Rg.Plugins.Popup.Pages;
using StFrenteAndroid.Models;
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
	public partial class PopUpRecebimentos : PopupPage
	{
		public PopUpRecebimentos (CupomPri Venda)
		{
			InitializeComponent ();

            LblNumeroVenda.Text = Venda.ID_CP.ToString();
            InputVlrVenda.Text = Venda.TOTAL_CP.ToString();
            InputSaldo.Text = Venda.TOTAL_CP.ToString();

        }

        private void InputFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}