using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StFrenteAndroid.Services;


namespace StFrenteAndroid.Droid
{
    class SchemasXml : ISchemas
    {
        public String nfe40()
        {
            String content;
            AssetManager assets = App.ats;
            using (StreamReader sr = new StreamReader(assets.Open("Schemas/nfe_v4.00.xsd")))
            {
                content = sr.ReadToEnd();
            }
            return content;
            throw new NotImplementedException();
        }
    }
}