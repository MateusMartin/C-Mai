using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Data
{
    public class ServiceManager
    {
        ISoapService soapService;

        public ServiceManager(ISoapService service)
        {
            soapService = service;
        }

        public Endereco GetEndereco(String CEP)
        {
            return soapService.GetEndereco(CEP);
        }


    }
}
