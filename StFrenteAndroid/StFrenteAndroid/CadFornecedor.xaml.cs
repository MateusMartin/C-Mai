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
	public partial class CadFornecedor : PopupPage
	{
		public CadFornecedor ()
		{
			InitializeComponent ();
            ConsultaTab();

        }

        public void ConsultaTab()
        {
            CommandFornecedores CmdForn = new CommandFornecedores();           
            CmdForn.CriarBancoFornecedores();

            List<Fornecedores> LForn = CmdForn.GetFornecedores();
            Tabela_Fornecedores.ItemsSource = LForn;

        }

        private async void InputCEP_Unfocused(object sender, FocusEventArgs e)
        {
            String InpCep = InputCEP.Text;
            if (InpCep.Length == 9)
            {
                Endereco End = App.SvcManager.GetEndereco(InpCep);
                InputBairro.Text = End.Bairro;
                InputRua.Text = End.StrEndereco;
                InputUF.Text = End.Estado;
                InputCidade.Text = End.Cidade;
            }
        }

        private void SalvarForn_Clicked(object sender, EventArgs e)
        {
            String SForn = InputCodigoForn.Text;
   
            if (SForn == "" || SForn == null)
            {
                Boolean Salvar = true;

                if (InputRazaoSocial.Text == "" || InputRazaoSocial.Text == null)
                {
                    DownRazaoSocial.IsVisible = true;
                    DownRazaoSocial.Text = "Informe a Razão Social";
                    Salvar = false;
                }
                if (InputCEP.Text == "" || InputCEP.Text == null)
                {
                    DownCEP.IsVisible = true;
                    DownCEP.Text = "Informe o CEP";
                    Salvar = false;
                }
                if (InputRua.Text == "" || InputRua.Text == null)
                {
                    DownRua.IsVisible = true;
                    DownRua.Text = "Informe a Rua";
                    Salvar = false;
                }
                if (InputNumero.Text == "" || InputNumero.Text == null)
                {
                    DownNumero.IsVisible = true;
                    DownNumero.Text = "Informe o Número";
                    Salvar = false;
                }
                if (InputComplemento.Text == "" || InputComplemento.Text == null)
                {
                    InputComplemento.IsVisible = true;
                    InputComplemento.Text = "Informe o Complemento";
                    Salvar = false;
                }
                if (InputBairro.Text == "" || InputBairro.Text == null)
                {
                    DownBairro.IsVisible = true;
                    DownBairro.Text = "Informe o Bairro";
                    Salvar = false;
                }
                if (InputCidade.Text == "" || InputCidade.Text == null)
                {
                    DownCidade.IsVisible = true;
                    DownCidade.Text = "Informe a Cidade";
                    Salvar = false;
                }
                if (InputUF.Text == "" || InputUF.Text == null)
                {
                    DownUF.IsVisible = true;
                    DownUF.Text = "Informe o Estado";
                    Salvar = false;
                }
                if (InputCdMunicip.Text == "" || InputCdMunicip.Text == null)
                {
                    DownComplemento.IsVisible = true;
                    DownComplemento.Text = "Informe o Complemento";
                    Salvar = false;
                }
                if (InputCdPais.Text == "" || InputCdPais.Text == null)
                {
                    DownCdPais.IsVisible = true;
                    DownCdPais.Text = "Informe o Codigo do País";
                    Salvar = false;
                }
                if (InputPais.Text == "" || InputPais.Text == null)
                {
                    DownPais.IsVisible = true;
                    DownPais.Text = "Informe o País";
                    Salvar = false;
                }

                CommandFornecedores CmdForn = new CommandFornecedores();
                CmdForn.CriarBancoFornecedores();
                List<Fornecedores> LForn = CmdForn.GetMax();
                int Codigo = 1;
                if (LForn.Count > 0)
                {
                    Codigo = LForn[0].Codigo + 1;
                }

                if (Salvar == true)
                {
                    Fornecedores Forc = new Fornecedores();
                    Forc.Codigo = Codigo;
                    Forc.RazaoSocial = InputRazaoSocial.Text;
                    Forc.Cep = InputCEP.Text;
                    Forc.Rua = InputRua.Text;
                    Forc.Numero = InputNumero.Text;
                    Forc.Complemento = InputComplemento.Text;
                    Forc.Bairro = InputBairro.Text;
                    Forc.Cidade = InputCidade.Text;
                    Forc.UF = InputUF.Text;
                    Forc.CodigoDeMunicipios = InputCdMunicip.Text;
                    Forc.CodigoPais = InputCdPais.Text;
                    Forc.Pais = InputPais.Text;
                    Forc.CNPJ = InputCnpj.Text;
                    Forc.Inscricao = InputInscricao.Text;
                    Forc.Telefone1 = InputFone1.Text;
                    Forc.Telefone2 = InputFone2.Text;
                    Forc.DiferIcms = ChkDiferIcms.IsChecked;
                    Forc.Email = InputEmail.Text;
                    Forc.HomePage = InputHomePage.Text;
                    Forc.Banco = InputBanco.Text;
                    Forc.Agencia = InputAgencia.Text;
                    Forc.Conta = InputConta.Text;
                    Forc.Score = InputScore.Text;
                    Forc.Observacao = InputObs.Text;
                    CommandFornecedores CmFor = new CommandFornecedores();
                    CmFor.CriarBancoFornecedores();
                    CmFor.InserirFornecedores(Forc);
                }
            }
            else
            {
                Boolean Salvar = true;

                if (InputRazaoSocial.Text == "" || InputRazaoSocial.Text == null)
                {
                    DownRazaoSocial.IsVisible = true;
                    DownRazaoSocial.Text = "Informe a Razão Social";
                    Salvar = false;
                }
                if (InputCEP.Text == "" || InputCEP.Text == null)
                {
                    DownCEP.IsVisible = true;
                    DownCEP.Text = "Informe o CEP";
                    Salvar = false;
                }
                if (InputRua.Text == "" || InputRua.Text == null)
                {
                    DownRua.IsVisible = true;
                    DownRua.Text = "Informe a Rua";
                    Salvar = false;
                }
                if (InputNumero.Text == "" || InputNumero.Text == null)
                {
                    DownNumero.IsVisible = true;
                    DownNumero.Text = "Informe o Número";
                    Salvar = false;
                }
                if (InputComplemento.Text == "" || InputComplemento.Text == null)
                {
                    InputComplemento.IsVisible = true;
                    InputComplemento.Text = "Informe o Complemento";
                    Salvar = false;
                }
                if (InputBairro.Text == "" || InputBairro.Text == null)
                {
                    DownBairro.IsVisible = true;
                    DownBairro.Text = "Informe o Bairro";
                    Salvar = false;
                }
                if (InputCidade.Text == "" || InputCidade.Text == null)
                {
                    DownCidade.IsVisible = true;
                    DownCidade.Text = "Informe a Cidade";
                    Salvar = false;
                }
                if (InputUF.Text == "" || InputUF.Text == null)
                {
                    DownUF.IsVisible = true;
                    DownUF.Text = "Informe o Estado";
                    Salvar = false;
                }
                if (InputCdMunicip.Text == "" || InputCdMunicip.Text == null)
                {
                    DownComplemento.IsVisible = true;
                    DownComplemento.Text = "Informe o Complemento";
                    Salvar = false;
                }
                if (InputCdPais.Text == "" || InputCdPais.Text == null)
                {
                    DownCdPais.IsVisible = true;
                    DownCdPais.Text = "Informe o Codigo do País";
                    Salvar = false;
                }
                if (InputPais.Text == "" || InputPais.Text == null)
                {
                    DownPais.IsVisible = true;
                    DownPais.Text = "Informe o País";
                    Salvar = false;
                }

                if (Salvar == true)
                {
                    Fornecedores Forc = new Fornecedores();
                    Forc.Codigo = Convert.ToInt32(InputCodigoForn.Text);
                    Forc.RazaoSocial = InputRazaoSocial.Text;
                    Forc.Cep = InputCEP.Text;
                    Forc.Rua = InputRua.Text;
                    Forc.Numero = InputNumero.Text;
                    Forc.Complemento = InputComplemento.Text;
                    Forc.Bairro = InputBairro.Text;
                    Forc.Cidade = InputCidade.Text;
                    Forc.UF = InputUF.Text;
                    Forc.CodigoDeMunicipios = InputCdMunicip.Text;
                    Forc.CodigoPais = InputCdPais.Text;
                    Forc.Pais = InputPais.Text;
                    Forc.CNPJ = InputCnpj.Text;
                    Forc.Inscricao = InputInscricao.Text;
                    Forc.Telefone1 = InputFone1.Text;
                    Forc.Telefone2 = InputFone2.Text;
                    Forc.DiferIcms = ChkDiferIcms.IsChecked;
                    Forc.Email = InputEmail.Text;
                    Forc.HomePage = InputHomePage.Text;
                    Forc.Banco = InputBanco.Text;
                    Forc.Agencia = InputAgencia.Text;
                    Forc.Conta = InputConta.Text;
                    Forc.Score = InputScore.Text;
                    Forc.Observacao = InputObs.Text;
                    CommandFornecedores CmFor = new CommandFornecedores();
                    CmFor.CriarBancoFornecedores();
                    CmFor.AlterarFornecedores(Forc);
                }

            }
        }

        private void Consulta_Clicked(object sender, EventArgs e)
        {
            String Stg = Consulta.Text;

            if (Stg == "Consultar")
            {
                Consulta.Text = "Cadastro";
                StkCadastro.IsVisible = false;
                StkConsulta.IsVisible = true;
                SalvarForn.IsVisible = false;
                Filtrar.IsVisible = true;

                ConsultaTab();
            }
            else
            {
                Consulta.Text = "Consultar";
                StkCadastro.IsVisible = true;
                StkConsulta.IsVisible = false;
                SalvarForn.IsVisible = true;
                Filtrar.IsVisible = false;
            }
        }

        private async void InputCnpj_Unfocused(object sender, FocusEventArgs e)
        {
            String Cnpj = InputCnpj.Text;
            if (Cnpj.Length == 11)
            {
                Boolean Valida = ValidarCPF(Cnpj);
                if (Valida == true)
                {
                    string formatado = Convert.ToUInt64(Cnpj).ToString(@"000\.000\.000\-00");
                    InputCnpj.Text = formatado;
                }
                else
                {
                    await DisplayAlert("St Frente Android","Número de CPF Invalido","OK");
                }
            }
            else if (Cnpj.Length == 14)
            {
                Boolean Valida = IsCnpj(Cnpj);
                if (Valida == true)
                {                   
                    string formatado = Convert.ToUInt64(Cnpj).ToString(@"00\.000\.000\/0000\-00");
                    InputCnpj.Text = formatado;
                }
                else
                {
                    await DisplayAlert("St Frente Android", "Número de CNPJ Invalido", "OK");
                }
            }
            else
            {
                await DisplayAlert("St Frente Android", "Infome uma Quantidade de Caracteres Valida", "OK");
            }

        }

        public static bool ValidarCPF(string sourceCPF)
        {
            if (String.IsNullOrWhiteSpace(sourceCPF))
                return false;

            string clearCPF;
            clearCPF = sourceCPF.Trim();
            clearCPF = clearCPF.Replace("-", "");
            clearCPF = clearCPF.Replace(".", "");

            if (clearCPF.Length != 11)
            {
                return false;
            }

            int[] cpfArray;
            int totalDigitoI = 0;
            int totalDigitoII = 0;
            int modI;
            int modII;

            if (clearCPF.Equals("00000000000") ||
                clearCPF.Equals("11111111111") ||
                clearCPF.Equals("22222222222") ||
                clearCPF.Equals("33333333333") ||
                clearCPF.Equals("44444444444") ||
                clearCPF.Equals("55555555555") ||
                clearCPF.Equals("66666666666") ||
                clearCPF.Equals("77777777777") ||
                clearCPF.Equals("88888888888") ||
                clearCPF.Equals("99999999999"))
            {
                return false;
            }

            foreach (char c in clearCPF)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }

            cpfArray = new int[11];
            for (int i = 0; i < clearCPF.Length; i++)
            {
                cpfArray[i] = int.Parse(clearCPF[i].ToString());
            }

            for (int posicao = 0; posicao < cpfArray.Length - 2; posicao++)
            {
                totalDigitoI += cpfArray[posicao] * (10 - posicao);
                totalDigitoII += cpfArray[posicao] * (11 - posicao);
            }

            modI = totalDigitoI % 11;
            if (modI < 2) { modI = 0; }
            else { modI = 11 - modI; }

            if (cpfArray[9] != modI)
            {
                return false;
            }

            totalDigitoII += modI * 2;

            modII = totalDigitoII % 11;
            if (modII < 2) { modII = 0; }
            else { modII = 11 - modII; }
            if (cpfArray[10] != modII)
            {
                return false;
            }
            // CPF Válido!
            return true;
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private async void Tabela_Fornecedores_SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {          
            if (Tabela_Fornecedores.SelectedItem != null)
            {
                var ItemSelected = (Fornecedores)Tabela_Fornecedores.SelectedItem;
                Boolean Editar = await DisplayAlert("St Frente", "Deseja Editar o Cadastro do Fornecedor "+ItemSelected.RazaoSocial, "Sim", "Não");
                if (Editar == true)
                {

                    InputCodigoForn.Text = ItemSelected.Codigo.ToString();
                    InputRazaoSocial.Text = ItemSelected.RazaoSocial;
                    InputCEP.Text = ItemSelected.Cep;
                    InputRua.Text = ItemSelected.Rua;
                    InputNumero.Text = ItemSelected.Numero;
                    InputComplemento.Text = ItemSelected.Complemento;
                    InputBairro.Text = ItemSelected.Bairro;
                    InputCidade.Text = ItemSelected.Cidade;
                    InputUF.Text = ItemSelected.UF;
                    InputCdMunicip.Text = ItemSelected.CodigoDeMunicipios;
                    InputCdPais.Text = ItemSelected.CodigoPais ;
                    InputPais.Text = ItemSelected.Pais;

                    String Cpf_Cnpj = ""+ItemSelected.CNPJ;
                    Cpf_Cnpj = Cpf_Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                    string formatado = "";
                    if (Cpf_Cnpj.Length == 11)
                    { 
                     formatado = Convert.ToUInt64(Cpf_Cnpj).ToString(@"000\.000\.000\-00");
                    }
                    else if (Cpf_Cnpj.Length == 14)
                    { 
                     formatado = Convert.ToUInt64(Cpf_Cnpj).ToString(@"00\.000\.000\/0000\-00");
                    }else
                    {
                        formatado = Cpf_Cnpj;
                    }

                    InputCnpj.Text = formatado;
                    InputInscricao.Text = ItemSelected.Inscricao ;
                    InputFone1.Text = ItemSelected.Telefone1;
                    InputFone2.Text = ItemSelected.Telefone2 ;
                    ChkDiferIcms.IsChecked = ItemSelected.DiferIcms ;
                    InputEmail.Text = ItemSelected.Email;
                    InputHomePage.Text = ItemSelected.HomePage ;
                    InputBanco.Text = ItemSelected.Banco;
                    InputAgencia.Text = ItemSelected.Agencia;
                    InputConta.Text = ItemSelected.Conta ;
                    InputScore.Text = ItemSelected.Score ;
                    InputObs.Text = ItemSelected.Observacao;

                    Consulta.Text = "Consultar";
                    StkCadastro.IsVisible = true;
                    StkConsulta.IsVisible = false;

                    SalvarForn.IsVisible = true;
                    Filtrar.IsVisible = false;

                }
                else
                {
                    Tabela_Fornecedores.SelectedItem = null;
                }
            }
        }

        private void ChkRazao_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkRazao.IsChecked == true)
            {
                ChkCidade.IsChecked = false;
                ChkCnpj.IsChecked = false;
                LblFiltro.Text = "Razão Social";
            }
        }

        private void ChkCidade_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkCidade.IsChecked == true)
            {
                ChkRazao.IsChecked = false;
                ChkCnpj.IsChecked = false;
                LblFiltro.Text = "Cidade";
            }
        }

        private void ChkCnpj_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ChkCnpj.IsChecked == true)
            {
                ChkCidade.IsChecked = false;
                ChkRazao.IsChecked = false;
                LblFiltro.Text = "CNPJ/CPF";
            }
        }

        private void Filtrar_Clicked(object sender, EventArgs e)
        {

            if (ChkRazao.IsChecked == false && ChkCidade.IsChecked == false && ChkCnpj.IsChecked == false)
            {



            }
            else
            {

                if (InputFiltro.Text != "" && InputFiltro.Text != null)
                {
                    String TipoFilt = "";
                    String Filtro = "";
                    if (ChkRazao.IsChecked == true)
                    {
                        TipoFilt = "Razao";
                    }
                    if (ChkCidade.IsChecked == true)
                    {
                        TipoFilt = "Cidade";
                    }
                    if (ChkCnpj.IsChecked == true)
                    {
                        TipoFilt = "CNPJ";
                    }
                    Filtro = InputFiltro.Text;
                    CommandFornecedores CmFor = new CommandFornecedores();
                    CmFor.CriarBancoFornecedores();
                    List<Fornecedores> LForn = CmFor.GetFiltroFornecedores(TipoFilt, Filtro);
                    Tabela_Fornecedores.ItemsSource = LForn;
                }

            }

        }

        private async void InputFiltro_Unfocused(object sender, FocusEventArgs e)
        {
            if (ChkCnpj.IsChecked == true)
            {
                String Cnpj = InputFiltro.Text;
                if (Cnpj.Length == 11)
                {
                    Boolean Valida = ValidarCPF(Cnpj);
                    if (Valida == true)
                    {
                        string formatado = Convert.ToUInt64(Cnpj).ToString(@"000\.000\.000\-00");
                        InputFiltro.Text = formatado;
                    }
                    else
                    {
                        await DisplayAlert("St Frente Android", "Número de CPF Invalido", "OK");
                    }
                }
                else if (Cnpj.Length == 14)
                {
                    Boolean Valida = IsCnpj(Cnpj);
                    if (Valida == true)
                    {
                        string formatado = Convert.ToUInt64(Cnpj).ToString(@"00\.000\.000\/0000\-00");
                        InputFiltro.Text = formatado;
                    }
                    else
                    {
                        await DisplayAlert("St Frente Android", "Número de CNPJ Invalido", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("St Frente Android", "Infome uma Quantidade de Caracteres Valida", "OK");
                }


            }
        }


    }
}