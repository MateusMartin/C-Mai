using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;
using System.Xml;
using CarouselView.FormsPlugin.Android;


namespace StFrenteAndroid.Droid
{
    [Activity(Label = "StFrenteAndroid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            AssetManager assets = this.Assets;

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            var listAssets = Assets.List("Schemas");
            CarouselViewRenderer.Init();
            App.Manager = new Services.SchemasXml(new SchemasXml());
            App.SvcManager = new Data.ServiceManager(new SoapService());
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(assets));
            
        }
    }


}