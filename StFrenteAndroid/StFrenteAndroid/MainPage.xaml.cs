using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StFrenteAndroid.Assina;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Reflection;
using System.IO;
using Android.Content.Res;
using System.Xml.Schema;
using System.Xml.XPath;

namespace StFrenteAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Certificado cert = new Certificado();
            X509Certificate2 XSertifica = cert.BuscaNome("Andri");

            XmlDocument doc = new XmlDocument();
            doc.Load("/storage/emulated/0/certificados/NotaTeste.xml");
            String xml = doc.InnerXml;

            AssinaturaDigital ass = new AssinaturaDigital();
            //int i = ass.Assinar(xml, "infNFe", XSertifica);
            String nfe40Schema = App.Manager.nfe40();
            AssetManager assets = App.ats;
            XmlReaderSettings Settings = new XmlReaderSettings();
            Settings.Schemas.Add("http://www.portalfiscal.inf.br/nfe", XmlReader.Create(assets.Open("Schemas/nfe_v4.00.xsd")));
            Settings.Schemas.Add("http://www.portalfiscal.inf.br/nfe", XmlReader.Create(assets.Open("Schemas/leiauteNFe_v4.00.xsd")));
            Settings.Schemas.Add("http://www.w3.org/2000/09/xmldsig#", XmlReader.Create(assets.Open("Schemas/xmldsig-core-schema_v1.01.xsd")));
            Settings.Schemas.Add("http://www.portalfiscal.inf.br/nfe", XmlReader.Create(assets.Open("Schemas/tiposBasico_v4.00.xsd")));
            Settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            Settings.ValidationType = ValidationType.Schema;
            try
            {
                XmlReader validator = XmlReader.Create("/storage/emulated/0/certificados/xml.xml", Settings);
                Montagem_lote("/storage/emulated/0/certificados/xml.xml","12345.xml",1234);
                while (validator.Read()){ }
            }
            catch (Exception EX)
            {
                string ex = EX.ToString();
            }
        }
        public String Montagem_lote(String Nota_xml,String Nr_lote,int  NumeroNta)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string NotaPath;
                StreamWriter fluxoTexto;
                string LINHA;
                String SEQ_lote = NumeroNta.ToString();
                SEQ_lote = SEQ_lote.PadLeft(15,'0');
                Nr_lote = "/storage/emulated/0/certificados/" + Nr_lote;
                if (File.Exists(Nota_xml) == false)
                {
                    return "Erro nota nao encontrada";
                }
                NotaPath = Nota_xml;
                doc.PreserveWhitespace = true;
                doc.Load(NotaPath);
                StreamWriter sw = File.CreateText(Nr_lote);
                sw.Close();
                fluxoTexto = new StreamWriter(Nr_lote);
                LINHA = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                fluxoTexto.WriteLine(LINHA);                   
                LINHA = "<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + "4.00" + "\">";
                fluxoTexto.WriteLine(LINHA);
                LINHA = "<idLote>" + SEQ_lote + "</idLote>";
                fluxoTexto.WriteLine(LINHA);
                //0=Não.
                //1=Empresa solicita processamento síncrono do Lote de NF-e (sem a geração de Recibo para consulta futura);
                LINHA = "<indSinc>" + "1" + "</indSinc>";
                fluxoTexto.WriteLine(LINHA);

                string flx = doc.OuterXml;
                flx = flx.Remove(0,38);
                fluxoTexto.WriteLine(flx);
                LINHA = "</enviNFe>";
                fluxoTexto.WriteLine(LINHA);
                fluxoTexto.Close();

                XmlDocument docs = new XmlDocument();
                XmlDocument docx = new XmlDocument();
                docs.Load(Nr_lote);
                String teste = docs.OuterXml;
                teste = teste.Replace(">[\\s\r\n]*<", "><");
                docx.LoadXml(teste);   
                docx.PreserveWhitespace = true;
                docx.Save(Nr_lote);

                return "";
            }
            catch (Exception ex)
            {
                string exs = ex.ToString();
                return "";
            }
        }
        //Display any warnings or errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred. " + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
        }
        private static void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            System.Console.WriteLine(e.Message);
        }
        private static void DocumentValidationHandler(object sender, ValidationEventArgs e)
        {
            System.Console.WriteLine(e.Message);
        }

    }
}