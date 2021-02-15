using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StFrenteAndroid.Services
{
    public class SchemasXml
    {
        ISchemas Schema;


        public SchemasXml(ISchemas service)
        {
            Schema = service;
        }

        public String nfe40()
        {
            return Schema.nfe40();
        }


    }
}
