using SQLite;
using StFrenteAndroid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StFrenteAndroid.SQL
{
    public class CommandCertificado
    {

        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CriarBancoCertificado()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.CreateTable<Certificado>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public bool DeletarCertificado()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.DropTable<Certificado>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }
        public bool InserirCertificado(Certificado SQLServ)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    conexao.Insert(SQLServ);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return false;
            }
        }

        public List<Certificado> GetCertificado()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "StfrenteAndroid.db")))
                {
                    return conexao.Query<Certificado>("SELECT * FROM Certificado");
                }
            }
            catch (SQLiteException ex)
            {
                String exs = ex.ToString();
                return null;
            }
        }

    }
}
