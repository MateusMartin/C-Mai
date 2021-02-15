using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using StFrenteAndroid.Assina;
using StFrenteAndroid.Models;
using StFrenteAndroid.SQL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StFrenteAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadFiscal : ContentPage
	{
        public CadFiscal ()
		{
			InitializeComponent ();
            BuscaDados();    
            NavigationPage.SetHasNavigationBar(this, false);
        }      
        public void BuscaDados()
        {       
            CommandNfePadrao Cmd = new CommandNfePadrao();
            Cmd.CriarBancoNfePadrao();

            List<NfePadrao> LNfeP = Cmd.GetNfePadrao();
            if (LNfeP.Count > 0)
            {
                foreach (NfePadrao Crt in LNfeP)
                {
                    InputNomFantasia.Text = Crt.NOME_PN;
                    InputCnpj.Text = Crt.CNPJ_PN;
                    InputLogradouro.Text = Crt.ENDERECO_PN;
                    InputNumero.Text = Crt.NUMERO_PN;
                    InputComplemento.Text = Crt.CPL_PN;
                    InputBairro.Text = Crt.bairro_pn;
                    InputCodMunicipio.Text = Crt.CODMUN_PN;
                    InputMunicipio.Text = Crt.CIDADE_PN;
                    InputUF.Text = Crt.uf_PN;
                    InputCEP.Text = Crt.CEP_PN;
                    InputFone.Text = Crt.FONE_PN;
                    InputInsEstadual.Text = Crt.IE_PN;
                    InputNtFiscal.Text = Crt.SERIE_PN.ToString();
                    InputPathCertificado.Text = Crt.PATH_CHAVE;
                    InputSenhaCertificado.Text = Crt.SENHA_CERTIFICADO;
                    InputAmbAt.Text = Crt.AMBIENTE_PN.ToString();
                    InputCodUF.Text = Crt.CODUF_PN;
                    InputRazaoSocial.Text = Crt.RAZAO_PN;
                    int BcIcms = Crt.BASEICMS_PN;
                    PkModalBcICMS.SelectedIndex = BcIcms;
                    int iBaseIcmsSt = Crt.BASEST_PN;
                    PkModalBcICMSST.SelectedIndex = iBaseIcmsSt - 1;
                    int IRgt = Crt.SIMPLES_PN;
                    PkRegimeTrib.SelectedIndex = IRgt -1;
                    InputEmailDestino.Text = Crt.EMAIL_PN;                    
                    DownInputAlicotaICMS.Text = Crt.PERCREDCSO.ToString();
                    Boolean Ipi = Crt.IPI_PN;                        
                    InputContribIpi.IsChecked = Ipi;
                    Boolean Imprimi = Crt.IMPRIMEAMBOS_PN;
                    InputDadClie.Text = Crt.ISENTO_ATE;
                    InputIdTolk.Text = Crt.cIdToken;
                    InputCSC.Text = Crt.CSC;
                    //Crt.TIPOCNPJBAIXAR_PN = ;
                    //Crt.CNPJBAIXAR_prd = "";
                    //Crt.MODELO_PN   = .Text;
                    //Crt.Msg_fisco  = "";
                    //Crt.Msg_Contri  = "";
                    //Crt.LOCBACK_PN   = "";
                    //Crt.PATH_SCHEMAS  = null;
                    //Crt.PATH_MOVIMENTO = null;

                }
            }
        }
        private async void InputPathCertificado_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();
                // the dataarray of the file will be found in filedata.DataArray 
                // file name will be found in filedata.FileName;
                //etc etc.
                if (filedata != null)
                {
                    InputPathCertificado.Text = filedata.FilePath;
                }
            }
            catch (Exception ex)
            {
               String Exs = ex.ToString();
            }
        }
        private async void InputPathArquivar_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();
            }
            catch (Exception ex)
            {
                String Exs = ex.ToString();
            }
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new ConfigMenu());
            return true;
        }
        private void BtnGravar_Clicked(object sender, EventArgs e)
        {
            NfePadrao Crt = new NfePadrao();
            CommandNfePadrao CmCert = new CommandNfePadrao();
            CmCert.CriarBancoNfePadrao();
            Boolean Cria = true;
        
            if (InputNtFiscal.Text == "" || InputNtFiscal.Text == null)
            {
                DownInputNtFiscal.Text = "Informe a Série da nota";
                DownInputNtFiscal.IsVisible = true;
                Cria = false;
            }
            if (InputAmbAt.Text == "" || InputAmbAt.Text == null)
            {
                DownInputAmbAt.Text = "Informe o Ambiente Atual";
                DownInputAmbAt.IsVisible = true;
                Cria = false;
            }
            if (InputRazaoSocial.Text == "" || InputRazaoSocial.Text == null)
            {
                DownInputRazaoSocial.Text = "Informe a Razão Social";
                DownInputRazaoSocial.IsVisible = true;
                Cria = false;
            }
            if (InputNomFantasia.Text == "" || InputNomFantasia.Text == null)
            {
                DownInputNomFantasia.Text = "Informe o Nome Fantasia";
                DownInputNomFantasia.IsVisible = true;
                Cria = false;
            }
            if (InputCnpj.Text == "" || InputCnpj.Text == null)
            {
                DownInputCnpj.Text = "Informe o CNPJ";
                DownInputCnpj.IsVisible = true;
                Cria = false;
            }
            if (InputLogradouro.Text == "" || InputLogradouro.Text == null)
            {
                DownInputLogradouro.Text = "Informe o Logradouro";
                DownInputLogradouro.IsVisible = true;
                Cria = false;
            }
            if (InputNumero.Text == "" || InputNumero.Text == null)
            {
                DownInputNumero.Text = "Informe o Número";
                DownInputNumero.IsVisible = true;
                Cria = false;
            }
            if (InputComplemento.Text == "" || InputComplemento.Text == null)
            {
                DownComplemento.Text = "Informe o Complemento";
                DownComplemento.IsVisible = true;
                Cria = false;
            }
            if (InputBairro.Text == "" || InputBairro.Text == null)
            {
                DownInputBairro.Text = "Informe o Bairro";
                DownInputBairro.IsVisible = true;
                Cria = false;
            }
            if (InputCodMunicipio.Text == "" || InputCodMunicipio.Text == null)
            {
                DownInputCodMunicipio.Text = "Informe o Código Município";
                DownInputCodMunicipio.IsVisible = true;
                Cria = false;
            }
            if (InputMunicipio.Text == "" || InputMunicipio.Text == null)
            {
                DownInputMunicipio.Text = "Informe o Município";
                DownInputMunicipio.IsVisible = true;
                Cria = false;
            }
            if (InputUF.Text == "" || InputUF.Text == null)
            {
                DownInputUF.Text = "Informe o UF";
                DownInputUF.IsVisible = true;
                Cria = false;
            }
            if (InputCodUF.Text == "" || InputCodUF.Text == null)
            {
                DownInputCodUF.Text = "Informe o Código UF";
                DownInputCodUF.IsVisible = true;
                Cria = false;
            }
            if (InputCEP.Text == "" || InputCEP.Text == null)
            {
                DownInputCEP.Text = "Informe o CEP";
                DownInputCEP.IsVisible = true;
                Cria = false;
            }
            if (InputFone.Text == "" || InputFone.Text == null)
            {
                DownInputFone.Text = "Informe o Telefone";
                DownInputFone.IsVisible = true;
                Cria = false;
            }
            if (PkRegimeTrib.SelectedItem == null)
            {
                DownPkRegimeTrib.Text = "Selecione o Regime Tributário";
                DownPkRegimeTrib.IsVisible = true;
                Cria = false;
            }            
            if (InputAlicotaICMS.Text == "" || InputAlicotaICMS.Text == null)
            {
                DownInputAlicotaICMS.Text = "Informe a alíquota do ICMS";
                DownInputAlicotaICMS.IsVisible = true;
                Cria = false;
            }
            if (InputPathCertificado.Text == "" || InputPathCertificado.Text == null)
            {
                DownInputPathCertificado.Text = "Selecione o certificado";
                DownInputPathCertificado.IsVisible = true;
                Cria = false;
            }
            if (InputSenhaCertificado.Text == "" || InputSenhaCertificado.Text == null)
            {
                DownInputSenhaCertificado.Text = "Informe a Senha do Certificado";
                DownInputSenhaCertificado.IsVisible = true;
                Cria = false;
            }
            if (InputEmailDestino.Text == "" || InputEmailDestino.Text == null)
            {
                DownInputEmailDestino.Text = "Informe o Email Destino das Notas";
                DownInputEmailDestino.IsVisible = true;
                Cria = false;            
            }
            if (InputImpPadrao.Text == "" || InputImpPadrao.Text == null)
            {
                DownInputImpPadrao.Text = "Informe a Impressora Padrão";
                DownInputImpPadrao.IsVisible = true;
                Cria = false;
            }
            if (InputDadClie.Text == "" || InputDadClie.Text == null)
            {
                DownInputDadClie.Text = "Informe o Valor Minimo";
                DownInputDadClie.IsVisible = true;
                Cria = false;
            }
            if (InputIdTolk.Text == "" || InputIdTolk.Text == null)
            {
                DownInputIdTolk.Text = "Informe o Tolken";
                DownInputIdTolk.IsVisible = true;
                Cria = false;
            }
            if (InputCSC.Text == "" || InputCSC.Text == null)
            {
                DownInputCSC.Text = "Informe o CST";
                DownInputCSC.IsVisible = true;
                Cria = false;
            }
            if (PkModalBcICMS.SelectedItem == null)
            {
                DownPkModalBcICMS.Text = "Selecione um valor";
                DownPkModalBcICMS.IsVisible = true;
                Cria = false;
            }
            if (PkModalBcICMSST.SelectedItem == null)
            {
                DownPkModalBcICMSST.Text = "Selecione um valor";
                DownPkModalBcICMSST.IsVisible = true;
                Cria = false;           
            }
            String BaseIcms = PkModalBcICMS.SelectedItem.ToString();
            int BcIcms = -1;
            if (BaseIcms == "Margem Valor Agregado (%)")
            {
                BcIcms = 0;
            }
            if (BaseIcms == "Pauta (Valor)") 
            {
                BcIcms = 1;
            }
            if (BaseIcms == "Preço Tabelado Máx. (valor)")
            {
                BcIcms = 2;
            }
            if (BaseIcms == "Valor da operação")
            {
                BcIcms = 3;
            }
            String BaseIcmsSt = "";
            if (PkModalBcICMSST.SelectedItem != null)
            {
                BaseIcmsSt = PkModalBcICMSST.SelectedItem.ToString();
            }
            int iBaseIcmsSt = -1;
            if (BaseIcmsSt == "Preço tabelado ou máximo  sugerido")
            {
                iBaseIcmsSt = 0;
            }
            if (BaseIcmsSt == "Lista Negativa (valor)")
            {
                iBaseIcmsSt = 1;
            }
            if (BaseIcmsSt == "Lista Positiva (valor)")
            {
                iBaseIcmsSt = 2;
            }
            if (BaseIcmsSt == "Lista Neutra (valor)")
            {
                iBaseIcmsSt = 3;
            }
            if (BaseIcmsSt == "Margem Valor Agregado (%)")
            {
                iBaseIcmsSt = 4;
            }
            if (BaseIcmsSt == "Pauta (valor)")
            {
                iBaseIcmsSt = 5;
            }
            String Rgt = "";
            if (PkRegimeTrib.SelectedItem != null)
            {
                Rgt = PkRegimeTrib.SelectedItem.ToString();
            }

            int IRgt = -1;
            if (Rgt == "Simples Nacional"){ IRgt = 1; }
            if (Rgt == "Lucro Presumido"){ IRgt = 2; }
            if (Rgt == "Lucro Real"){ IRgt = 3; }

            if (Cria == true)
            {
                DownInputUF.IsVisible = false;
                DownInputCEP.IsVisible = false;
                DownInputCSC.IsVisible = false;
                DownInputFone.IsVisible = false;
                DownInputCnpj.IsVisible = false;
                DownInputCodUF.IsVisible = false;
                DownInputAmbAt.IsVisible = false;
                DownInputNumero.IsVisible = false;
                DownComplemento.IsVisible = false;
                DownInputIdTolk.IsVisible = false;
                DownInputBairro.IsVisible = false;
                DownPkRegimeTrib.IsVisible = false;
                DownInputDadClie.IsVisible = false;
                DownInputNtFiscal.IsVisible = false;
                DownPkModalBcICMS.IsVisible = false;
                DownInputImpPadrao.IsVisible = false;
                DownInputMunicipio.IsVisible = false;
                DownPkModalBcICMSST.IsVisible = false;
                DownInputLogradouro.IsVisible = false;
                DownInputRazaoSocial.IsVisible = false;
                DownInputNomFantasia.IsVisible = false;
                DownInputAlicotaICMS.IsVisible = false;
                DownInputEmailDestino.IsVisible = false;
                DownInputPathCertificado.IsVisible = false;
                DownInputSenhaCertificado.IsVisible = false;

                Crt.Cod_Cel = 1;
                Crt.NOME_PN = InputNomFantasia.Text;
                Crt.CNPJ_PN = InputCnpj.Text;
                Crt.ENDERECO_PN = InputLogradouro.Text;
                Crt.NUMERO_PN = InputNumero.Text;
                Crt.CPL_PN = InputComplemento.Text;
                Crt.bairro_pn = InputBairro.Text;
                Crt.CODMUN_PN = InputCodMunicipio.Text;
                Crt.CIDADE_PN = InputMunicipio.Text;
                Crt.uf_PN = InputUF.Text;
                Crt.CEP_PN = InputCEP.Text;
                Crt.FONE_PN = InputFone.Text;
                Crt.IE_PN = InputInsEstadual.Text;
                Crt.SERIE_PN = Convert.ToInt32(InputNtFiscal.Text);
                Crt.PATH_CHAVE = InputPathCertificado.Text;
                Crt.SENHA_CERTIFICADO = InputSenhaCertificado.Text;
                Crt.AMBIENTE_PN = Convert.ToInt32(InputAmbAt.Text);
                Crt.CODUF_PN = InputCodUF.Text;
                Crt.RAZAO_PN = InputRazaoSocial.Text;
                Crt.EMAIL_PN = InputEmailDestino.Text;
                Crt.ISENTO_ATE = InputDadClie.Text;
                Crt.cIdToken = InputIdTolk.Text;
                Crt.CSC = InputCSC.Text;
                Crt.BASEICMS_PN = BcIcms;
                Crt.BASEST_PN = iBaseIcmsSt;
                Crt.SIMPLES_PN = IRgt;
                Crt.INDICAATIVI_PN = 0;
                Crt.inscmun_PN = "";               
                Crt.USACOD_PN = true;                
                Crt.PERCREDCSO = Convert.ToInt32(DownInputAlicotaICMS.Text);
                Crt.IPI_PN = InputContribIpi.IsChecked;
                Crt.IMPRIMEAMBOS_PN = false;
                
                //Crt.TIPOCNPJBAIXAR_PN = ;
                //Crt.CNPJBAIXAR_prd = "";
                //Crt.MODELO_PN = .Text;
                //Crt.Msg_fisco = "";
                //Crt.Msg_Contri = "";
                //Crt.LOCBACK_PN = "";
                //Crt.PATH_SCHEMAS = null;
                //Crt.PATH_MOVIMENTO = null;

                CmCert.DeletarNfePadrao();
                CmCert.CriarBancoNfePadrao();
                CmCert.InserirNfePadrao(Crt);
                
            }
        }
    }
}