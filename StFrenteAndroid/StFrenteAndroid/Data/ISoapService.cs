using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.Data
{
    public interface ISoapService
    {
        Endereco GetEndereco(String CEP);

    }
}
