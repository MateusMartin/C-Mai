using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StFrenteAndroid.Data;
using StFrenteAndroid.Models;

namespace StFrenteAndroid.Droid
{
    class SoapService : ISoapService
    {
        WsCorreio.AtendeClienteService WsCorreio;

        public SoapService()
        {
            WsCorreio = new WsCorreio.AtendeClienteService();
            WsCorreio.Url = "https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl";
        }


        public Endereco GetEndereco(string CEP)
        {
            Endereco ende = new Endereco();
            int i = 0;
            int trys = 0;
            while (i == 0)
            {
                try
                {
                    var resultado = WsCorreio.consultaCEP(CEP);
                    ende.StrEndereco = resultado.end;
                    ende.Complemento2 = resultado.complemento2;
                    ende.Cidade = resultado.cidade;
                    ende.Bairro = resultado.bairro;
                    ende.Estado = resultado.uf;
                    i = 1;
                }
                catch (Exception ex)
                {
                    trys++;
                    if (trys > 10)
                    {
                        i = 1;
                    }
                }
            }

            return ende;
        }
    }
}