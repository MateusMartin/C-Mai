using Android.Content.Res;
using StFrenteAndroid.Data;
using StFrenteAndroid.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StFrenteAndroid
{
    public partial class App : Application
    {

        public static SchemasXml Manager { get; set; }
        public static AssetManager ats { get; set; }
        public static ServiceManager SvcManager { get; set; }

        public App(AssetManager assets)
        {
            InitializeComponent();

            MainPage = new MenuSistema();
            ats = assets;

            if (!Directory.Exists("/storage/emulated/0/StFrente/Notas"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/Notas");           
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/Mensagens"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/Mensagens");
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/Retornos"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/Retornos");
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/NotasDBck"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/NotasDBck");
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/NFCE/Notas"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/NFCE/Notas");
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/NFCE/Mensagens"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/NFCE/Mensagens");
            }

            if (!Directory.Exists("/storage/emulated/0/StFrente/NFCE/Retornos"))
            {
                // This path is a directory
                Directory.CreateDirectory("/storage/emulated/0/StFrente/NFCE/Retornos");
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
